import 'dart:async';

import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
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
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

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

  Timer? _debounce;

  void _onDropdownChanged(VoidCallback fetchFunction) {
    if (_debounce?.isActive ?? false) _debounce!.cancel();
    _debounce = Timer(const Duration(milliseconds: 300), () {
      fetchFunction();
    });
  }

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
    setState(() {
      _isLoading = true;
    });
    try {
      await _fetchSchools();
    } catch (e) {
      print(e);
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _fetchGrades() async {
    setState(() {
      _isLoading = true;
    });
    try {
      if (_selectedSubject != null) {
        var grades = await _gradeProvider.get(filter: {
          'PredmetID': _selectedSubject!.predmetID,
          'KorisnikID': _selectedUser?.korisnikId,
        });
        setState(() {
          _grades = grades.result;
        });

        await _fetchUsers();
      }
    } catch (e) {
      print(e);
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _fetchUsers() async {
    setState(() {
      _isLoading = true;
    });
    try {
      if (_selectedUser == null) {
        Map<int, User> fetchedUsers = {};
        for (Grade grade in _grades) {
          if (grade.korisnikID != null &&
              !_users.containsKey(grade.korisnikID!)) {
            User user = await _userProvider.getById(grade.korisnikID!);
            fetchedUsers[grade.korisnikID!] = user;
          }
        }
        setState(() {
          _users.addAll(fetchedUsers);
        });
      }
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
          await Future.wait([
            _fetchDepartmentSubjects(),
            _fetchDepartments(),
            _fetchSubjects(),
            _fetchGrades(),
          ]);
        }
      }
    } catch (e) {
      print(e);
    }
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
    } catch (e) {
      print(e);
    }
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
        await _fetchSubjects();
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
        _selectedSubject = _subjects.isNotEmpty ? _subjects.first : null;
        _selectedUser = null;
      });

      if (_selectedSubject != null) {
        await _fetchGrades();
      }
    } catch (e) {
      print(e);
    }
  }

  Future<double> _calculateZakljucnaOcjena(
      int korisnikID, int predmetID) async {
    var grades = await _gradeProvider.get(filter: {
      'PredmetID': predmetID,
      'KorisnikID': korisnikID,
    });

    if (grades.result.isEmpty) return 0.0;

    double sum = grades.result.fold(
        0.0,
        (prev, element) =>
            prev + (element.vrijednostOcjene?.toDouble() ?? 0.0));
    double average = sum / grades.result.length;

    return average;
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
                    : _buildContent(),
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
                _onDropdownChanged(() async {
                  await _fetchDepartmentSubjects();
                  await _fetchDepartments();
                  await _fetchSubjects();
                  await _fetchGrades();
                });
              },
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: DropdownButton<Department>(
              hint: Text("Izaberite odjeljenje"),
              value: _selectedDepartment,
              onChanged: (Department? newValue) async {
                setState(() {
                  _selectedDepartment = newValue;
                  _selectedUser = null;
                });
                await _fetchSubjects();
                await _fetchGrades();
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
              onChanged: (Subject? newValue) async {
                setState(() {
                  _selectedSubject = newValue;
                  _selectedUser = null;
                });
                await _fetchGrades();
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
              onChanged: (User? newValue) async {
                setState(() {
                  _selectedUser = newValue;
                  _isLoading = true;
                });
                await _fetchGrades();
                setState(() {
                  _isLoading = false;
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
        ],
      ),
    );
  }

  Widget _buildContent() {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Expanded(
          flex: 2,
          child: _buildChart(),
        ),
        SizedBox(width: 20),
        Expanded(
          flex: 1,
          child: _buildUserDetails(),
        ),
      ],
    );
  }

  Widget _buildUserDetails() {
    List<User> filteredUsers =
        _selectedUser == null ? _users.values.toList() : [_selectedUser!];

    return ListView.builder(
      shrinkWrap: true,
      itemCount: filteredUsers.length,
      itemBuilder: (context, index) {
        final user = filteredUsers[index];

        return FutureBuilder<double>(
          future: _calculateZakljucnaOcjena(
              user.korisnikId!, _selectedSubject!.predmetID!),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return CircularProgressIndicator();
            } else if (snapshot.hasError) {
              return Text('Error: ${snapshot.error}');
            } else {
              final finalGrade = snapshot.data ?? 0.0;
              return Card(
                child: ListTile(
                  title: Text('${user.ime} ${user.prezime}'),
                  subtitle: Text(
                      'Zaključna ocjena: ${finalGrade.toStringAsFixed(2)}'),
                ),
              );
            }
          },
        );
      },
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
    if (_grades.isEmpty || _users.isEmpty) {
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

    return groupedGrades.entries
        .map((entry) {
          int userId = entry.key;
          List<Grade> grades = entry.value;

          List<BarChartRodData> barRods = [];

          for (int i = 0; i < grades.length; i++) {
            var grade = grades[i];
            double gradeValue =
                (grade.vrijednostOcjene?.toDouble() ?? 0.0).clamp(1.0, 5.0);

            barRods.add(BarChartRodData(
              toY: gradeValue,
              color: Colors.blue,
              width: 20.0,
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
        })
        .whereType<BarChartGroupData>()
        .toList();
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
