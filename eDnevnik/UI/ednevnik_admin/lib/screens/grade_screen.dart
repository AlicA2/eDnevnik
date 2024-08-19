import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/department.dart';
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

  late UserProvider _userProvider;
  late GradeProvider _gradesProvider;
  late SubjectProvider _subjectProvider;
  late DepartmentProvider _departmentProvider;

  @override
  void initState() {
    super.initState();
    _gradesProvider = context.read<GradeProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _initializeData();
  }

  Future<void> _initializeData() async {
    setState(() {
      _isLoading = true;
    });

    try {
      SearchResult<Department> departmentResult =
          await _departmentProvider.get(filter: {'KorisnikID': widget.userID});
      Department department = departmentResult.result.first;
      int? skolaID = department.skolaID;

      SearchResult<Subject> subjectsResult =
          await _subjectProvider.get(filter: {'SkolaID': skolaID});
      _availableSubjects = subjectsResult.result;

      // Set the first subject as the selected subject
      if (_availableSubjects.isNotEmpty) {
        _selectedSubject = _availableSubjects.first;
      }

      var data = await _gradesProvider.get(filter: {
        'KorisnikID': widget.userID,
      });

      setState(() {
        _grades = data.result;
        _isLoading = false;
      });

      var userDetails = await _userProvider.getById(widget.userID ?? 0);
      setState(() {
        _userFullName = "${userDetails.ime} ${userDetails.prezime}";
      });
      await _fetchSubjects();
    } catch (e) {
      setState(() {
        _isLoading = false;
      });
      print("Error initializing data: $e");
    }
  }

  Future<void> _fetchSubjects() async {
    for (var grade in _grades) {
      if (grade.predmetID != null) {
        try {
          var subject = await _subjectProvider.getById(grade.predmetID!);
          setState(() {
            _subjects[grade.predmetID!] = subject;
          });
        } catch (e) {
          print("Error fetching subject for predmetID ${grade.predmetID}: $e");
        }
      }
    }
  }

  void _filterGradesBySubject(Subject? subject) {
    setState(() {
      _selectedSubject = subject;
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
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                Expanded(
                  child: _isLoading ? _buildLoading() : _buildDataListView(),
                ),
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
            "Ocjene za $_userFullName",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 16.0), // Use width instead of height for spacing
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
          child: DropdownButton<Subject>(
            hint: Text("Filter by Subject"),
            value: _selectedSubject,
            items: _availableSubjects.map((subject) {
              return DropdownMenuItem<Subject>(
                value: subject,
                child: Text(subject.naziv ?? "Unknown"),
              );
            }).toList(),
            onChanged: (Subject? newValue) {
              setState(() {
                _selectedSubject = newValue;
              });
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
    List<Grade> filteredGrades = _selectedSubject == null
        ? _grades
        : _grades
            .where((grade) => grade.predmetID == _selectedSubject?.predmetID)
            .toList();

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
                "Vrijednost Ocjene",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Datum",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
        ],
        rows: filteredGrades.map((grade) {
          var subject = _subjects[grade.predmetID];
          return DataRow(
            cells: [
              DataCell(Text(subject?.naziv ?? "N/A")),
              DataCell(Text(grade.vrijednostOcjene?.toString() ?? "N/A")),
              DataCell(Text(
                  grade.datum?.toLocal().toString().split(' ')[0] ?? "N/A")),
            ],
          );
        }).toList(),
      ),
    );
  }
}
