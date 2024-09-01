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

    _fetchSchools();
  }

  Future<void> _fetchGrades() async {
    try {
      var grades = await _gradeProvider.get(filter: {
        'PredmetID': _selectedSubject?.predmetID,
      });
      setState(() {
        _grades = grades.result;
      });

      await _fetchUsers();
    } catch (e) {}
  }

  Future<void> _fetchUsers() async {
    for (Grade grade in _grades) {
      if (grade.korisnikID != null && !_users.containsKey(grade.korisnikID!)) {
        User user = await _userProvider.getById(grade.korisnikID!);
        setState(() {
          _users[grade.korisnikID!] = user;
        });
      }
    }
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
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
        print(_filteredOdjeljenjeIDs);
      });
    } catch (e) {}
  }

  Future<void> _fetchDepartments() async {
    try {
      var data = await _departmentProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });

      List<Department> filteredDepartments = data.result.where((department) {
        return _filteredOdjeljenjeIDs.contains(department.odjeljenjeID);
      }).toList();

      setState(() {
        _departments = filteredDepartments;
      });
      _fetchSubjects();
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

      print(filteredSubjects);

      setState(() {
        _subjects = filteredSubjects;
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
                _buildChart(),
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
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            onPressed: () async {
              await _fetchGrades();
            },
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildChart() {
    if (_grades.isEmpty) {
      return Center(child: Text("No grades available"));
    }

    return Container(
      height: 300,
      padding: EdgeInsets.all(16.0),
      child: BarChart(
        BarChartData(
          alignment: BarChartAlignment.spaceAround,
          barGroups: _buildBarGroups(),
          borderData: FlBorderData(show: false),
          titlesData: FlTitlesData(
            bottomTitles: AxisTitles(
              sideTitles: SideTitles(
                showTitles: true,
                getTitlesWidget: (value, meta) => _buildBottomTitles(value),
              ),
            ),
            leftTitles: AxisTitles(
              sideTitles: SideTitles(
                showTitles: true,
                getTitlesWidget: (value, meta) =>
                    Text(value.toInt().toString()),
              ),
            ),
          ),
        ),
      ),
    );
  }

  List<BarChartGroupData> _buildBarGroups() {
    return _grades.asMap().entries.map((entry) {
      int index = entry.key;
      Grade grade = entry.value;
      return BarChartGroupData(
        x: index,
        barRods: [
          BarChartRodData(
            toY: grade.vrijednostOcjene?.toDouble() ?? 0.0,
            rodStackItems: [
              BarChartRodStackItem(
                0,
                grade.vrijednostOcjene?.toDouble() ?? 0.0,
                Colors.blue,
              ),
            ],
            borderSide: BorderSide(
              color: Colors.blue,
            ),
          ),
        ],
      );
    }).toList();
  }

  Widget _buildBottomTitles(double value) {
    final index = value.toInt();
    if (index < 0 || index >= _grades.length) return const Text('');
    final user = _users[_grades[index].korisnikID];
    return Text(user?.ime ?? 'N/A');
  }
}
