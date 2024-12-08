import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/models/school_year.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/screens/classes_student_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'dart:collection';

class CalendarDetailScreen extends StatefulWidget {
  const CalendarDetailScreen({super.key});

  @override
  State<CalendarDetailScreen> createState() => _CalendarDetailScreenState();
}

class _CalendarDetailScreenState extends State<CalendarDetailScreen> {
  School? _selectedSchool;
  List<School> _schools = [];
  List<Classes> _classes = [];
  DateTime _focusedDay = DateTime.now();
  DateTime? _selectedDay;
  User? loggedInUser;
  List<User> _profesors = [];
  User? _selectedProfesor;

  User _allProfesorsOption =
      User(null, "Svi profesori", "", "", "", "", "", "", [], [], null);

  late ClassesProvider _classesProvider;
  late SchoolProvider _schoolProvider;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;
  late DepartmentSubjectProvider _departmentSubjectProvider;
  late UserProvider _userProvider;
  late SchoolYearProvider _schoolYearProvider;

  List<DepartmentSubject> _departmentSubjects = [];
  List<AnnualPlanProgram> _annualPlanPrograms = [];
  List<Classes> _filteredClasses = [];
  List<SchoolYear> _schoolYears = [];

  AnnualPlanProgram? _selectedAnnualPlanProgram;
  Classes? _selectedClass;
  SchoolYear? _selectedSchoolYear;

  Map<DateTime, List<Classes>> _groupedClasses = {};

  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _schoolProvider = context.read<SchoolProvider>();
    _classesProvider = context.read<ClassesProvider>();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _userProvider = context.read<UserProvider>();
    _schoolYearProvider = context.read<SchoolYearProvider>();

    _fetchSchoolYears();
    _fetchSchools();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
  }

  Future<void> _fetchSchoolYears() async {
    try {
      var schoolYearsData = await _schoolYearProvider.get();
      if (mounted) {
        setState(() {
          _schoolYears = [
            SchoolYear(skolskaGodinaID: null, naziv: "Sve godine"),
            ...schoolYearsData.result,
          ];
          _selectedSchoolYear = _schoolYears.first;
        });
      }
    } catch (e) {
      print("Failed to load school years: $e");
    }
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchClassess();
            _fetchAnnualPlanPrograms();
          }
        });
      }
    } catch (e) {
      print("Failed to fetch schools: $e");
    }
  }

  Future<void> _fetchProfesors() async {
    if (_annualPlanPrograms.isEmpty) {
      return;
    }

    setState(() {
      _isLoading = true;
      _profesors = [];
    });

    try {
      List<int> profesorIds = [];

      for (var program in _annualPlanPrograms) {
        if (program.profesorID != null) {
          profesorIds.add(program.profesorID!);
        }
      }

      profesorIds = List.from(profesorIds.toSet());
      List<User> fetchedProfesors = [];
      for (int id in profesorIds) {
        var response = await _userProvider.get(filter: {'KorisnikID': id});
        if (response.result.isNotEmpty) {
          fetchedProfesors.add(response.result.first);
        }
      }

      if (mounted) {
        setState(() {
          _profesors = [_allProfesorsOption, ...fetchedProfesors];
          _selectedProfesor = _profesors.isNotEmpty ? _profesors.first : null;
        });
      }
    } catch (e) {
      print("Error fetching professors: $e");
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Widget _buildProfesorDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 180,
          child: DropdownButton<SchoolYear>(
            value: _selectedSchoolYear,
            onChanged: (SchoolYear? newValue) {
              setState(() {
                _selectedSchoolYear = newValue;
                _fetchClassess();
              });
            },
            items: _schoolYears.map((SchoolYear year) {
              return DropdownMenuItem<SchoolYear>(
                value: year,
                child: Text(year.naziv ?? ""),
              );
            }).toList(),
          ),
        ),
        SizedBox(
          width: 16,
        ),
        Container(
          width: 180,
          child: DropdownButton<User>(
            value: _selectedProfesor,
            items: _profesors.map((profesor) {
              return DropdownMenuItem<User>(
                value: profesor,
                child: Text("${profesor.ime} ${profesor.prezime}"),
              );
            }).toList(),
            onChanged: (User? newValue) {
              setState(() {
                _selectedProfesor = newValue;
              });
              _fetchClassess();
            },
          ),
        ),
      ],
    );
  }

  Future<void> _fetchClassess() async {
    if (_selectedSchool == null) return;

    try {
      var classesResponse = await _classesProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
        'ProfesorID': _selectedProfesor?.korisnikId,
        'SkolskaGodinaID': _selectedSchoolYear?.skolskaGodinaID
      });

      if (mounted) {
        setState(() {
          _classes = classesResponse.result
              .where((classItem) => classItem.datumOdrzavanjaCasa != null)
              .toList();

          _groupClassesByDate();
        });
      }
    } catch (e) {
      print("Failed to fetch classes: $e");
    }
  }

  Future<void> _fetchAnnualPlanPrograms() async {
    if (_selectedSchool == null) return;

    try {
      var annualPlanResponse = await _annualPlanProgramProvider.get(filter: {
        'SkolaID': _selectedSchool!.skolaID,
      });

      setState(() {
        _annualPlanPrograms = annualPlanResponse.result;
      });

      _fetchProfesors();
    } catch (e) {
      print("Failed to fetch Annual Plan Programs: $e");
    }
  }

  List<AnnualPlanProgram> _getFilteredAnnualPlanPrograms() {
    Set<String> seenSubjects = {};

    return _annualPlanPrograms.where((program) {
      String combinationKey = "${program.predmetID}-${program.odjeljenjeID}";

      if (!seenSubjects.contains(combinationKey)) {
        seenSubjects.add(combinationKey);
        return true;
      }

      return false;
    }).toList();
  }

  Future<void> _fetchClasses(BuildContext dialogContext) async {
    if (_selectedAnnualPlanProgram == null) return;

    try {
      var classesResponse = await _classesProvider.get(filter: {
        'GodisnjiPlanProgramID':
            _selectedAnnualPlanProgram!.godisnjiPlanProgramID,
      });

      setState(() {
        _filteredClasses = classesResponse.result.where((classItem) {
          return !_groupedClasses.values.any((classList) => classList.any(
              (existingClass) => existingClass.casoviID == classItem.casoviID));
        }).toList();

        _selectedClass = null;

        (dialogContext as Element).markNeedsBuild();
      });
    } catch (e) {
      print("Failed to fetch classes: $e");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Align(
        alignment: Alignment.topLeft,
        child: Container(
          width: double.infinity,
          height: double.infinity,
          color: Color(0xFFF7F2FA),
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20.0),
              ),
              child: _isLoading
                  ? Center(
                      child: CircularProgressIndicator(),
                    )
                  : SingleChildScrollView(
                      child: Column(
                        children: [
                          _buildScreenName(),
                          SizedBox(height: 16.0),
                          _buildCalendar(),
                          SizedBox(height: 20),
                          if (_selectedDay != null) _buildSelectedClasses(),
                          SizedBox(height: 20),
                          _buildAddClassesButton(),
                        ],
                      ),
                    ),
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenName() {
    return Align(
      alignment: Alignment.centerLeft,
      child: Column(
        children: [
          Row(
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
                  "Kalendar",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              Expanded(child: _buildSchoolDropdown()),
            ],
          ),
          SizedBox(height: 16),
          _buildProfesorDropdown(),
        ],
      ),
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
              if (newValue == null || newValue == _selectedSchool) return;

              setState(() {
                _selectedSchool = newValue;
                _profesors = [];
                _selectedProfesor = null;
              });

              _fetchAnnualPlanPrograms().then((_) => _fetchProfesors());
              _fetchClassess();
            },
          ),
        ),
      ],
    );
  }

  void _groupClassesByDate() {
    _groupedClasses.clear();
    for (var classItem in _classes) {
      if (classItem.datumOdrzavanjaCasa != null) {
        DateTime eventDate = DateTime(
          classItem.datumOdrzavanjaCasa!.year,
          classItem.datumOdrzavanjaCasa!.month,
          classItem.datumOdrzavanjaCasa!.day,
        );

        if (_groupedClasses[eventDate] == null) {
          _groupedClasses[eventDate] = [];
        }
        _groupedClasses[eventDate]?.add(classItem);
      }
    }
  }

  List<Classes> _getClassesForDay(DateTime day) {
    DateTime normalizedDay = DateTime(day.year, day.month, day.day);

    return _groupedClasses[normalizedDay] ?? [];
  }

  Future<void> _showAddClassDialog(BuildContext context) async {
    final _formKey = GlobalKey<FormBuilderState>();

    DateTime? selectedDate;
    String? selectedTime;
    List<String> availableTimes = ['08:00', '09:00', '10:00', '11:00', '12:00'];
    List<String> filteredTimes = List.from(availableTimes);

    DateTime initialDate = DateTime.now();
    if (initialDate.weekday == DateTime.saturday) {
      initialDate = initialDate.add(Duration(days: 2));
    } else if (initialDate.weekday == DateTime.sunday) {
      initialDate = initialDate.add(Duration(days: 1));
    }

    if (initialDate.month < 9) {
      initialDate = DateTime(initialDate.year, 9, 1);
    }

    await showDialog(
      context: context,
      builder: (dialogContext) {
        return StatefulBuilder(builder: (context, setState) {
          return AlertDialog(
            title: Text('Dodaj časove za kalendar'),
            content: FormBuilder(
              key: _formKey,
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  FormBuilderField(
                    name: 'datePicker',
                    validator: FormBuilderValidators.required(
                      errorText: "Ovo polje je obavezno!",
                    ),
                    builder: (field) => Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        ElevatedButton(
                          onPressed: () async {
                            DateTime? pickedDate = await showDatePicker(
                              context: context,
                              initialDate: initialDate,
                              firstDate: DateTime(initialDate.year, 9, 1),
                              lastDate: DateTime(initialDate.year, 12, 31),
                              selectableDayPredicate: (DateTime day) {
                                return (day.month >= 9 && day.month <= 12) &&
                                    (day.weekday != DateTime.saturday &&
                                        day.weekday != DateTime.sunday);
                              },
                            );
                            if (pickedDate != null) {
                              setState(() {
                                selectedDate = pickedDate;

                                List<Classes> classesForSelectedDate =
                                    _getClassesForDay(pickedDate);
                                List<String> occupiedTimes =
                                    classesForSelectedDate.map((classItem) {
                                  return "${classItem.datumOdrzavanjaCasa!.hour.toString().padLeft(2, '0')}:${classItem.datumOdrzavanjaCasa!.minute.toString().padLeft(2, '0')}";
                                }).toList();

                                filteredTimes = availableTimes
                                    .where(
                                        (time) => !occupiedTimes.contains(time))
                                    .toList();
                              });
                              field.didChange(pickedDate);
                            }
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.blue,
                          ),
                          child: Text(selectedDate == null
                              ? 'Odaberite datum'
                              : 'Datum: ${selectedDate!.toLocal()}'),
                        ),
                        if (field.hasError)
                          Text(
                            field.errorText!,
                            style: TextStyle(color: Colors.red),
                          ),
                      ],
                    ),
                  ),
                  SizedBox(height: 16),
                  FormBuilderDropdown<String>(
                    name: 'selectedTime',
                    isExpanded: true,
                    decoration: InputDecoration(
                      hintText: 'Odaberite vrijeme',
                    ),
                    validator: FormBuilderValidators.required(
                      errorText: "Ovo polje je obavezno!",
                    ),
                    items: filteredTimes.map((String time) {
                      return DropdownMenuItem<String>(
                        value: time,
                        child: Text(time),
                      );
                    }).toList(),
                    onChanged: (newValue) {
                      setState(() {
                        selectedTime = newValue;
                      });
                    },
                  ),
                  SizedBox(height: 16),
                  FormBuilderDropdown<AnnualPlanProgram>(
                    name: 'annualPlanProgram',
                    isExpanded: true,
                    decoration: InputDecoration(
                      hintText: 'Odaberite Godišnji plan program',
                    ),
                    validator: FormBuilderValidators.required(
                      errorText: "Ovo polje je obavezno!",
                    ),
                    items: _getFilteredAnnualPlanPrograms()
                        .map((AnnualPlanProgram program) {
                      return DropdownMenuItem<AnnualPlanProgram>(
                        value: program,
                        child: Text(program.naziv ?? 'N/A'),
                      );
                    }).toList(),
                    onChanged: (newValue) {
                      setState(() {
                        _selectedAnnualPlanProgram = newValue;
                        _selectedClass = null;
                        _fetchClasses(dialogContext);
                      });
                    },
                  ),
                  if (_filteredClasses.isNotEmpty) ...[
                    SizedBox(height: 16),
                    FormBuilderDropdown<Classes>(
                      name: 'selectedClass',
                      isExpanded: true,
                      decoration: InputDecoration(
                        hintText: 'Odaberite Čas',
                      ),
                      validator: FormBuilderValidators.required(
                        errorText: "Ovo polje je obavezno!",
                      ),
                      items: _filteredClasses.map((Classes classItem) {
                        return DropdownMenuItem<Classes>(
                          value: classItem,
                          child: Text(classItem.nazivCasa ?? 'N/A'),
                        );
                      }).toList(),
                      onChanged: (newValue) {
                        setState(() {
                          _selectedClass = newValue;
                        });
                      },
                    ),
                  ],
                ],
              ),
            ),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
                child: Text('Otkaži'),
              ),
              ElevatedButton(
                onPressed: () {
                  if (_formKey.currentState!.validate()) {
                    final selectedDate = _formKey
                        .currentState!.fields['datePicker']?.value as DateTime?;
                    final selectedTime = _formKey
                        .currentState!.fields['selectedTime']?.value as String?;
                    final selectedClass = _formKey.currentState!
                        .fields['selectedClass']?.value as Classes?;

                    if (selectedDate != null &&
                        selectedTime != null &&
                        _selectedClass != null &&
                        _selectedAnnualPlanProgram != null) {
                      _addClassForDay(selectedDate, selectedTime);
                      Navigator.of(context).pop();
                    }
                  }
                },
                style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white,
                  backgroundColor: Colors.green,
                ),
                child: Text('Dodaj'),
              ),
            ],
          );
        });
      },
    );
  }

  void _addClassForDay(DateTime date, String time) async {
    List<String> timeParts = time.split(':');
    int hour = int.parse(timeParts[0]);
    int minute = int.parse(timeParts[1]);

    DateTime classDateTime = DateTime(
      date.year,
      date.month,
      date.day,
      hour,
      minute,
    );

    if (_selectedClass != null && _selectedAnnualPlanProgram != null) {
      Map<String, dynamic> requestBody = {
        'NazivCasa': _selectedClass!.nazivCasa,
        'Opis': _selectedClass!.opis,
        'GodisnjiPlanProgramID':
            _selectedAnnualPlanProgram!.godisnjiPlanProgramID,
        'DatumOdrzavanjaCasa': classDateTime.toIso8601String(),
      };

      try {
        await _classesProvider.Update(
            _selectedClass!.casoviID ?? 0, requestBody);
        setState(() {
          if (_groupedClasses[classDateTime] == null) {
            _groupedClasses[classDateTime] = [];
          }

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text("Uspješno ste dodali čas u kalendar."),
              backgroundColor: Colors.green,
            ),
          );

          Classes updatedClass = _selectedClass!;
          updatedClass.datumOdrzavanjaCasa = classDateTime;

          _groupedClasses[classDateTime]?.add(updatedClass);
          print("Class provider Update : ${updatedClass}");

          _selectedDay = classDateTime;
          _fetchClassess();
        });
      } catch (e) {
        print("Failed to update class: $e");
      }
    } else {
      print("No class or program selected to update.");
    }
  }

  Widget _buildCalendar() {
    return TableCalendar(
      firstDay: DateTime.utc(2020, 1, 1),
      lastDay: DateTime.utc(2030, 12, 31),
      focusedDay: _focusedDay,
      selectedDayPredicate: (day) {
        return isSameDay(_selectedDay, day);
      },
      onDaySelected: (selectedDay, focusedDay) {
        setState(() {
          _selectedDay = selectedDay;
          _focusedDay = focusedDay;
        });
      },
      calendarFormat: CalendarFormat.month,
      availableCalendarFormats: const {
        CalendarFormat.month: 'Month',
      },
      eventLoader: _getClassesForDay,
    );
  }

  Widget _buildSelectedClasses() {
    List<Classes> selectedDayClasses = _getClassesForDay(_selectedDay!);

    if (selectedDayClasses.isEmpty) {
      return Text("Nema časova za selektirani dan.");
    }

    return Padding(
      padding: const EdgeInsets.only(left: 16, right: 16),
      child: Column(
        children: selectedDayClasses.map((classItem) {
          String time = classItem.datumOdrzavanjaCasa != null
              ? "${classItem.datumOdrzavanjaCasa!.hour.toString().padLeft(2, '0')}:${classItem.datumOdrzavanjaCasa!.minute.toString().padLeft(2, '0')}"
              : "N/A";

          return Container(
            margin: const EdgeInsets.symmetric(vertical: 8.0),
            decoration: BoxDecoration(
              color: Color(0xFFF7F2FA),
              borderRadius: BorderRadius.circular(10.0),
              boxShadow: [
                BoxShadow(
                  color: Colors.black12,
                  blurRadius: 4.0,
                  offset: Offset(0, 2),
                ),
              ],
            ),
            child: Padding(
              padding: const EdgeInsets.only(left: 16, right: 16),
              child: ListTile(
                contentPadding: const EdgeInsets.all(8.0),
                title: Text(
                  "$time ${classItem.nazivCasa ?? "N/A"}",
                ),
                trailing: Padding(
                  padding: const EdgeInsets.only(left: 8.0, right: 8.0),
                  child: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Tooltip(
                        message: "Prelazak na stranicu za prisustvo",
                        child: IconButton(
                          icon: Icon(Icons.upload_outlined, color: Colors.blue),
                          onPressed: () {
                            _navigateToClassDetails(classItem.casoviID ?? 0);
                          },
                        ),
                      ),
                      Tooltip(
                        message: "Brisanje časa",
                        child: IconButton(
                          icon: Icon(Icons.delete, color: Colors.red),
                          onPressed: () {
                            _confirmDeleteClass(classItem);
                          },
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          );
        }).toList(),
      ),
    );
  }

  void _navigateToClassDetails(int casoviID) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => ClassesHeldDetailScreen(casoviID: casoviID),
      ),
    );
  }

  void _confirmDeleteClass(Classes classItem) async {
    if (classItem.isOdrzan == true) {
      await showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Brisanje nije moguće'),
            content: Text('Ne možete obrisati čas koji je već održan.'),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
                child: Text('U redu'),
              ),
            ],
          );
        },
      );
    } else {
      bool? isConfirmed = await showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Potvrda brisanja'),
            content: Text('Da li ste sigurni da želite obrisati ovaj čas?'),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop(false);
                },
                style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
                child: Text('Ne'),
              ),
              ElevatedButton(
                onPressed: () {
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(
                      content: Text("Uspješno ste obrisali čas iz kalendara."),
                      backgroundColor: Colors.green,
                    ),
                  );
                  Navigator.of(context).pop(true);
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.red,
                  foregroundColor: Colors.white,
                ),
                child: Text('Da'),
              ),
            ],
          );
        },
      );

      if (isConfirmed == true) {
        _deleteClass(classItem);
      }
    }
  }

  void _deleteClass(Classes classItem) async {
    try {
      Map<String, dynamic> requestBody = {
        'NazivCasa': classItem.nazivCasa,
        'Opis': classItem.opis,
        'GodisnjiPlanProgramID': classItem.godisnjiPlanProgramID,
        'DatumOdrzavanjaCasa': null,
      };

      await _classesProvider.Update(classItem.casoviID ?? 0, requestBody);
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text("Uspješno ste izbrisali čas iz kalendara."),
          backgroundColor: Colors.green,
        ),
      );
      setState(() {
        _classes.removeWhere(
            (existingClass) => existingClass.casoviID == classItem.casoviID);

        _groupClassesByDate();

        _fetchClassess();
      });

      print('Class updated successfully');
    } catch (e) {
      print("Failed to update class: $e");
    }
  }

  Widget _buildAddClassesButton() {
    return Align(
      alignment: Alignment.centerRight,
      child: Padding(
        padding: const EdgeInsets.only(right: 16, bottom: 16),
        child: ElevatedButton(
          onPressed: () {
            _showAddClassDialog(context);
          },
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.white,
            backgroundColor: Colors.blue,
          ),
          child: Text("Dodaj časove za kalendar"),
        ),
      ),
    );
  }
}
