import 'package:fl_chart/fl_chart.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
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

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;

  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];
  List<Grade> _grades = [];
  Map<int, User> _users = {};

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _gradeProvider = context.read<GradeProvider>();
    _userProvider = context.read<UserProvider>();

    _fetchSchools();
  }

  Future<void> _fetchGrades() async {
    try {
      var grades = await _gradeProvider.get(filter: {
        'DepartmentID': _selectedDepartment?.odjeljenjeID,
        'SubjectID': _selectedSubject?.predmetID,
        'SchoolID': _selectedSchool?.skolaID,
      });
      setState(() {
        _grades = grades.result;
      });

      await _fetchUsers();
    } catch (e) {
    }
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
            _selectedSchool = _schools.first;
            _fetchDepartments();
            _fetchSubjects();
          }
        });
      }
    } catch (e) {}
  }

  Future<void> _fetchDepartments() async {
    var data = await _departmentProvider.get(filter: {
      'SkolaID': _selectedSchool?.skolaID,
    });
    setState(() {
      _departments = data.result;
    });
  }

  Future<void> _fetchSubjects() async {
    var data = await _subjectProvider.get(filter: {
      'SkolaID': _selectedSchool?.skolaID,
    });
    setState(() {
      _subjects = data.result;
    });
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
                _fetchSubjects();
                _fetchDepartments();
              },
            ),
          ),
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
                getTitlesWidget: (value, meta) => Text(value.toInt().toString()),
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
