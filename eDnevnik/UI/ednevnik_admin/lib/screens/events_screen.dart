import 'dart:convert';
import 'dart:io';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
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
          }
        });
      }
    } catch (e) {
      setState(() {});
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
                Expanded(child: Container()),
                _buildActionButtons(),
              ],
            ),
          ),
        ),
      ),
    );
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
          width: 300,
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
                      _buildTextField("Naziv događaja", _nazivController),
                      SizedBox(height: 16),
                      _buildTextField("Opis događaja", _opisController),
                      SizedBox(height: 16),
                      _buildDateButton(),
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
                  onPressed: () => Navigator.pop(context),
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
                            SnackBar(content: Text("Događaj uspješno dodan")));
                        _resetForm();
                      } catch (e) {
                        _showErrorDialog();
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
                  child: Text("Dodaj"),
                ),
              ],
            );
          },
        );
      },
    );
  }

  Widget _buildTextField(String label, TextEditingController controller) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8.0),
      child: TextFormField(
        controller: controller,
        decoration: InputDecoration(labelText: label),
        validator: (value) {
          if (value == null || value.isEmpty) {
            return "$label je obavezno polje";
          }
          return null;
        },
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
    return _isSlikaSelected && _image != null
        ? Container(
            height: 150,
            width: double.infinity,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(10),
              image: DecorationImage(
                image: FileImage(_image!),
                fit: BoxFit.cover,
              ),
            ),
          )
        : const SizedBox.shrink();
  }

  Widget _buildDateButton() {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8.0),
      child: SizedBox(
        width: double.infinity,
        child: ElevatedButton(
          onPressed: () => _selectDate(context),
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

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime.now().add(Duration(days: 5)),
      firstDate: DateTime.now().add(Duration(days: 5)),
      lastDate: DateTime(2101),
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
        ScaffoldMessenger.of(context)
            .showSnackBar(SnackBar(content: Text("Događaj uspješno dodan")));
        _resetForm();
      } catch (e) {
        _showErrorDialog();
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

  void _resetForm() {
    setState(() {
      _nazivController.clear();
      _opisController.clear();
      _selectedDate = null;
      _image = null;
      _base64Image = null;
      _isSlikaSelected = false;
      _selectedSchool = _schools.isNotEmpty ? _schools.first : null;
    });
  }

  void _showErrorDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Greška"),
          content:
              Text("Greška prilikom dodavanja događaja. Pokušajte ponovo."),
          actions: [
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: Text("U redu"),
            ),
          ],
        );
      },
    );
  }
}
