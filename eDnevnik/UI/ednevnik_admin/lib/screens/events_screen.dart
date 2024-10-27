import 'dart:convert';
import 'dart:io';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/events.dart';
import 'package:ednevnik_admin/providers/events_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class EventsDetailScreen extends StatefulWidget {
  const EventsDetailScreen({super.key});

  @override
  State<EventsDetailScreen> createState() => _EventsDetailScreenState();
}

class _EventsDetailScreenState extends State<EventsDetailScreen> {
  List<School> _schools = [];
  School? _selectedSchool;
  List<Events> _eventsList = [];

  late SchoolProvider _schoolProvider;
  late EventsProvider _eventsProvider;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController _nazivController = TextEditingController();
  final TextEditingController _opisController = TextEditingController();

  DateTime? _selectedDate;
  File? _image;
  String? _base64Image;
  bool _isSlikaSelected = false;

  @override
  void initState() {
    super.initState();
    _schoolProvider = context.read<SchoolProvider>();
    _eventsProvider = context.read<EventsProvider>();
    _fetchSchools();
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchEvents();
          }
        });
      }
    } catch (e) {
      setState(() {});
    }
  }

  Future<void> _fetchEvents() async {
    if (_selectedSchool != null) {
      try {
        var events = await _eventsProvider
            .get(filter: {'SkolaID': _selectedSchool?.skolaID});
        if (mounted) {
          setState(() {
            _eventsList = events.result;
          });
        }
      } catch (e) {
        setState(() {
          _eventsList = [];
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20.0),
            ),
            child: Column(
              children: [
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                Expanded(child: _buildEventCards()),
                SizedBox(height: 16),
                _buildActionButtons(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildEventCards() {
    if (_eventsList.isEmpty) {
      return Center(
        child: Text("Nema događaja za odabranu školu."),
      );
    }

    return GridView.builder(
      padding: const EdgeInsets.all(16.0),
      itemCount: _eventsList.length,
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
        crossAxisCount: 4,
        crossAxisSpacing: 8,
        mainAxisSpacing: 8,
        childAspectRatio: 0.75,
      ),
      itemBuilder: (context, index) {
        Events event = _eventsList[index];
        return _buildEventCard(event);
      },
    );
  }

  Widget _buildEventCard(Events event) {
    bool isActive = event.stateMachine == "active";
    bool isDraft = event.stateMachine == "draft";

    return Card(
      elevation: 4,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
      ),
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Flexible(
                      child: Text(
                        event.nazivDogadjaja ?? "No Name",
                        overflow: TextOverflow.ellipsis,
                        style: TextStyle(
                            fontSize: 18, fontWeight: FontWeight.bold),
                      ),
                    ),
                    Row(
                      children: [
                        Tooltip(
                          message: "Uređivanje događaja",
                          child: IconButton(
                            icon: Icon(Icons.edit,
                                color: isActive ? Colors.grey : Colors.blue),
                            onPressed: isActive
                                ? null
                                : () {
                                    _showEditEventDialog(event);
                                  },
                          ),
                        ),
                        Tooltip(
                          message: "Brisanje događaja",
                          child: IconButton(
                            icon: Icon(Icons.delete,
                                color: isActive ? Colors.grey : Colors.red),
                            onPressed: isActive
                                ? null
                                : () {
                                    _confirmDeleteEvent(event);
                                  },
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
                SizedBox(height: 8),
                event.slika != null && event.slika!.isNotEmpty
                    ? Container(
                        height: 100,
                        width: double.infinity,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          image: DecorationImage(
                            image: _buildImageFromBase64(event.slika!),
                            fit: BoxFit.cover,
                          ),
                        ),
                      )
                    : _buildPlaceholderImage(),
                SizedBox(height: 8),
                Text(
                  event.opisDogadjaja ?? "No Description",
                  maxLines: 2,
                  overflow: TextOverflow.ellipsis,
                  style: TextStyle(fontSize: 14),
                ),
                SizedBox(height: 8),
                Center(
                  child: Text(
                    event.datumDogadjaja != null
                        ? DateFormat('yyyy-MM-dd').format(event.datumDogadjaja!)
                        : "No Date",
                    style: TextStyle(color: Colors.grey),
                  ),
                ),
              ],
            ),
            SizedBox(height: 16),
            _buildActionButtons2(event, isActive, isDraft),
          ],
        ),
      ),
    );
  }

  Widget _buildActionButtons2(Events event, bool isActive, bool isDraft) {
    return Column(
      children: [
        SizedBox(
          width: double.infinity,
          child: Tooltip(
            message: "Aktiviraj događaj",
            child: ElevatedButton(
              onPressed: isDraft
                  ? () async {
                      try {
                        await _eventsProvider.activate(event.dogadjajId!);
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text("Događaj uspješno aktiviran"),
                            backgroundColor: Colors.green,
                          ),
                        );
                        _fetchEvents();
                      } catch (e) {
                        _showErrorDialog("Error activating event: $e");
                      }
                    }
                  : null,
              style: ElevatedButton.styleFrom(
                backgroundColor: isDraft ? Colors.green : Colors.grey,
                foregroundColor: Colors.white,
              ),
              child: Text("Aktiviraj Događaj"),
            ),
          ),
        ),
        SizedBox(height: 8),
        SizedBox(
          width: double.infinity,
          child: Tooltip(
            message: "Sakrij događaj",
            child: ElevatedButton(
              onPressed: isActive
                  ? () async {
                      try {
                        await _eventsProvider.hide(event.dogadjajId!);
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text("Događaj uspješno sakriven"),
                            backgroundColor: Colors.green,
                          ),
                        );
                        _fetchEvents();
                      } catch (e) {
                        _showErrorDialog("Error hiding event: $e");
                      }
                    }
                  : null,
              style: ElevatedButton.styleFrom(
                backgroundColor: isActive ? Colors.orange : Colors.grey,
                foregroundColor: Colors.white,
              ),
              child: Text("Sakrij Događaj"),
            ),
          ),
        ),
      ],
    );
  }

  Future<void> _showEditEventDialog(Events event) {
    String? errorMessage;

    _nazivController.text = event.nazivDogadjaja ?? '';
    _opisController.text = event.opisDogadjaja ?? '';
    _selectedDate = event.datumDogadjaja;
    _base64Image = event.slika;
    _isSlikaSelected = _base64Image != null;

    return showDialog(
      context: context,
      builder: (context) {
        return StatefulBuilder(
          builder: (BuildContext context, StateSetter setState) {
            return AlertDialog(
              title: Text("Uredi Događaj"),
              content: Form(
                key: _formKey,
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      _buildTextField("Naziv događaja", _nazivController, true),
                      SizedBox(height: 16),
                      _buildTextField("Opis događaja", _opisController, false),
                      SizedBox(height: 16),
                      _buildDateButton(setState),
                      SizedBox(height: 16),
                      _buildImageButton(setState),
                      SizedBox(height: 16),
                      _buildImagePreview(),
                      if (_isSlikaSelected) SizedBox(height: 16),
                      if (errorMessage != null)
                        Padding(
                          padding: const EdgeInsets.only(top: 16.0),
                          child: Text(
                            errorMessage!,
                            style: TextStyle(color: Colors.red),
                          ),
                        ),
                    ],
                  ),
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () {
                    _resetForm();
                    Navigator.pop(context);
                  },
                  child: Text("Odustani"),
                  style:
                      ElevatedButton.styleFrom(foregroundColor: Colors.black),
                ),
                ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState!.validate() &&
                        _selectedDate != null &&
                        _base64Image != null) {
                      setState(() {
                        errorMessage = null;
                      });

                      var updatedEvent = {
                        'nazivDogadjaja': _nazivController.text,
                        'opisDogadjaja': _opisController.text,
                        'slika': _base64Image,
                        'datumDogadjaja': _selectedDate?.toIso8601String(),
                      };

                      try {
                        await _eventsProvider.Update(
                            event.dogadjajId!, updatedEvent);
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text("Uspješno ste ažurirali događaj."),
                            backgroundColor: Colors.green,
                          ),
                        );
                        Navigator.pop(context);
                        _resetForm();
                        _fetchEvents();
                      } catch (e) {
                        _showErrorDialog("Failed to update event.");
                      }
                    } else {
                      setState(() {
                        if (_selectedDate == null) {
                          errorMessage = "Molimo odaberite datum događaja.";
                        } else if (_base64Image == null) {
                          errorMessage = "Molimo odaberite sliku za događaj.";
                        }
                      });
                    }
                  },
                  style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.green,
                      foregroundColor: Colors.white),
                  child: Text("Uredi"),
                ),
              ],
            );
          },
        );
      },
    );
  }

  Widget _buildPlaceholderImage() {
    return Container(
      height: 100,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.grey[200],
        borderRadius: BorderRadius.circular(10),
      ),
      child: Center(
        child: Icon(Icons.image, size: 50, color: Colors.grey),
      ),
    );
  }

  ImageProvider _buildImageFromBase64(String base64String) {
    try {
      return MemoryImage(base64Decode(base64String));
    } catch (e) {
      print("Error decoding base64 image: $e");
      return const NetworkImage("https://via.placeholder.com/150");
    }
  }

  Widget _buildScreenHeader() {
    return Row(
      children: [
        Container(
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(5),
              topLeft: Radius.circular(20),
              topRight: Radius.elliptical(5, 5),
              bottomRight: Radius.circular(30.0),
            ),
          ),
          padding: const EdgeInsets.all(16.0),
          child: Text(
            "Događaji",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 16.0),
        Expanded(
          child: _buildSchoolDropdown(),
        ),
      ],
    );
  }

  Widget _buildSchoolDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 210,
          child: DropdownButton<School>(
            value: _selectedSchool,
            items: _schools.map((school) {
              return DropdownMenuItem<School>(
                value: school,
                child: Text(school.naziv ?? "N/A"),
              );
            }).toList(),
            onChanged: (School? newValue) {
              setState(() {
                _selectedSchool = newValue;
                _fetchEvents();
              });
            },
          ),
        ),
      ],
    );
  }

  Widget _buildActionButtons() {
    return Padding(
      padding: const EdgeInsets.only(right: 16.0, bottom: 16.0),
      child: Align(
        alignment: Alignment.bottomRight,
        child: ElevatedButton(
          onPressed: () => _showEventDialog(),
          style: ElevatedButton.styleFrom(
            padding:
                const EdgeInsets.symmetric(horizontal: 24.0, vertical: 12.0),
            backgroundColor: Colors.blue,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(30.0),
            ),
          ),
          child: Text(
            "Dodaj događaj",
            style: TextStyle(
              color: Colors.white,
              fontSize: 16,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ),
    );
  }

  Future<void> _showEventDialog() {
    String? errorMessage;

    return showDialog(
      context: context,
      builder: (context) {
        return StatefulBuilder(
          builder: (BuildContext context, StateSetter setState) {
            return AlertDialog(
              title: Text("Dodaj Događaj"),
              content: Form(
                key: _formKey,
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      _buildTextField("Naziv događaja", _nazivController, true),
                      SizedBox(height: 16),
                      _buildTextField("Opis događaja", _opisController, false),
                      SizedBox(height: 16),
                      _buildDateButton(setState),
                      if (_selectedDate == null && errorMessage != null)
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0),
                          child: Text(
                            "Molimo odaberite datum događaja.",
                            style: TextStyle(color: Colors.red),
                          ),
                        ),
                      SizedBox(height: 16),
                      _buildImageButton(setState),
                      SizedBox(height: 16),
                      _buildImagePreview(),
                      if (_isSlikaSelected) SizedBox(height: 16),
                      if (_base64Image == null && errorMessage != null)
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0),
                          child: Text(
                            "Molimo odaberite sliku za događaj.",
                            style: TextStyle(color: Colors.red),
                          ),
                        ),
                    ],
                  ),
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () {
                    _resetForm();
                    Navigator.pop(context);
                  },
                  child: Text("Odustani"),
                  style:
                      ElevatedButton.styleFrom(foregroundColor: Colors.black),
                ),
                ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState!.validate() &&
                        _selectedDate != null &&
                        _base64Image != null) {
                      setState(() {
                        errorMessage = null;
                      });

                      Events newEvent = Events(
                        null,
                        _nazivController.text,
                        _opisController.text,
                        _base64Image,
                        _selectedDate,
                        "active",
                        _selectedSchool?.skolaID,
                      );

                      try {
                        await _eventsProvider.Insert(newEvent);
                        Navigator.pop(context);
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text("Uspješno ste dodali novi događaj."),
                            backgroundColor: Colors.green,
                          ),
                        );
                        _resetForm();
                        _fetchEvents();
                      } catch (e) {
                        _showErrorDialog("Failed to delete event.");
                      }
                    } else {
                      setState(() {
                        if (_selectedDate == null) {
                          errorMessage = "Molimo odaberite datum događaja.";
                        }
                        if (_base64Image == null) {
                          errorMessage = "Molimo odaberite sliku za događaj.";
                        }
                      });
                    }
                  },
                  style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.green,
                      foregroundColor: Colors.white),
                  child: Text("Dodaj"),
                ),
              ],
            );
          },
        );
      },
    );
  }

  void _resetForm() {
    _nazivController.clear();
    _opisController.clear();
    _selectedDate = null;
    _base64Image = null;
    _isSlikaSelected = false;
  }

  Widget _buildTextField(
      String label, TextEditingController controller, bool isNaziv) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8.0),
      child: FormBuilderTextField(
        name: label,
        controller: controller,
        decoration: InputDecoration(labelText: label),
        validator: FormBuilderValidators.compose([
          FormBuilderValidators.required(errorText: "$label je obavezno polje"),
          if (isNaziv) ...[
            FormBuilderValidators.match(RegExp(r"^[A-Z]"),
                errorText: "Morate započeti velikim slovom"),
            FormBuilderValidators.minLength(4,
                errorText: "Morate imati najmanje 4 znaka"),
            FormBuilderValidators.match(RegExp(r"^[A-Za-z]+$"),
                errorText: "Polje sadrži samo slova"),
          ] else ...[
            FormBuilderValidators.match(RegExp(r"^[A-Z]"),
                errorText: "Morate započeti velikim slovom"),
            FormBuilderValidators.minLength(4,
                errorText: "Morate imati najmanje 4 znaka"),
            FormBuilderValidators.match(RegExp(r"^[A-Z][a-zA-Z.,!? ]+$"),
                errorText: "Polje sadrži samo slova i znakove . , ! ?"),
            FormBuilderValidators.match(RegExp(r"[.,!?]$"),
                errorText: "Morate završiti s . , ! ili ?"),
          ],
        ]),
      ),
    );
  }

  Widget _buildImageButton(StateSetter setState) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8.0),
      child: SizedBox(
        width: double.infinity,
        child: ElevatedButton(
          onPressed: () async {
            var result =
                await FilePicker.platform.pickFiles(type: FileType.image);
            if (result != null && result.files.single.path != null) {
              setState(() {
                _image = File(result.files.single.path!);
                _base64Image = base64Encode(_image!.readAsBytesSync());
                _isSlikaSelected = true;
              });
            }
          },
          style: ElevatedButton.styleFrom(
              backgroundColor: Colors.blue, foregroundColor: Colors.white),
          child: Text("Odaberite sliku"),
        ),
      ),
    );
  }

  Widget _buildImagePreview() {
    if (_isSlikaSelected && _image != null) {
      return Container(
        height: 150,
        width: double.infinity,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          image: DecorationImage(
            image: FileImage(_image!),
            fit: BoxFit.cover,
          ),
        ),
      );
    } else if (_base64Image != null) {
      return Container(
        height: 150,
        width: double.infinity,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          image: DecorationImage(
            image: _buildImageFromBase64(_base64Image!),
            fit: BoxFit.cover,
          ),
        ),
      );
    } else {
      return _buildPlaceholderImage();
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Error'),
        content: Text(message),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text('OK'),
          ),
        ],
      ),
    );
  }

  Future<void> _confirmDeleteEvent(Events event) async {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Potvrda brisanja'),
        content: Text('Da li ste sigurni da želite da obrišete ovaj događaj?'),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context, false),
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.black,
              backgroundColor: Colors.white,
            ),
            child: Text('Odustani'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.red,
            ),
            child: Text('Izbriši'),
          ),
        ],
      ),
    );

    if (confirmDelete == true) {
      await _deleteEvent(event);
    }
  }

  Future<void> _deleteEvent(Events event) async {
    if (event.dogadjajId != null) {
      try {
        print('Deleting event with ID: ${event.dogadjajId}');
        await _eventsProvider.delete(event.dogadjajId!);
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text("Uspješno ste izbrisali događaj."),
            backgroundColor: Colors.green,
          ),
        );
        _fetchEvents();
      } catch (e) {
        _showErrorDialog("Greška prilikom brisanja događaja: $e");
      }
    }
  }

  Widget _buildDateButton(StateSetter setState) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8.0),
      child: SizedBox(
        width: double.infinity,
        child: ElevatedButton(
          onPressed: () => _selectDate(context, setState),
          child: Text(
            _selectedDate == null
                ? "Odaberite datum događaja"
                : DateFormat('yyyy-MM-dd').format(_selectedDate!),
          ),
          style: ElevatedButton.styleFrom(
              backgroundColor: Colors.blue, foregroundColor: Colors.white),
        ),
      ),
    );
  }

  Future<void> _selectDate(BuildContext context, StateSetter setState) async {
    final DateTime currentDate = DateTime.now();
    final DateTime firstSelectableDate = currentDate.add(Duration(days: 3));
    final DateTime lastDate = DateTime(2101);

    final DateTime initialDate =
        (_selectedDate != null && _selectedDate!.isAfter(firstSelectableDate))
            ? _selectedDate!
            : firstSelectableDate;

    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: initialDate,
      firstDate: firstSelectableDate,
      lastDate: lastDate,
    );

    if (picked != null && picked != _selectedDate) {
      setState(() {
        _selectedDate = picked;
      });
    }
  }

  Future<void> _submitEventForm() async {
    if (_formKey.currentState!.validate() &&
        _selectedDate != null &&
        _base64Image != null) {
      Events newEvent = Events(
        null,
        _nazivController.text,
        _opisController.text,
        _base64Image,
        _selectedDate,
        "active",
        _selectedSchool?.skolaID,
      );

      try {
        await _eventsProvider.Insert(newEvent);
        Navigator.pop(context);
        _resetForm();
        ScaffoldMessenger.of(context).showSnackBar(SnackBar(
          content: Text("Događaj uspješno dodan"),
          backgroundColor: Colors.green,
        ));
        _fetchEvents();
      } catch (e) {
        _showErrorDialog("An error occurred.");
      }
    } else {
      if (_selectedDate == null) {
        ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text("Molimo odaberite datum događaja.")));
      }
      if (_base64Image == null) {
        ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text("Molimo odaberite sliku za događaj.")));
      }
    }
  }
}
