import 'dart:async';
import 'dart:io';
import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/models/final_grade.dart';
import 'package:ednevnik_admin/providers/final_grade_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pdf/pdf.dart';
import 'package:pdf/widgets.dart' as pw;
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
  late FinalGradeProvider _finalGradeProvider;

  Department? _selectedDepartment;
  DepartmentSubject? _selectedSubject;
  School? _selectedSchool;
  User? _selectedUser;
  bool _isLoading = false;
  Map<int, User> _users = {};

  List<FinalGrade> _finalGrades = [];
  List<Department> _departments = [];
  List<DepartmentSubject> _subjects = [];
  List<School> _schools = [];
  List<Grade> _grades = [];
  Map<int, String> _subjectNames = {};

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
    _schoolProvider = context.read<SchoolProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _gradeProvider = context.read<GradeProvider>();
    _userProvider = context.read<UserProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _finalGradeProvider = context.read<FinalGradeProvider>();

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

  Future<void> _fetchFinalGrades(int predmetID, int korisnikID) async {
    try {
      var finalGrades = await _finalGradeProvider.get(filter: {
        'PredmetID': predmetID,
        'KorisnikID': korisnikID,
      });

      if (finalGrades.result.isNotEmpty) {
        setState(() {
          _finalGrades = finalGrades.result;
        });
      }
    } catch (e) {
      print("Error fetching final grades: $e");
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
        _selectedSubject = _subjects.isNotEmpty ? _subjects.first : null;
      });

      if (_selectedSubject != null) {
        await _fetchGrades();
      }
    } catch (e) {
      print("Error fetching department subjects: $e");
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
                    _isLoading
                        ? Center(child: CircularProgressIndicator())
                        : _buildContent(),
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
            onPressed: _generatePDFReport,
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
                  await _fetchGrades();
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
                  _selectedUser = null;
                });
                await _fetchDepartmentSubjects();
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
          SizedBox(width: 40),
          Expanded(
            child: DropdownButton<DepartmentSubject>(
              hint: Text("Izaberite predmet"),
              value: _selectedSubject,
              onChanged: (DepartmentSubject? newValue) async {
                setState(() {
                  _selectedSubject = newValue;
                  _selectedUser = null;
                });
                await _fetchGrades();
              },
              items: _subjects.map((DepartmentSubject departmentSubject) {
                return DropdownMenuItem<DepartmentSubject>(
                  value: departmentSubject,
                  child:
                      Text(_subjectNames[departmentSubject.predmetID] ?? "N/A"),
                );
              }).toList(),
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

  Future<double> _calculateZakljucnaOcjena(
      int korisnikID, int predmetID) async {
    var finalGrades = await _finalGradeProvider.get(filter: {
      'PredmetID': predmetID,
      'KorisnikID': korisnikID,
    });

    if (finalGrades.result.isEmpty) return 0.0;

    double sum = finalGrades.result.fold(
        0.0,
        (prev, element) =>
            prev + (element.vrijednostZakljucneOcjene?.toDouble() ?? 0.0));
    double average = sum / finalGrades.result.length;

    return average;
  }

  Widget _buildUserDetails() {
    List<User> filteredUsers =
        _selectedUser == null ? _users.values.toList() : [_selectedUser!];

    if (filteredUsers.isEmpty || _selectedSubject == null) {
      return Center(
        child: Text(
          "Nema zaključnih ocjena za pregled.",
          style: TextStyle(fontSize: 16, color: Colors.black),
          textAlign: TextAlign.center,
        ),
      );
    }

    return FutureBuilder<List<double>>(
      future: Future.wait(
        filteredUsers.map((user) => _calculateZakljucnaOcjena(
            user.korisnikId!, _selectedSubject!.predmetID!)),
      ),
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: CircularProgressIndicator());
        } else if (snapshot.hasError || snapshot.data == null) {
          return Center(child: Text('Error: ${snapshot.error}'));
        } else {
          final grades = snapshot.data!;
          final usersWithGrades = [
            for (int i = 0; i < filteredUsers.length; i++)
              if (grades[i] > 0.0) MapEntry(filteredUsers[i], grades[i])
          ];

          if (usersWithGrades.isEmpty) {
            return Center(
              child: Text(
                "Kako nema ocjena za učenike, tako nema i zaključnih ocjena.",
                style: TextStyle(fontSize: 16, color: Colors.grey),
                textAlign: TextAlign.center,
              ),
            );
          }

          return ListView(
            shrinkWrap: true,
            children: usersWithGrades.map((entry) {
              final user = entry.key;
              final finalGrade = entry.value;
              return Card(
                child: ListTile(
                  title: Text('${user.ime} ${user.prezime}'),
                  subtitle: Text(
                      'Zaključna ocjena: ${finalGrade.toStringAsFixed(2)}'),
                ),
              );
            }).toList(),
          );
        }
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
            showingTooltipIndicators: [],
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

  Future<String> _fetchSubjectName(int predmetID) async {
    try {
      final subject = await _subjectProvider.getById(predmetID);
      return subject.naziv ?? "N/A";
    } catch (e) {
      print("Error fetching subject name: $e");
      return "N/A";
    }
  }

  void _generatePDFReport() async {
    final pdf = pw.Document();
    final dateFormat = DateFormat('dd.MM.yyyy');
    final now = DateTime.now();
    final timestamp = DateFormat('yyyyMMdd_HHmmss').format(now);

    final schoolName = replaceSpecialChars(_selectedSchool?.naziv ?? "N/A");
    final departmentName =
        replaceSpecialChars(_selectedDepartment?.nazivOdjeljenja ?? "N/A");
    final subjectName = _selectedSubject != null
        ? await _fetchSubjectName(_selectedSubject!.predmetID!)
        : "N/A";

    pdf.addPage(
      pw.Page(
        build: (pw.Context context) {
          return pw.Center(
            child: pw.Column(
              mainAxisSize: pw.MainAxisSize.min,
              crossAxisAlignment: pw.CrossAxisAlignment.center,
              children: [
                pw.Text(
                  replaceSpecialChars('Izvještaj o ocjenama'),
                  style: pw.TextStyle(
                    fontSize: 24,
                    fontWeight: pw.FontWeight.bold,
                    color: PdfColors.blue800,
                  ),
                ),
                pw.SizedBox(height: 20),
                pw.Text(
                  'kola: $schoolName',
                  style: pw.TextStyle(fontSize: 16, color: PdfColors.black),
                ),
                pw.Text(
                  'Odjeljenje: $departmentName',
                  style: pw.TextStyle(fontSize: 16, color: PdfColors.black),
                ),
                pw.Text(
                  'Predmet: $subjectName',
                  style: pw.TextStyle(fontSize: 16, color: PdfColors.black),
                ),
                pw.SizedBox(height: 10),
                pw.Text(
                  'Izvjestaj generisan na datum: ${dateFormat.format(now)}',
                  style: pw.TextStyle(
                    fontSize: 16,
                    fontWeight: pw.FontWeight.bold,
                    color: PdfColors.grey900,
                  ),
                ),
              ],
            ),
          );
        },
      ),
    );

    pdf.addPage(
      pw.Page(
        build: (pw.Context context) {
          return pw.Column(
            crossAxisAlignment: pw.CrossAxisAlignment.start,
            children: [
              pw.Text(
                replaceSpecialChars('Ocjene učenika'),
                style: pw.TextStyle(
                  fontSize: 18,
                  fontWeight: pw.FontWeight.bold,
                  color: PdfColors.black,
                ),
              ),
              pw.SizedBox(height: 10),
              pw.Table.fromTextArray(
                headers: [
                  replaceSpecialChars('Učenik'),
                  replaceSpecialChars('Datum'),
                  replaceSpecialChars('Ocjena')
                ],
                data: _grades.map((grade) {
                  final user = _users[grade.korisnikID];
                  final userName =
                      '${replaceSpecialChars(user?.ime ?? '')} ${replaceSpecialChars(user?.prezime ?? '')}';
                  final gradeDate =
                      dateFormat.format(grade.datum ?? DateTime.now());
                  final gradeValue = grade.vrijednostOcjene?.toString() ?? '';

                  return [userName, gradeDate, gradeValue];
                }).toList(),
                border: pw.TableBorder.all(),
                cellStyle: pw.TextStyle(fontSize: 12),
                headerStyle: pw.TextStyle(
                  fontSize: 14,
                  fontWeight: pw.FontWeight.bold,
                  color: PdfColors.blue900,
                ),
                headerDecoration: pw.BoxDecoration(
                  color: PdfColors.grey300,
                ),
              ),
            ],
          );
        },
      ),
    );

    final result = await FilePicker.platform.saveFile(
      dialogTitle: 'Odaberite mjesto za spremanje PDF-a',
      fileName: 'izvještaj_$timestamp.pdf',
    );

    if (result != null) {
      final outputFile = File(result);
      await outputFile.writeAsBytes(await pdf.save());
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('PDF je uspješno spremljen: ${outputFile.path}'),
          backgroundColor: Colors.green,
        ),
      );
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Spremanje PDF-a nije uspjelo.'),
          backgroundColor: Colors.green,
        ),
      );
    }
  }

  String replaceSpecialChars(String input) {
    return input
        .replaceAll('š', 's')
        .replaceAll('č', 'c')
        .replaceAll('ć', 'c')
        .replaceAll('đ', 'd')
        .replaceAll('ž', 'z')
        .replaceAll('Đ', 'D')
        .replaceAll('Ć', 'C')
        .replaceAll('Č', 'C')
        .replaceAll('Š', 'S')
        .replaceAll('Ž', 'Z');
  }
}
