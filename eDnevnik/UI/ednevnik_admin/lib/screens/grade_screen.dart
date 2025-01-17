import 'dart:convert';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/classes_students_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/final_grade_provider.dart';
import 'package:ednevnik_admin/screens/grade_edit_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:ednevnik_admin/models/result.dart';

class GradeDetailScreen extends StatefulWidget {
  final int? userID;

  const GradeDetailScreen({Key? key, required this.userID}) : super(key: key);

  @override
  State<GradeDetailScreen> createState() => _GradeDetailScreenState();
}

class _GradeDetailScreenState extends State<GradeDetailScreen> {
  List<Grade> _grades = [];
  Map<int, Subject?> _subjects = {};
  List<Subject> _availableSubjects = [];
  Subject? _selectedSubject;
  bool _isLoading = true;
  String _userFullName = '';
  List<int> _casoviIDs = [];
  List<Classes> _fetchedClasses = [];

  late UserProvider _userProvider;
  late GradeProvider _gradesProvider;
  late SubjectProvider _subjectProvider;
  late DepartmentProvider _departmentProvider;
  late DepartmentSubjectProvider _departmentSubjectProvider;
  late ClassesProvider _classesProvider;
  late ClassesStudentsProvider _classesStudentsProvider;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;
  late FinalGradeProvider _finalGradeProvider;

  @override
  void initState() {
    super.initState();
    _gradesProvider = context.read<GradeProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _classesProvider = context.read<ClassesProvider>();
    _classesStudentsProvider = context.read<ClassesStudentsProvider>();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _finalGradeProvider = context.read<FinalGradeProvider>();

    _fetchClassesStudents();
    _initializeData();
  }

  Future<void> _initializeData() async {
    if (mounted) {
      setState(() {
        _isLoading = true;
      });
    }
    try {
      SearchResult<Department> departmentResult =
          await _departmentProvider.get(filter: {'isUceniciIncluded': true});

      int? odjeljenjeID;
      bool userFound = false;

      for (var department in departmentResult.result) {
        if (department.ucenici != null) {
          for (var user in department.ucenici!) {
            if (user.korisnikId == widget.userID) {
              odjeljenjeID = department.odjeljenjeID;
              userFound = true;
              break;
            }
          }
          if (userFound) break;
        }
      }

      if (odjeljenjeID != null) {
        await _fetchSubjectDepartment(odjeljenjeID);
      } else {
        print("User with ID ${widget.userID} not found in any department.");
      }

      var data = await _gradesProvider.get(filter: {
        'KorisnikID': widget.userID,
      });

      if (mounted) {
        setState(() {
          _grades = data.result;
          _isLoading = false;
        });
        await _fetchSubjects();
      }

      var userDetails = await _userProvider.getById(widget.userID ?? 0);
      if (mounted) {
        setState(() {
          _userFullName = "${userDetails.ime} ${userDetails.prezime}";
        });
      }

      _resetSelectedSubject();
    } catch (e) {
      if (mounted) {
        setState(() {
          _isLoading = false;
        });
      }
      print("Error initializing data: $e");
    }
  }

  Future<void> _fetchSubjectDepartment(int departmentID) async {
    try {
      SearchResult<Subject> allSubjectsResult =
          await _subjectProvider.get(filter: {});

      SearchResult<DepartmentSubject> departmentSubjectsResult =
          await _departmentSubjectProvider.get(filter: {
        'OdjeljenjeID': departmentID,
      });

      List<DepartmentSubject> departmentSubjects =
          departmentSubjectsResult.result;
      List<Subject> filteredSubjects = [];

      for (var departmentSubject in departmentSubjects) {
        if (departmentSubject.predmetID != null) {
          var subject = allSubjectsResult.result.firstWhere(
            (s) => s.predmetID == departmentSubject.predmetID,
            orElse: () => Subject(0, '', '', '', 0, null),
          );
          if (subject != null) {
            filteredSubjects.add(subject);
          }
        }
      }

      if (mounted) {
        setState(() {
          _availableSubjects = filteredSubjects;
          _selectedSubject = null;
        });
      }
    } catch (e) {
      print("Error fetching subjects: $e");
    }
  }

  Future<void> _fetchClasses() async {
    try {
      if (_casoviIDs.isNotEmpty) {
        List<Classes> allClasses = [];

        for (int casoviID in _casoviIDs) {
          var classesResult = await _classesProvider.get(filter: {
            'CasoviID': casoviID,
            'IsOdrzan': true,
          });

          allClasses.addAll(classesResult.result);
        }

        if (mounted) {
          setState(() {
            _fetchedClasses = allClasses;
          });
        }
      }
    } catch (e) {
      print("Error fetching Classes: $e");
    }
  }

  Future<void> _fetchClassesStudents() async {
    try {
      var classesStudentsResult = await _classesStudentsProvider.get(filter: {
        'IsPrisutan': true,
        'zakljucan': true,
        'UcenikID': widget.userID
      });

      if (mounted) {
        setState(() {
          _casoviIDs = classesStudentsResult.result
              .map<int>((classStudent) => classStudent.casoviID!)
              .toList();
        });
        await _fetchClasses();
      }
    } catch (e) {
      print("Error fetching classes students: $e");
    }
  }

  Future<void> _fetchSubjects() async {
    for (var grade in _grades) {
      if (grade.predmetID != null) {
        try {
          var subjectResult = await _subjectProvider.get(filter: {
            'PredmetID': grade.predmetID!,
            'isOcjeneIncluded': true,
          });

          Subject? subject = subjectResult.result.isNotEmpty
              ? subjectResult.result.first
              : null;

          if (mounted) {
            setState(() {
              _subjects[grade.predmetID!] = subject;
            });
          }
        } catch (e) {
          print("Error fetching subject for predmetID ${grade.predmetID}: $e");
        }
      }
    }
  }

  void _resetSelectedSubject() {
    setState(() {
      _selectedSubject = null;
    });
  }

  void _filterGradesBySubject(Subject? subject) {
    if (mounted) {
      setState(() {
        _selectedSubject = subject;
      });
    }
  }

  String _getGradeValues(Subject? subject) {
    if (subject?.ocjene == null || subject!.ocjene!.isEmpty) {
      return "N/A";
    }

    var filteredOcjene = subject.ocjene!
        .where((ocjena) => ocjena.korisnikID == widget.userID)
        .map((grade) => grade.vrijednostOcjene.toString());

    return filteredOcjene.isNotEmpty ? filteredOcjene.join(", ") : "N/A";
  }

  Future<int?> _fetchAnnualPlanProgram(int? predmetID) async {
    if (predmetID == null) return null;
    try {
      var annualPlanProgramResult = await _annualPlanProgramProvider
          .get(filter: {"PredmetID": predmetID});
      if (annualPlanProgramResult != null &&
          annualPlanProgramResult.result.isNotEmpty) {
        var annualPlanProgram = annualPlanProgramResult.result.first;
        return annualPlanProgram.godisnjiPlanProgramID;
      } else {
        print('No annual plan program found for Predmet ID $predmetID');
        return null;
      }
    } catch (e) {
      print("Error fetching annual plan program: $e");
      return null;
    }
  }

  Future<void> _fetchClassesForAnnualPlan(int godisnjiPlanProgramID,
      StateSetter setState, int? korisnikID, int? predmetID) async {
    try {
      var classesResult = await _classesProvider
          .get(filter: {"GodisnjiPlanProgramID": godisnjiPlanProgramID});

      if (classesResult != null && classesResult.result.isNotEmpty) {
        var gradesResult = await _gradesProvider.get(
          filter: {
            "KorisnikID": korisnikID,
            "PredmetID": predmetID,
          },
        );

        List<DateTime?> gradeDates = [];
        if (gradesResult != null && gradesResult.result.isNotEmpty) {
          gradeDates = gradesResult.result
              .map((grade) => DateTime(
                  grade.datum!.year, grade.datum!.month, grade.datum!.day))
              .toList();
        }

        List<DateTime?> fetchedClassDates = classesResult.result
            .where((c) => c.isOdrzan ?? false)
            .map((c) => DateTime(c.datumOdrzavanjaCasa!.year,
                c.datumOdrzavanjaCasa!.month, c.datumOdrzavanjaCasa!.day))
            .toList();

        List<DateTime?> allowedDates = fetchedClassDates
            .where((classDate) => !gradeDates.contains(classDate))
            .toList();

        if (allowedDates.isNotEmpty) {
          await _pickDate(context, allowedDates, setState);
        } else {
          _showNoClassesDialog(context);
        }
      } else {
        _showNoClassesDialog(context);
      }
    } catch (e) {
      print("Error fetching classes: $e");
    }
  }

  DateTime? selectedDate;

  Future<void> _addGradeDialog(BuildContext context) async {
    final _formKey = GlobalKey<FormBuilderState>();
    String? komentar;

    Subject? selectedSubject =
        _availableSubjects.isNotEmpty ? _availableSubjects.first : null;
    int selectedGradeValue = 1;

    List<DateTime?> allowedDates = _fetchedClasses
        .where((c) => c.isOdrzan ?? false)
        .map((c) => c.datumOdrzavanjaCasa)
        .toList();

    return showDialog<void>(
      context: context,
      barrierDismissible: false,
      builder: (BuildContext context) {
        return StatefulBuilder(
          builder: (BuildContext context, StateSetter setState) {
            void resetFields() {
              selectedSubject = _availableSubjects.isNotEmpty
                  ? _availableSubjects.first
                  : null;
              selectedGradeValue = 1;
              selectedDate = null;
              _formKey.currentState?.reset();
            }

            return AlertDialog(
              title: Text('Dodaj ocjenu za učenika'),
              content: SingleChildScrollView(
                child: FormBuilder(
                  key: _formKey,
                  child: ListBody(
                    children: <Widget>[
                      FormBuilderTextField(
                        name: 'studentName',
                        initialValue: _userFullName,
                        enabled: false,
                        decoration: InputDecoration(
                          labelText: 'Učenik',
                        ),
                      ),
                      SizedBox(height: 16),
                      FormBuilderDropdown<Subject?>(
                        name: 'subject',
                        initialValue: selectedSubject,
                        items: _availableSubjects.map((subject) {
                          return DropdownMenuItem<Subject?>(
                            value: subject,
                            child: Text(subject?.naziv ?? ""),
                          );
                        }).toList(),
                        validator: FormBuilderValidators.required(
                            errorText: 'Polje je obavezno'),
                        onChanged: (Subject? newValue) {
                          setState(() {
                            selectedSubject = newValue;
                          });
                        },
                        decoration: InputDecoration(
                          labelText: 'Predmet',
                        ),
                      ),
                      SizedBox(height: 16),
                      FormBuilderDropdown<int>(
                        name: 'gradeValue',
                        initialValue: selectedGradeValue,
                        items: [1, 2, 3, 4, 5].map((int value) {
                          return DropdownMenuItem<int>(
                            value: value,
                            child: Text(value.toString()),
                          );
                        }).toList(),
                        validator: FormBuilderValidators.required(
                            errorText: 'Polje je obavezno'),
                        onChanged: (int? newValue) {
                          setState(() {
                            selectedGradeValue = newValue!;
                          });
                        },
                        decoration: InputDecoration(
                          labelText: 'Ocjena',
                        ),
                      ),
                      SizedBox(height: 16),
                      FormBuilderTextField(
                        name: 'komentar',
                        maxLines: 3,
                        decoration: InputDecoration(
                          labelText: 'Komentar',
                          hintText: 'Unesite komentar',
                        ),
                        onChanged: (value) {
                          komentar = value;
                        },
                        validator: _validateKomentar,
                      ),
                      SizedBox(height: 16),
                      Text(
                        "Datum: ${selectedDate != null ? selectedDate!.toLocal().toString().split(' ')[0] : "N/A"}",
                        style: TextStyle(
                            color: selectedDate == null
                                ? Colors.red
                                : Colors.black),
                      ),
                      SizedBox(height: 8),
                      ElevatedButton(
                        onPressed: () async {
                          if (selectedSubject != null) {
                            int? godisnjiPlanProgramID =
                                await _fetchAnnualPlanProgram(
                                    selectedSubject!.predmetID);
                            if (godisnjiPlanProgramID != null) {
                              await _fetchClassesForAnnualPlan(
                                  godisnjiPlanProgramID,
                                  setState,
                                  widget?.userID,
                                  selectedSubject!.predmetID);
                            } else {
                              print(
                                  "No annual plan program found for selected subject.");
                              _showNoClassesDialog(context);
                            }
                          } else {
                            print("No subject selected.");
                          }
                        },
                        style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.black,
                            backgroundColor: Colors.white),
                        child: Text('Dodaj datum'),
                      ),
                    ],
                  ),
                ),
              ),
              actions: <Widget>[
                TextButton(
                  style: ElevatedButton.styleFrom(
                      foregroundColor: Colors.black,
                      backgroundColor: Colors.white),
                  child: Text('Odustani'),
                  onPressed: () {
                    resetFields();
                    Navigator.of(context).pop();
                  },
                ),
                TextButton(
                  style: ElevatedButton.styleFrom(
                      foregroundColor: Colors.white,
                      backgroundColor: Colors.green),
                  child: Text('Dodaj'),
                  onPressed: () async {
                    if (_formKey.currentState?.saveAndValidate() ?? false) {
                      if (selectedDate == null) {
                        _showNoDateSelectedDialog(context);
                      } else if (selectedSubject != null) {
                        Grade newGrade = Grade(
                          null,
                          selectedGradeValue,
                          selectedDate!,
                          widget.userID,
                          selectedSubject!.predmetID,
                          komentar,
                        );

                        try {
                          bool success = await _subjectProvider.addOcjena(
                              selectedSubject!.predmetID ?? 0, newGrade);
                          if (success) {
                            await _fetchFinalGrade(
                                widget.userID!, selectedSubject!.predmetID!);
                            _initializeData();
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                content: Text(
                                    "Uspješno ste dodali novu ocjenu učeniku."),
                                backgroundColor: Colors.green,
                              ),
                            );
                            Navigator.of(context).pop();
                            resetFields();
                          }
                        } catch (e) {
                          print("Error adding grade: $e");
                        }
                      } else {
                        print("No subject selected. Grade cannot be added.");
                      }
                    } else {
                      print("Validation failed");
                    }
                  },
                ),
              ],
            );
          },
        );
      },
    ).then((_) => _resetSelectedSubject());
  }

  void _showNoDateSelectedDialog(BuildContext context) {
    showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Greška'),
          content: Text('Morate odabrati datum prije dodavanja ocjene!'),
          actions: <Widget>[
            TextButton(
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
              child: Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  bool _containsNumbers(String input) {
    return input.contains(RegExp(r'[0-9]'));
  }

  String? _validateKomentar(String? value) {
    if (value == null || value.isEmpty) {
      return 'Komentar je obavezan i ne može biti prazan.';
    }

    if (_containsNumbers(value)) {
      return 'Komentar ne može sadržavati brojeve.';
    }

    if (!RegExp(r'^[A-ZŽĐŠĆČ]').hasMatch(value)) {
      return 'Komentar mora početi velikim slovom.';
    }

    if (value.length < 4) {
      return 'Komentar mora imati minimum 4 slova.';
    }

    final sentences = value.split('. ');
    for (var i = 0; i < sentences.length; i++) {
      var sentence = sentences[i].trim();

      if (sentence.isNotEmpty && !RegExp(r'^[A-ZŽĐŠĆČ]').hasMatch(sentence)) {
        return 'Svaka rečenica mora početi velikim slovom.';
      }

      if (i == sentences.length - 1 && !sentence.endsWith('.')) {
        return 'Komentar mora završiti sa tačkom.';
      }

      if (i < sentences.length - 1 && sentence.endsWith('.')) {
        return 'Samo zadnja rečenica može završavati sa tačkom.';
      }
    }

    return null;
  }

  void _showNoClassesDialog(BuildContext context) {
    showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Greška'),
          content:
              Text('Nemate održanih časova da možete unjeti ocjenu učeniku!'),
          actions: <Widget>[
            TextButton(
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
              child: Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  Future<void> _pickDate(BuildContext context, List<DateTime?> allowedDates,
      StateSetter setState) async {
    DateTime? initialDate = selectedDate;
    if (!allowedDates.contains(initialDate)) {
      initialDate = allowedDates.isNotEmpty ? allowedDates.first : null;
    }

    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: initialDate ?? DateTime.now(),
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
      selectableDayPredicate: (DateTime date) {
        return allowedDates.any((allowedDate) =>
            allowedDate?.year == date.year &&
            allowedDate?.month == date.month &&
            allowedDate?.day == date.day);
      },
    );

    if (picked != null && picked != selectedDate) {
      setState(() {
        selectedDate = picked;
      });
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
                Expanded(
                  child: _isLoading ? _buildLoading() : _buildDataListView(),
                ),
                SizedBox(height: 16.0),
                _buildActionButtons(),
                SizedBox(
                  height: 16,
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildActionButtons() {
    return Row(mainAxisAlignment: MainAxisAlignment.end, children: [
      SizedBox(
        width: 16,
      ),
      ElevatedButton(
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.blue,
        ),
        onPressed: () {
          Navigator.pop(context);
        },
        child: Text('Odustani'),
      ),
      Spacer(),
      ElevatedButton(
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.blue,
        ),
        onPressed: () {
          _addGradeDialog(context);
        },
        child: Text('Dodaj ocjenu'),
      ),
      SizedBox(
        width: 16,
      )
    ]);
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
            "Ocjene za $_userFullName",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 16.0),
        Expanded(
          child: _buildSubjectDropdown(),
        )
      ],
    );
  }

  Widget _buildSubjectDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 200,
          child: DropdownButton<Subject?>(
            hint: Text("Filtriraj po predmetu"),
            value: _selectedSubject,
            items: [null, ..._availableSubjects].map((subject) {
              return DropdownMenuItem<Subject?>(
                value: subject,
                child: Text(subject?.naziv ?? "Svi Predmeti"),
              );
            }).toList(),
            onChanged: (Subject? newValue) {
              if (mounted) {
                setState(() {
                  _selectedSubject = newValue;
                });
              }
              _filterGradesBySubject(newValue);
            },
          ),
        ),
      ],
    );
  }

  Widget _buildLoading() {
    return Center(
      child: CircularProgressIndicator(),
    );
  }

  Widget _buildDataListView() {
    final Map<int, List<Grade>> gradesBySubject = {};
    for (var grade in _grades) {
      if (gradesBySubject.containsKey(grade.predmetID)) {
        gradesBySubject[grade.predmetID!]!.add(grade);
      } else {
        gradesBySubject[grade.predmetID!] = [grade];
      }
    }

    List<DataRow> dataRows = [];
    for (var entry in gradesBySubject.entries) {
      int predmetID = entry.key;
      List<Grade> grades = entry.value;

      if (_selectedSubject == null ||
          _selectedSubject!.predmetID == predmetID) {
        Subject? subject = _subjects[predmetID];

        dataRows.add(
          DataRow(
            cells: [
              DataCell(Text(subject?.naziv ?? "N/A")),
              DataCell(Center(
                child: FutureBuilder<String?>(
                  future: _fetchFinalGrade(widget.userID ?? 0, predmetID),
                  builder: (context, snapshot) {
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return Text('Loading...');
                    } else if (snapshot.hasError) {
                      return Text('Error');
                    } else {
                      return Text(snapshot.data ?? "N/A");
                    }
                  },
                ),
              )),
              DataCell(Center(child: Text(_getGradeValues(subject)))),
              DataCell(
                Tooltip(
                  message: "Uređivanje ocjene",
                  child: Center(
                    child: IconButton(
                      icon: Icon(Icons.edit),
                      onPressed: () {
                        _showEditGradeDialog(context, grades);
                      },
                    ),
                  ),
                ),
              ),
              DataCell(
                Tooltip(
                  message: "Informacije o ocjenama",
                  child: IconButton(
                    icon: Icon(Icons.info_outline),
                    onPressed: () {
                      _showGradeDetailsDialog(context, subject, grades);
                    },
                  ),
                ),
              ),
            ],
          ),
        );
      }
    }

    return SingleChildScrollView(
      child: DataTable(
        columns: const [
          DataColumn(
            label: Expanded(
              child: Text(
                "Naziv Predmeta",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Zaključna Ocjena",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Sve Ocjene",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Uredi ocjene",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Center(
                child: Text(
                  "Info",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
          ),
        ],
        rows: dataRows,
      ),
    );
  }

  Future<String?> _fetchFinalGrade(int korisnikID, int predmetID) async {
    try {
      var finalGradeResult = await _finalGradeProvider.get(filter: {
        'KorisnikID': korisnikID,
        'PredmetID': predmetID,
      });

      if (finalGradeResult != null && finalGradeResult.result.isNotEmpty) {
        var finalGrade = finalGradeResult.result.first;
        return finalGrade.vrijednostZakljucneOcjene?.toString();
      } else {
        print(
            'No final grade found for KorisnikID: $korisnikID and PredmetID: $predmetID');
        return null;
      }
    } catch (e) {
      print("Error fetching final grade: $e");
      return null;
    }
  }

  void _showEditGradeDialog(BuildContext context, List<Grade> grades) async {
    bool? dataChanged = await Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => EditGradesScreen(grades: grades),
      ),
    );

    if (dataChanged == true) {
      _initializeData();
    }
  }

  void _showGradeDetailsDialog(
      BuildContext context, Subject? subject, List<Grade> grades) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text(subject?.naziv ?? "Detalji Ocjena"),
          content: SingleChildScrollView(
            child: ListBody(
              children: grades.map((grade) {
                String datum =
                    grade.datum?.toLocal().toString().split(' ')[0] ?? "N/A";
                String vrijednostOcjene = grade.vrijednostOcjene.toString();
                String komentar = grade.komentar ?? "N/A";
                return ListTile(
                  title: Row(
                    children: [
                      Text(
                        "Datum: ",
                        style: TextStyle(
                            fontWeight: FontWeight.bold),
                      ),
                      Text(datum),
                    ],
                  ),
                  subtitle: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      SizedBox(height: 4),
                      Row(
                        children: [
                          Text(
                            "Ocjena: ",
                            style: TextStyle(
                                fontWeight:
                                    FontWeight.bold),
                          ),
                          Text(vrijednostOcjene),
                        ],
                      ),
                      SizedBox(height: 4),
                      Row(
                        children: [
                          Text(
                            "Komentar: ",
                            style: TextStyle(
                                fontWeight:
                                    FontWeight.bold),
                          ),
                          Text(komentar),
                        ],
                      ),
                    ],
                  ),
                );
              }).toList(),
            ),
          ),
          actions: <Widget>[
            TextButton(
              style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
              child: Text('Zatvori'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
