import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
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

  TextEditingController _nazivController = TextEditingController();

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;

  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];

  @override
  void initState() {
    super.initState();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();

    _fetchSchools();
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
            _fetchAnnualPlanPrograms();
          }
        });
      }
    } catch (e) {}
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

  Future<void> _fetchAnnualPlanPrograms() async {
    var filter = {
      'naziv': _nazivController.text,
      'SkolaID': _selectedSchool?.skolaID,
    };
    if (_selectedDepartment != null) {
      filter['odjeljenjeID'] = _selectedDepartment!.odjeljenjeID.toString();
    }
    if (_selectedSubject != null) {
      filter['predmetID'] = _selectedSubject!.predmetID.toString();
    }

    var data = await _annualPlanProgramProvider.get(filter: filter);

    setState(() {
      result = data;
    });
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
          width: 300,
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
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            onPressed: () async { await _fetchAnnualPlanPrograms;},
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: DataTable(
        columns: const [
          DataColumn(
            label: Expanded(
              child: Text(
                "Redni broj",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Naziv",
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
                  DataCell(Text(index.toString())),
                  DataCell(Text(e.naziv ?? "")),
                  DataCell(Text(_getDepartmentName(e.odjeljenjeID))),
                  DataCell(Text(_getSubjectName(e.predmetID))),
                  DataCell(Text(e.brojCasova?.toString() ?? "")),
                  DataCell(Row(
                    children: [
                      IconButton(
                        icon: Icon(Icons.edit),
                        onPressed: () {
                          _navigateToAddOrEditScreen(e);
                        },
                      ),
                      IconButton(
                        icon: Icon(Icons.navigate_next),
                        onPressed: () async {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => ClassesDetailScreen(
                                annualPlanProgramID: e.godisnjiPlanProgramID,
                                predmetID: e.predmetID,
                              ),
                            ),
                          );
                        },
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
