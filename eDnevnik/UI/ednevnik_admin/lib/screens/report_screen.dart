import 'package:fl_chart/fl_chart.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:flutter/material.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:provider/provider.dart';

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

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;
  User? _selectedUser;
  bool _isLoading = false;

  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];
  List<Grade> _grades = [];
  Map<int, User> _users = {};
  List<DepartmentSubject> _departmentSubjects = [];
  List<int> _filteredOdjeljenjeIDs = [];
  List<int> _filteredPredmetIDs = [];

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _gradeProvider = context.read<GradeProvider>();
    _userProvider = context.read<UserProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();

    _initializeData();
  }

  Future<void> _initializeData() async {
    await _fetchSchools();
    if (_selectedSchool != null) {
      await _fetchDepartmentSubjects();
      await _fetchDepartments();
      await _fetchSubjects();
      await _fetchGrades();
    }
  }

  Future<void> _fetchGrades() async {
    setState(() {
      _isLoading=true;
    });
    try {
      var grades = await _gradeProvider.get(filter: {
        'PredmetID': _selectedSubject?.predmetID,
        'KorisnikID': _selectedUser?.korisnikId,
      });
      setState(() {
        _grades = grades.result;
      });

      await _fetchUsers();
    } catch (e) {
      print(e);
    } finally {
      setState(() {
        _isLoading=false;
      });
    }
  }

  Future<void> _fetchUsers() async {
  setState(() {
    _isLoading = true;
  });
  if (_selectedUser == null) {
    int count = 0;
    Map<int, User> fetchedUsers = {};
    for (Grade grade in _grades) {
      if (grade.korisnikID != null && !_users.containsKey(grade.korisnikID!)) {
        try {
          User user = await _userProvider.getById(grade.korisnikID!);
          count++;
          fetchedUsers[grade.korisnikID!] = user;
          print('Fetched User: ${user.ime} ${user.prezime}');
          print('User Count: $count');
          print('User ID: ${grade.korisnikID}');
          print('-----------------------------------------------------------------');
        } catch (e) {
          print('Error fetching user with ID ${grade.korisnikID}: $e');
        }
      }
    }
    setState(() {
      _users = fetchedUsers;
    });
  } else {
  }
  setState(() {
    _isLoading = false;
  });
}

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          _selectedSchool = _schools.isNotEmpty ? schools.result.first : null;
          if (_schools.isNotEmpty) {
            _fetchDepartmentSubjects();
            _fetchDepartments();
          }
        });
      }
    } catch (e) {}
  }

  Future<void> _fetchDepartmentSubjects() async {
    try {
      var data = await _departmentSubjectProvider.get();
      setState(() {
        _departmentSubjects = data.result;
        _filteredOdjeljenjeIDs = _departmentSubjects
            .map((ds) => ds.odjeljenjeID ?? 0)
            .toSet()
            .toList();
        _filteredPredmetIDs =
            _departmentSubjects.map((ds) => ds.predmetID ?? 0).toSet().toList();
      });
    } catch (e) {}
  }

  Future<void> _fetchDepartments() async {
    try {
      var data = await _departmentProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
        'isUceniciIncluded': true,
      });

      List<Department> filteredDepartments = data.result.where((department) {
        return _filteredOdjeljenjeIDs.contains(department.odjeljenjeID);
      }).toList();

      setState(() {
        _departments = filteredDepartments;
        _selectedDepartment =
            filteredDepartments.isNotEmpty ? filteredDepartments.first : null;
        _selectedUser = null;
      });

      if (_selectedDepartment != null) {
        _fetchSubjects();
      }
    } catch (e) {
      print(e);
    }
  }

  Future<void> _fetchSubjects() async {
    try {
      var data = await _subjectProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });

      List<Subject> filteredSubjects = data.result.where((subject) {
        return _filteredPredmetIDs.contains(subject.predmetID);
      }).toList();

      setState(() {
        _subjects = filteredSubjects;
        _selectedSubject = _subjects.first;
      });
    } catch (e) {
      print(e);
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
              _buildScreenName(),
              SizedBox(height: 16.0),
              _buildSearch(),
              SizedBox(height: 20),
              _isLoading
                  ? Center(child: CircularProgressIndicator())
                  : _buildChart(),
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
    );
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
                  _selectedDepartment = null;
                  _selectedSubject = null;
                  _selectedUser = null;
                });
                _fetchDepartmentSubjects().then((_) => _fetchDepartments());
              },
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: DropdownButton<Department>(
              hint: Text("Izaberite odjeljenje"),
              value: _selectedDepartment,
              onChanged: (Department? newValue) {
                setState(() {
                  _selectedDepartment = newValue;
                  _selectedUser = null;
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
              hint: Text("Izaberite predmet"),
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
            child: DropdownButton<User>(
              hint: Text("Izaberite učenika"),
              value: _selectedUser,
              onChanged: (User? newValue) {
                setState(() {
                  _selectedUser = newValue;
                });
                if (newValue == null) {
                  _fetchUsers().then((_) {
                    setState(() {
                      _buildBarGroups();
                    });
                  });
                } else {
                  print('Selected User: ${newValue.ime}');
                }
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
          SizedBox(width: 10),
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            onPressed: () async {
              await _fetchGrades();
              setState(() {
                _buildBarGroups();
              });
            },
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildChart() {
    try {
      if (_subjects.isEmpty) {
        return Center(child: Text("Nema dostupnih ocjena na pregled"));
      }

      return Container(
        height: 300,
        padding: EdgeInsets.all(16.0),
        child: BarChart(
          BarChartData(
            alignment: BarChartAlignment.spaceAround,
            minY: 1,
            maxY: 5,
            barGroups: _buildBarGroups(),
            borderData: FlBorderData(show: false),
            titlesData: FlTitlesData(
              bottomTitles: AxisTitles(
                sideTitles: SideTitles(
                  showTitles: true,
                  getTitlesWidget: (value, meta) =>
                      _buildBottomTitles(value, meta),
                ),
              ),
              leftTitles: AxisTitles(
                sideTitles: SideTitles(
                  showTitles: true,
                  interval: 1,
                  getTitlesWidget: (value, meta) {
                    return Text(
                      value.toInt().toString(),
                      style: TextStyle(
                        color: Colors.black,
                        fontSize: 12,
                      ),
                    );
                  },
                ),
              ),
            ),
          ),
        ),
      );
    } catch (e) {
      print('Error in _buildChart: $e');
      return Center(
          child: Text("Došlo je do greške prilikom učitavanja podataka"));
    }
  }

  List<BarChartGroupData> _buildBarGroups() {
  if (_grades == null || _grades.isEmpty || _users.isEmpty) {
    return [];
  }

  Map<int, List<Grade>> groupedGrades = {};
  for (var grade in _grades) {
    if (groupedGrades.containsKey(grade.korisnikID)) {
      groupedGrades[grade.korisnikID!]!.add(grade);
    } else {
      groupedGrades[grade.korisnikID!] = [grade];
    }
  }

  Map<int, String> userNames = {};
  for (var user in _users.values) {
    userNames[user.korisnikId!] = '${user.ime ?? ''} ${user.prezime ?? ''}';
  }

  return groupedGrades.entries.map((entry) {
    int userId = entry.key;
    List<Grade> grades = entry.value;

    List<BarChartRodData> barRods = [];
    double barWidth = 20.0;
    double barSpacing = 4.0;

    for (int i = 0; i < grades.length; i++) {
      var grade = grades[i];
      double gradeValue = (grade.vrijednostOcjene?.toDouble() ?? 0.0).clamp(1.0, 5.0);

      barRods.add(BarChartRodData(
        toY: gradeValue,
        color: Colors.blue,
        width: barWidth,
        borderSide: BorderSide(
          color: Colors.blue,
        ),
      ));
    }

    if (barRods.isEmpty) {
      return null;
    }

    return BarChartGroupData(
      x: userId,
      barRods: barRods,
      showingTooltipIndicators: [0],
    );
  }).whereType<BarChartGroupData>().toList();
}

Widget _buildBottomTitles(double value, TitleMeta meta) {
  final userId = value.toInt();
  final userName = _users[userId]?.ime ?? 'N/A';

  return SideTitleWidget(
    axisSide: meta.axisSide,
    child: Container(
      height: 40,
      alignment: Alignment.center,
      child: Text(
        userName,
        style: TextStyle(
          fontSize: 12,
          color: Colors.black,
        ),
        textAlign: TextAlign.center,
      ),
    ),
  );
}

}
