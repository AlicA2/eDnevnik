import 'dart:async';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/models/final_grade.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/classes_students_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/final_grade_provider.dart';

class ReportDetailScreen extends StatefulWidget {
  const ReportDetailScreen({Key? key}) : super(key: key);

  @override
  State<ReportDetailScreen> createState() => _ReportDetailScreenState();
}

class _ReportDetailScreenState extends State<ReportDetailScreen> {
  late DepartmentProvider _departmentProvider;
  late SubjectProvider _subjectProvider;
  late SchoolProvider _schoolProvider;
  late GradeProvider _gradeProvider;
  late UserProvider _userProvider;
  late DepartmentSubjectProvider _departmentSubjectProvider;
  late FinalGradeProvider _finalGradeProvider;
  late ClassesProvider _classesProvider;
  late ClassesStudentsProvider _classesStudentsProvider;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;

  List<School> _schools = [];
  List<Department> _departments = [];
  List<DepartmentSubject> _subjects = [];
  Map<int, String> _subjectNames = {};

  School? _selectedSchool;
  Department? _selectedDepartment;
  DepartmentSubject? _selectedSubject;
  User? _selectedUser;

  List<Map<String, dynamic>> userGrades = [];

  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _gradeProvider = context.read<GradeProvider>();
    _userProvider = context.read<UserProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _finalGradeProvider = context.read<FinalGradeProvider>();
    _classesProvider = context.read<ClassesProvider>();
    _classesStudentsProvider = context.read<ClassesStudentsProvider>();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();

    _initializeData();
  }

  Future<void> _initializeData() async {
    setState(() {
      _isLoading = true;
    });

    try {
      await _fetchSchools();
      await fetchFinalGrades();
    } catch (e) {
      print(e);
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          _selectedSchool = _schools.isNotEmpty ? _schools.first : null;
        });

        if (_selectedSchool != null) {
          await _fetchDepartments();
        }
      }
    } catch (e) {
      print(e);
    }
  }

  Future<void> _fetchDepartments() async {
    if (_selectedSchool == null) return;
    try {
      var data = await _departmentProvider.get(filter: {
        'SkolaID': _selectedSchool!.skolaID,
        'isUceniciIncluded': true,
      });

      setState(() {
        _departments = data.result;
        _selectedDepartment =
            _departments.isNotEmpty ? _departments.first : null;
      });

      if (_selectedDepartment != null) {
        await _fetchDepartmentSubjects();
      }
    } catch (e) {
      print(e);
    }
  }

  Future<void> _fetchDepartmentSubjects() async {
    if (_selectedDepartment == null) return;
    try {
      var data = await _departmentSubjectProvider.get(
        filter: {'OdjeljenjeID': _selectedDepartment!.odjeljenjeID},
      );

      final List<DepartmentSubject> departmentSubjects = data.result;
      final subjectNames = <int, String>{};

      for (var departmentSubject in departmentSubjects) {
        try {
          final subject =
              await _subjectProvider.getById(departmentSubject.predmetID!);
          if (subject != null && subject.naziv != null) {
            subjectNames[departmentSubject.predmetID!] = subject.naziv!;
          } else {
            subjectNames[departmentSubject.predmetID!] = "N/A";
          }
        } catch (e) {
          subjectNames[departmentSubject.predmetID!] = "N/A";
        }
      }

      setState(() {
        _subjects = departmentSubjects;
        _subjectNames = subjectNames;
        _selectedSubject = null;
      });

      if (_selectedSubject != null) {}
    } catch (e) {
      print("Error fetching department subjects: $e");
    }
  }

  Future<void> fetchFinalGrades() async {
    try {
      List<int?> korisnikIDs = [];
      if (_selectedUser == null) {
        korisnikIDs = _selectedDepartment?.ucenici
                ?.map((user) => user.korisnikId)
                .toList() ??
            [];
      } else {
        korisnikIDs = [_selectedUser!.korisnikId];
      }

      List<Map<String, dynamic>> fetchedGrades = [];

      if (_selectedSubject == null) {
        for (var korisnikID in korisnikIDs) {
          var data = await _finalGradeProvider.get(filter: {
            'KorisnikID': korisnikID,
          });

          final user = _selectedDepartment?.ucenici
              ?.firstWhere((u) => u.korisnikId == korisnikID);
          final userName =
              "${user?.ime ?? 'Unknown'} ${user?.prezime ?? 'Unknown'}";

          for (var grade in data.result) {
            final subjectName =
                _subjectNames[grade.predmetID] ?? "Unknown Subject";
            fetchedGrades.add({
              "userName": userName,
              "predmet": subjectName,
              "vrijednostZakljucneOcjene":
                  grade.vrijednostZakljucneOcjene ?? 0.0,
              "korisnikID": korisnikID,
              "predmetID": grade.predmetID,
            });
          }
        }
      } else if (_selectedUser != null && _selectedSubject != null) {
        var data = await _finalGradeProvider.get(filter: {
          'KorisnikID': _selectedUser!.korisnikId,
          'PredmetID': _selectedSubject!.predmetID,
        });

        final userName =
            "${_selectedUser!.ime ?? 'Unknown'} ${_selectedUser!.prezime ?? 'Unknown'}";
        final subjectName =
            _subjectNames[_selectedSubject!.predmetID] ?? "Unknown Subject";

        for (var grade in data.result) {
          fetchedGrades.add({
            "userName": userName,
            "predmet": subjectName,
            "vrijednostZakljucneOcjene": grade.vrijednostZakljucneOcjene ?? 0.0,
            "korisnikID": _selectedUser!.korisnikId,
            "predmetID": grade.predmetID,
          });
        }
      } else {
        for (var korisnikID in korisnikIDs) {
          var data = await _finalGradeProvider.get(filter: {
            'KorisnikID': korisnikID,
            'PredmetID': _selectedSubject!.predmetID,
          });

          final user = _selectedDepartment?.ucenici
              ?.firstWhere((u) => u.korisnikId == korisnikID);
          final userName =
              "${user?.ime ?? 'Unknown'} ${user?.prezime ?? 'Unknown'}";

          for (var grade in data.result) {
            final subjectName =
                _subjectNames[grade.predmetID] ?? "Unknown Subject";
            fetchedGrades.add({
              "userName": userName,
              "predmet": subjectName,
              "vrijednostZakljucneOcjene":
                  grade.vrijednostZakljucneOcjene ?? 0.0,
              "korisnikID": korisnikID,
              "predmetID": grade.predmetID,
            });
          }
        }
      }

      setState(() {
        userGrades = fetchedGrades;
      });
    } catch (e) {
      print("Error fetching final grades: $e");
    }
  }

  Future<double> _fetchAttendance(int? korisnikID, int? predmetID) async {
    if (korisnikID == null || predmetID == null) {
      return 0.0;
    }

    try {
      final annualPlanResponse = await _annualPlanProgramProvider.get(filter: {
        'PredmetID': predmetID,
      });

      if (annualPlanResponse.result == null ||
          annualPlanResponse.result.isEmpty) {
        return 0.0;
      }

      final annualPlanProgram = annualPlanResponse.result.first;
      final godisnjiPlanProgramID = annualPlanProgram.godisnjiPlanProgramID;

      final classesResponse = await _classesProvider.get(filter: {
        'GodisnjiPlanProgramID': godisnjiPlanProgramID,
      });

      if (classesResponse.result == null || classesResponse.result.isEmpty) {
        return 0.0;
      }

      final classes = classesResponse.result
          .where((classItem) => classItem.isOdrzan == true)
          .toList();
      final totalClasses = classes.length;

      if (totalClasses == 0) {
        return 0.0;
      }

      int attendedClasses = 0;

      for (var classItem in classes) {
        final attendanceResponse = await _classesStudentsProvider.get(filter: {
          'CasoviID': classItem.casoviID,
          'UcenikID': korisnikID,
        });

        if (attendanceResponse.result != null) {
          bool isPresent = attendanceResponse.result
              .any((student) => student.isPrisutan == true);
          if (isPresent) {
            attendedClasses++;
          }
        }
      }

      final attendancePercentage = (attendedClasses / totalClasses) * 100;
      return attendancePercentage;
    } catch (e) {
      return 0.0;
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        width: double.infinity,
        height: double.infinity,
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: SingleChildScrollView(
            child: ConstrainedBox(
              constraints: BoxConstraints(
                minHeight: MediaQuery.of(context).size.height,
              ),
              child: Container(
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(20.0),
                ),
                child: Column(
                  children: [
                    _buildScreenName(),
                    SizedBox(height: 16.0),
                    _buildSearch(),
                    SizedBox(height: 20),
                    SingleChildScrollView(
                        child: _isLoading
                            ? Center(
                                child: CircularProgressIndicator(),
                              )
                            : _buildDataTable())
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildDataTable() {
    if (userGrades.isEmpty) {
      return const Center(
          child: Text(
              "Trenutno nema podataka, pritisnite dugme 'Pretraga' ukoliko već niste to uradili."));
    }

    List<DataRow> rows = userGrades.map((grade) {
      final korisnikID = grade["korisnikID"] as int?;
      final predmetID = grade["predmetID"] as int?;

      return DataRow(
        cells: [
          DataCell(Text(grade["userName"] ?? "Unknown User")),
          DataCell(Text(grade["predmet"] ?? "Unknown Subject")),
          DataCell(Text(grade["vrijednostZakljucneOcjene"].toString())),
          DataCell(
            FutureBuilder<double>(
              future: _fetchAttendance(korisnikID, predmetID),
              builder: (context, snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const CircularProgressIndicator();
                }
                if (snapshot.hasError) {
                  return const Text("Error");
                }

                final attendance = snapshot.data ?? 0.0;
                return Text("${attendance.toStringAsFixed(1)}%");
              },
            ),
          ),
          DataCell(
            IconButton(
              icon: const Icon(Icons.comment, color: Colors.blue),
              onPressed: () {
                _showCommentsDialog(korisnikID);
              },
            ),
          ),
        ],
      );
    }).toList();

    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: DataTable(
        columns: const [
          DataColumn(
            label: Text(
              "Ime i prezime",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          DataColumn(
            label: Text(
              "Predmet",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          DataColumn(
            label: Text(
              "Zaključna ocjena",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          DataColumn(
            label: Text(
              "Prisustvo",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          DataColumn(
            label: Text(
              "Komentari",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
        ],
        rows: rows,
      ),
    );
  }

  Future<void> _showCommentsDialog(int? korisnikID) async {
    if (korisnikID == null) {
      return;
    }

    try {
      final data = await _gradeProvider.get(filter: {'KorisnikID': korisnikID});
      final comments = data.result;

      showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            title: const Text("Komentari"),
            content: SizedBox(
              width: double.minPositive,
              child: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: comments.map<Widget>((comment) {
                    String formattedDate = comment.datum != null
                        ? DateFormat('dd/MM/yyyy').format(comment.datum!)
                        : 'N/A';

                    return Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Row(
                            children: [
                              const Text(
                                "Datum: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text(formattedDate),
                            ],
                          ),
                          Row(
                            children: [
                              const Text(
                                "Ocjena: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text("${comment.vrijednostOcjene ?? 'N/A'}"),
                            ],
                          ),
                          Row(
                            children: [
                              const Text(
                                "Komentar: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Expanded(
                                child: Text(comment.komentar ?? 'N/A'),
                              ),
                            ],
                          ),
                        ],
                      ),
                    );
                  }).toList(),
                ),
              ),
            ),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.white,
                    foregroundColor: Colors.black),
                child: const Text("Zatvori"),
              ),
            ],
          );
        },
      );
    } catch (e) {
      print("Error fetching comments: $e");
    }
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Row(
        children: [
          Expanded(
            child: DropdownButton<School>(
              hint: Text("Izaberite školu"),
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
                  _fetchDepartments();
                });
              },
            ),
          ),
          SizedBox(width: 40),
          Expanded(
            child: DropdownButton<Department>(
              hint: Text("Izaberite odjeljenje"),
              value: _selectedDepartment,
              onChanged: (Department? newValue) async {
                setState(() {
                  _selectedDepartment = newValue;
                });
                await _fetchDepartmentSubjects();
              },
              items: _departments.map((Department department) {
                return DropdownMenuItem<Department>(
                  value: department,
                  child: Text(department.nazivOdjeljenja ?? ""),
                );
              }).toList(),
            ),
          ),
          SizedBox(width: 40),
          Expanded(
            child: DropdownButton<DepartmentSubject>(
              hint: Text("Izaberite predmet"),
              value: _selectedSubject,
              onChanged: (DepartmentSubject? newValue) {
                setState(() {
                  _selectedSubject = newValue;
                });
              },
              items: [
                DropdownMenuItem<DepartmentSubject>(
                  value: null,
                  child: Text("Svi predmeti"),
                ),
                ..._subjects.map((DepartmentSubject departmentSubject) {
                  return DropdownMenuItem<DepartmentSubject>(
                    value: departmentSubject,
                    child: Text(
                      _subjectNames[departmentSubject.predmetID] ?? "N/A",
                    ),
                  );
                }).toList(),
              ],
            ),
          ),
          SizedBox(width: 40),
          Expanded(
            child: DropdownButton<User>(
              hint: Text("Izaberite učenika"),
              value: _selectedUser,
              onChanged: (User? newValue) async {
                setState(() {
                  _selectedUser = newValue;
                });
              },
              items: [
                DropdownMenuItem<User>(
                  value: null,
                  child: Text("Svi učenici"),
                ),
                ...?_selectedDepartment?.ucenici?.map((User user) {
                  return DropdownMenuItem<User>(
                    value: user,
                    child: Text('${user.ime ?? ''} ${user.prezime ?? ''}'),
                  );
                }).toList(),
              ],
            ),
          ),
          SizedBox(
            width: 40,
          ),
          Center(
            child: ElevatedButton(
              onPressed: () async {
                await fetchFinalGrades();
              },
              style: ElevatedButton.styleFrom(
                padding:
                    const EdgeInsets.symmetric(horizontal: 20, vertical: 15),
                backgroundColor: Colors.blue,
                foregroundColor: Colors.white,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10.0),
                ),
              ),
              child: const Text(
                "Pretraga",
                style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildScreenName() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Align(
          alignment: Alignment.centerLeft,
          child: Container(
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.only(
                bottomLeft: const Radius.circular(5),
                topLeft: const Radius.circular(20),
                topRight: const Radius.elliptical(5, 5),
                bottomRight: const Radius.circular(30.0),
              ),
            ),
            padding: const EdgeInsets.all(16.0),
            child: const Text(
              "Izvještaj",
              style: TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(right: 16.0),
          child: ElevatedButton.icon(
            onPressed: () => print("PDF"),
            icon: Icon(Icons.print),
            label: Text("Printaj izvještaj"),
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(20.0),
              ),
              padding:
                  const EdgeInsets.symmetric(horizontal: 16.0, vertical: 12.0),
            ),
          ),
        ),
      ],
    );
  }
}

void _showErrorDialog(BuildContext context, String title, String message) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return AlertDialog(
        title: Text(title),
        content: Text(message),
        actions: [
          TextButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            child: Text("OK"),
            style: ElevatedButton.styleFrom(
                foregroundColor: Colors.black, backgroundColor: Colors.white),
          ),
        ],
      );
    },
  );
}
