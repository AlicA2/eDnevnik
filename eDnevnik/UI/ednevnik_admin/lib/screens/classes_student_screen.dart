import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/classes_students.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/classes_students_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ClassesHeldDetailScreen extends StatefulWidget {
  final int? casoviID;
  const ClassesHeldDetailScreen({super.key, required this.casoviID});

  @override
  State<ClassesHeldDetailScreen> createState() =>
      _ClassesHeldDetailScreenState();
}

class _ClassesHeldDetailScreenState extends State<ClassesHeldDetailScreen> {
  late ClassesProvider _classesProvider;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;
  late DepartmentProvider _departmentProvider;
  late ClassesStudentsProvider _classesStudentsProvider;

  Classes? _fetchedClass;
  bool _isLoading = true;
  bool? _isOdrzan;
  Department? _fetchedDepartment;
  List<ClassesStudents>? _classesStudentsList;
  bool _allPresent = false;
  bool _isSubmitted = false;

  @override
  void initState() {
    super.initState();
    _classesProvider = context.read<ClassesProvider>();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _classesStudentsProvider = context.read<ClassesStudentsProvider>();

    _fetchClasses();
  }

  Future<void> _fetchClasses() async {
    try {
      var classesResponse = await _classesProvider.get(filter: {
        'CasoviID': widget.casoviID,
      });

      if (classesResponse != null && classesResponse.result.isNotEmpty) {
        setState(() {
          _fetchedClass = classesResponse.result.first;
          _isOdrzan = _fetchedClass?.isOdrzan;
          _isLoading = false;
        });

        await _fetchAnnualPlanProgram(_fetchedClass?.godisnjiPlanProgramID);
      }
    } catch (e) {
      print("Failed to fetch classes: $e");
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _fetchAnnualPlanProgram(int? godisnjiPlanProgramID) async {
    if (godisnjiPlanProgramID == null) {
      print("Annual Plan Program ID is null");
      return;
    }

    try {
      var annualPlanProgramResponse =
          await _annualPlanProgramProvider.get(filter: {
        'GodisnjiPlanProgramID': godisnjiPlanProgramID,
      });

      if (annualPlanProgramResponse != null &&
          annualPlanProgramResponse.result.isNotEmpty) {
        AnnualPlanProgram annualPlanProgram =
            annualPlanProgramResponse.result.first;
        await _fetchDepartment(annualPlanProgram.odjeljenjeID);
      } else {
        print(
            "No Annual Plan Program found for GodisnjiPlanProgramID: $godisnjiPlanProgramID");
      }
    } catch (e) {
      print("Failed to fetch Annual Plan Program: $e");
    }
  }

  Future<void> _fetchDepartment(int? odjeljenjeID) async {
    if (odjeljenjeID == null) {
      print("Department ID is null");
      return;
    }

    try {
      var departmentResponse = await _departmentProvider.get(filter: {
        'OdjeljenjeID': odjeljenjeID,
        'isUceniciIncluded': true,
      });

      if (departmentResponse != null && departmentResponse.result.isNotEmpty) {
        setState(() {
          _fetchedDepartment = departmentResponse.result.first;
        });

        await _fetchClassesStudents();

        if (_classesStudentsList == null || _classesStudentsList!.isEmpty) {
          await _insertClassesStudents(_fetchedDepartment!.ucenici!);
        } else {
          print("ClassesStudents already exist for this CasoviID.");
        }

        await _fetchClassesStudents();
      } else {
        print("No Department found for OdjeljenjeID: $odjeljenjeID");
      }
    } catch (e) {
      print("Failed to fetch Department: $e");
    }
  }

  Future<void> _fetchClassesStudents() async {
    try {
      var response = await _classesStudentsProvider.get(filter: {
        'CasoviID': widget.casoviID,
      });

      if (response != null && response.result.isNotEmpty) {
        setState(() {
          _classesStudentsList = response.result;
        });
      } else {
        print("No ClassesStudents found for CasoviID: ${widget.casoviID}");
      }
    } catch (e) {
      print("Failed to fetch ClassesStudents: $e");
    }
  }

  Future<void> _insertClassesStudents(List<User> ucenici) async {
    for (var ucenik in ucenici) {
      try {
        var request = {
          'casoviID': widget.casoviID,
          'ucenikID': ucenik.korisnikId,
          'isPrisutan': false
        };

        await _classesStudentsProvider.Insert(request);
        print("ClassesStudent inserted for ucenikID: ${ucenik.korisnikId}");
      } catch (e) {
        print("Failed to insert ClassesStudent: $e");
      }
    }
  }

  Future<void> _updateClassOdrzan(bool value) async {
    setState(() {
      _isOdrzan = value;
    });

    if (_fetchedClass != null && widget.casoviID != null) {
      final updateRequest = {
        'NazivCasa': _fetchedClass?.nazivCasa,
        'Opis': _fetchedClass?.opis,
        'GodisnjiPlanProgramID': _fetchedClass?.godisnjiPlanProgramID,
        'DatumOdrzavanjaCasa':
            _fetchedClass?.datumOdrzavanjaCasa?.toIso8601String(),
        'isOdrzan': value,
      };

      try {
        await _classesProvider.Update(widget.casoviID!, updateRequest);
        print("Class updated successfully!");
      } catch (e) {
        print("Failed to update class: $e");
      }
    }
  }

  Future<void> _updateStudentsPresenceAndLock() async {
    if (_classesStudentsList == null || _classesStudentsList!.isEmpty) {
      print("No students to update.");
      return;
    }

    try {
      for (var student in _classesStudentsList!) {
        if (student.casoviUceniciID == null) {
          print(
              "Skipping student ${student.ucenikID} as CasoviStudentiID is null.");
          continue;
        }

        var updateRequest = {
          'CasoviID': widget.casoviID,
          'UcenikID': student.ucenikID,
          'IsPrisutan': student.isPrisutan,
          'Zakljucan': true,
          'CasoviStudentiID': student.casoviUceniciID,
        };

        await _classesStudentsProvider.Update(
            student.casoviUceniciID!, updateRequest);
        student.zakljucan = true;
      }

      setState(() {
        _isSubmitted = true;
      });

      print("All students updated and locked successfully!");
    } catch (e) {
      print("Failed to update and lock student presence: $e");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Align(
        alignment: Alignment.topLeft,
        child: Container(
          width: double.infinity,
          height: double.infinity,
          color: Color(0xFFF7F2FA),
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: _isLoading
                ? Center(child: CircularProgressIndicator())
                : Container(
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    child: SingleChildScrollView(
                      child: Column(
                        children: [
                          _buildScreenName(),
                          SizedBox(height: 16.0),
                          _classesStudentsList != null
                              ? _buildClassesStudentsTable(
                                  _classesStudentsList!)
                              : SizedBox(),
                          SizedBox(height: 16.0),
                          if (_isOdrzan == true && !_isSubmitted)
                            _buildAddPresenceButton(),
                        ],
                      ),
                    ),
                  ),
          ),
        ),
      ),
    );
  }

  Future<void> _toggleAllPresent(bool value) async {
    setState(() {
      _allPresent = value;
      for (var student in _classesStudentsList!) {
        student.isPrisutan = value;
      }
    });
  }

  Future<void> _toggleStudentPresent(int studentId, bool value) async {
    setState(() {
      var student =
          _classesStudentsList!.firstWhere((s) => s.ucenikID == studentId);
      student.isPrisutan = value;

      _allPresent = _classesStudentsList!.every((s) => s.isPrisutan == true);
    });
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
              "Održani časovi",
              style: TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Spacer(),
          Column(
            children: [
              _buildConfirmationRow(),
              Row(
                children: [
                  Checkbox(
                    value: _allPresent,
                    onChanged: (_isOdrzan == true && !_isSubmitted)
                        ? (value) {
                            _toggleAllPresent(value ?? false);
                          }
                        : null,
                  ),
                  Text(
                    "Svi prisutni",
                    style: TextStyle(
                      fontSize: 16,
                    ),
                  ),
                ],
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildConfirmationRow() {
    return Padding(
      padding: const EdgeInsets.only(left: 16.0, right: 16),
      child: Row(
        children: [
          Text(
            "Da li je čas održan: ",
            style: TextStyle(
              fontSize: 16,
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 8.0, right: 8.0),
            child: Row(
              children: [
                ElevatedButton(
                  onPressed:
                      _isSubmitted ? null : () => _updateClassOdrzan(true),
                  style: ElevatedButton.styleFrom(
                    backgroundColor:
                        (_isOdrzan == true) ? Colors.green : Colors.grey,
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                  ),
                  child: Text('Da'),
                ),
                SizedBox(width: 10),
                ElevatedButton(
                  onPressed:
                      _isSubmitted ? null : () => _updateClassOdrzan(false),
                  style: ElevatedButton.styleFrom(
                    backgroundColor:
                        (_isOdrzan == false) ? Colors.red : Colors.grey,
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                  ),
                  child: Text('Ne'),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildClassesStudentsTable(List<ClassesStudents> classesStudents) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: DataTable(
        columns: const [
          DataColumn(label: Text('Ime')),
          DataColumn(label: Text('Prezime')),
          DataColumn(label: Text('Prisutan')),
        ],
        rows: classesStudents.map((classStudent) {
          var user = _fetchedDepartment?.ucenici?.firstWhere(
            (u) => u.korisnikId == classStudent.ucenikID,
            orElse: () => User(null, null, null, null, null, null, null, null,
                null, null, null),
          );
          return DataRow(cells: [
            DataCell(Text(user?.ime ?? '')),
            DataCell(Text(user?.prezime ?? '')),
            DataCell(
              Checkbox(
                value: classStudent.isPrisutan,
                onChanged: (_isOdrzan == true &&
                        !_isSubmitted &&
                        classStudent.zakljucan != true)
                    ? (value) {
                        _toggleStudentPresent(
                            classStudent.ucenikID!, value ?? false);
                      }
                    : null,
              ),
            ),
          ]);
        }).toList(),
      ),
    );
  }

  Widget _buildAddPresenceButton() {
    return ElevatedButton(
      onPressed: _isSubmitted ? null : _updateStudentsPresenceAndLock,
      style: ElevatedButton.styleFrom(
        backgroundColor: _isSubmitted ? Colors.grey : Colors.blue,
        foregroundColor: Colors.white,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(10),
        ),
      ),
      child: Text('Dodaj prisustvo'),
    );
  }
}
