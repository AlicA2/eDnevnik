import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
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

  TextEditingController _nazivController = TextEditingController();

  Department? _selectedDepartment;
  Subject? _selectedSubject;

  List<Department> _departments = [];
  List<Subject> _subjects = [];

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _fetchDepartments();
    _fetchSubjects();
    _fetchAnnualPlanPrograms();
  }

  Future<void> _fetchDepartments() async {
    var data = await _departmentProvider.get();
    setState(() {
      _departments = data.result;
    });
  }

  Future<void> _fetchSubjects() async {
    var data = await _subjectProvider.get();
    setState(() {
      _subjects = data.result;
    });
  }

  Future<void> _fetchAnnualPlanPrograms() async {
    var filter = {
      'naziv': _nazivController.text,
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
    return _departments.firstWhere(
      (dept) => dept.odjeljenjeID == id,
      orElse: () => Department(0, '', 0),
    ).nazivOdjeljenja ?? "";
  }

  String _getSubjectName(int? id) {
    return _subjects.firstWhere(
      (sub) => sub.predmetID == id,
      orElse: () => Subject(0, '', '', ""),
    ).naziv ?? "";
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        child: Column(
          children: [
            _buildSearch(),
            _buildDataListView(),
          ],
        ),
      ),
      // tittle: "Godišnji Plan i Program",
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
          ElevatedButton(
            onPressed: _fetchAnnualPlanPrograms,
            child: Text("Pretraga"),
          ),
          ElevatedButton(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => SingleAnnualPlanProgramScreen(
                    planProgram: null,
                  ),
                ),
              );
            },
            child: Text("Dodaj Plan i Program"),
          ),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return Expanded(
      child: SingleChildScrollView(
        child: DataTable(
          columns: const [
            DataColumn(
              label: Expanded(
                child: Text(
                  "ID",
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
          rows: result?.result.map((AnnualPlanProgram e) {
            return DataRow(
              onSelectChanged: (selected) {
                if (selected == true) {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => SingleAnnualPlanProgramScreen(
                        planProgram: e,
                      ),
                    ),
                  );
                }
              },
              cells: [
                DataCell(Text(e.godisnjiPlanProgramID?.toString() ?? "")),
                DataCell(Text(e.naziv ?? "")),
                DataCell(Text(_getDepartmentName(e.odjeljenjeID))),
                DataCell(Text(e.brojCasova?.toString() ?? "")),
                DataCell(Row(
                  children: [
                    IconButton(
                      icon: Icon(Icons.edit),
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => SingleAnnualPlanProgramScreen(
                              planProgram: e,
                            ),
                          ),
                        );
                      },
                    ),
                    IconButton(
                      icon: Icon(Icons.navigate_next),
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => ClassesDetailScreen(
                              annualPlanProgramID: e.godisnjiPlanProgramID,
                            ),
                          ),
                        );
                      },
                    ),
                  ],
                )),
              ],
            );
          }).toList() ?? [],
        ),
      ),
    );
  }
}
