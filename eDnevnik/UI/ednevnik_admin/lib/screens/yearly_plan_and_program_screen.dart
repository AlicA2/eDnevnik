import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school_year.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/classes_screen.dart';
import 'package:ednevnik_admin/screens/single_annual_plan_program_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class YearlyPlanAndProgramDetailScreen extends StatefulWidget {
  const YearlyPlanAndProgramDetailScreen({Key? key}) : super(key: key);

  @override
  _YearlyPlanAndProgramDetailScreenState createState() =>
      _YearlyPlanAndProgramDetailScreenState();
}

class _YearlyPlanAndProgramDetailScreenState
    extends State<YearlyPlanAndProgramDetailScreen> {
  SearchResult<AnnualPlanProgram>? result;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;
  late DepartmentProvider _departmentProvider;
  late SubjectProvider _subjectProvider;
  late SchoolProvider _schoolProvider;
  late UserProvider _userProvider;
  late SchoolYearProvider _schoolYearProvider;

  TextEditingController _nazivController = TextEditingController();

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;
  SchoolYear? _selectedSchoolYear;
  User? loggedInUser;

  List<User> _profesors = [];
  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];
  List<SchoolYear> _schoolYears = [];

  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _userProvider = context.read<UserProvider>();
    _schoolYearProvider = context.read<SchoolYearProvider>();

    _fetchSchools();
    _fetchSchoolYears();
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
            SchoolYear(skolskaGodinaID: -1, naziv: "Sve godine"),
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
    setState(() {
      isLoading = true;
    });
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchDepartments();
            _fetchSubjects();
            _fetchAnnualPlanPrograms();
            _fetchProfesors();
          } else {
            isLoading = false;
          }
        });
      }
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  Future<void> _fetchProfesors() async {
    setState(() {
      isLoading = true;
    });
    try {
      var profesors = await _userProvider.get();
      if (mounted) {
        setState(() {
          _profesors = profesors.result;
          isLoading = false;
        });
      }
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  void _navigateToAddOrEditScreen([AnnualPlanProgram? planProgram]) async {
    final result = await Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) =>
            SingleAnnualPlanProgramScreen(planProgram: planProgram),
      ),
    );

    if (result == true) {
      _fetchAnnualPlanPrograms();
    }
  }

  Future<void> _fetchDepartments() async {
    setState(() {
      isLoading = true;
    });
    try {
      var data = await _departmentProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });
      setState(() {
        _departments = [Department(0, 'Sva odjeljenja', 0, 0), ...data.result];

        if (_departments.isNotEmpty) {
          _selectedDepartment = _departments.first;
        } else {
          isLoading = false;
        }
        isLoading = false;
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  Future<void> _fetchSubjects() async {
    setState(() {
      isLoading = true;
    });
    try {
      var data = await _subjectProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });

      setState(() {
        _subjects = [Subject(0, 'Svi predmeti', '', '', 0), ...data.result];

        if (_subjects.isNotEmpty) {
          _selectedSubject = _subjects.first;
        } else {
          isLoading = false;
        }
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  Future<void> _fetchAnnualPlanPrograms() async {
    setState(() {
      isLoading = true;
    });
    try {
      var filter = {
        'naziv': _nazivController.text,
        'SkolaID': _selectedSchool?.skolaID,
        // 'ProfesorID': loggedInUser?.korisnikId
      };

      if (_selectedDepartment != null &&
          _selectedDepartment!.odjeljenjeID != 0) {
        filter['odjeljenjeID'] = _selectedDepartment!.odjeljenjeID.toString();
      }

      if (_selectedSubject != null && _selectedSubject!.predmetID != 0) {
        filter['predmetID'] = _selectedSubject!.predmetID.toString();
      }

      if (_selectedSchoolYear != null &&
          _selectedSchoolYear!.skolskaGodinaID != -1) {
        filter['SkolskaGodinaID'] =
            _selectedSchoolYear!.skolskaGodinaID.toString();
      }

      var data = await _annualPlanProgramProvider.get(filter: filter);

      setState(() {
        result = data;
        isLoading = false;
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  String _getDepartmentName(int? id) {
    return _departments
            .firstWhere(
              (dept) => dept.odjeljenjeID == id,
              orElse: () => Department(0, '', 0, 0),
            )
            .nazivOdjeljenja ??
        "";
  }

  String _getProfesorsName(int? id) {
    final user = _profesors.firstWhere(
      (prof) => prof.korisnikId == id,
      orElse: () => User(
          null, null, null, null, null, null, null, null, null, null, null),
    );

    return "${user.ime ?? ""} ${user.prezime ?? ""}".trim();
  }

  String _getSubjectName(int? id) {
    return _subjects
            .firstWhere(
              (sub) => sub.predmetID == id,
              orElse: () => Subject(0, '', '', "", 0),
            )
            .naziv ??
        "";
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
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
                Expanded(child: _buildDataListView()),
                _buildAddButton(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenName() {
    return Align(
      alignment: Alignment.centerLeft,
      child: Row(
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
              "Godišnji plan i program",
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
              setState(() {
                _selectedSchool = newValue;
                _selectedDepartment = null;
                _selectedSubject = null;
              });
              _fetchAnnualPlanPrograms();
              _fetchSubjects();
              _fetchDepartments();
            },
          ),
        ),
      ],
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Row(
        children: [
          Expanded(
            child: DropdownButton<Department>(
              hint: Text("Odjeljenje"),
              value: _selectedDepartment,
              onChanged: (Department? newValue) {
                setState(() {
                  _selectedDepartment = newValue;
                });
              },
              items: _departments.map((Department department) {
                return DropdownMenuItem<Department>(
                  value: department,
                  child: Text(department.nazivOdjeljenja ?? ""),
                );
              }).toList(),
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: DropdownButton<Subject>(
              hint: Text("Predmet"),
              value: _selectedSubject,
              onChanged: (Subject? newValue) {
                setState(() {
                  _selectedSubject = newValue;
                });
              },
              items: _subjects.map((Subject subject) {
                return DropdownMenuItem<Subject>(
                  value: subject,
                  child: Text(subject.naziv ?? ""),
                );
              }).toList(),
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: DropdownButton<SchoolYear>(
  value: _selectedSchoolYear,
  onChanged: (SchoolYear? newValue) {
    setState(() {
      _selectedSchoolYear = newValue;
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
          SizedBox(width: 10),
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            onPressed: () async {
              await _fetchAnnualPlanPrograms();
            },
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    if (isLoading) {
      return Center(
        child: CircularProgressIndicator(),
      );
    }
    return result == null || result!.result.isEmpty
        ? Center(
            child: Text(
              "Nema podataka za prikazati.",
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
          )
        : SingleChildScrollView(
            child: DataTable(
              columns: const [
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "Naziv godišnjeg plana i programa",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "Odjeljenje",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "Predmet",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "Profesor",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "Broj Časova",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      "",
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
              ],
              rows: result?.result.asMap().entries.map((entry) {
                    int index = entry.key + 1;
                    AnnualPlanProgram e = entry.value;
                    return DataRow(
                      cells: [
                        DataCell(Text(e.naziv ?? "")),
                        DataCell(Center(
                            child: Text(_getDepartmentName(e.odjeljenjeID)))),
                        DataCell(Text(_getSubjectName(e.predmetID))),
                        DataCell(Text(_getProfesorsName(e.profesorID))),
                        DataCell(Center(
                            child: Text(e.brojCasova?.toString() ?? ""))),
                        DataCell(Row(
                          children: [
                            Tooltip(
                              message: "Prelazak na stranicu časova",
                              child: ElevatedButton(
                                onPressed: () async {
                                  Navigator.of(context).push(
                                    MaterialPageRoute(
                                      builder: (context) => ClassesDetailScreen(
                                        annualPlanProgramID:
                                            e.godisnjiPlanProgramID,
                                        predmetID: e.predmetID,
                                      ),
                                    ),
                                  );
                                },
                                style: ElevatedButton.styleFrom(
                                    foregroundColor: Colors.white,
                                    backgroundColor: Colors.blue),
                                child: Text("Časovi"),
                              ),
                            ),
                            Padding(
                              padding: const EdgeInsets.only(left: 16.0),
                              child: Tooltip(
                                message:
                                    "Uređivanje godišnjeg plana i programa",
                                child: IconButton(
                                  icon: Icon(Icons.edit),
                                  onPressed: () {
                                    _navigateToAddOrEditScreen(e);
                                  },
                                ),
                              ),
                            ),
                          ],
                        )),
                      ],
                    );
                  }).toList() ??
                  [],
            ),
          );
  }

  Widget _buildAddButton() {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.blue,
        ),
        onPressed: () {
          _navigateToAddOrEditScreen();
        },
        child: Text("Dodaj novi plan i program"),
      ),
    );
  }
}
