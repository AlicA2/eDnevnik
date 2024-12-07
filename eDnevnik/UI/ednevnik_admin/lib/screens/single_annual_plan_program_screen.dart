import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/school_year.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

class SingleAnnualPlanProgramScreen extends StatefulWidget {
  final AnnualPlanProgram? planProgram;

  const SingleAnnualPlanProgramScreen({Key? key, this.planProgram})
      : super(key: key);

  @override
  _SingleAnnualPlanProgramScreenState createState() =>
      _SingleAnnualPlanProgramScreenState();
}

class _SingleAnnualPlanProgramScreenState
    extends State<SingleAnnualPlanProgramScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late AnnualPlanProgramProvider _planProgramProvider;
  late DepartmentProvider _departmentProvider;
  late SubjectProvider _subjectProvider;
  late SchoolProvider _schoolProvider;
  late ClassesProvider _classProvider;
  late UserProvider _usersProvider;
  late SchoolYearProvider _schoolYearProvider;

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;
  User? _selectedProfesor;
  SchoolYear? _selectedSchoolYear;

  int? _selectedProfesorID;
  int? _selectedDepartmentID;
  int? _selectedSchoolID;
  int? _selectedSubjectID;
  int? _selectedSchoolYearID;
  User? loggedInUser;

  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];
  List<User> _profesor = [];
  List<SchoolYear> _schoolYears = [];

  @override
  void initState() {
    super.initState();
    _planProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _classProvider = context.read<ClassesProvider>();
    _usersProvider = context.read<UserProvider>();
    _schoolYearProvider = context.read<SchoolYearProvider>();

    _fetchSchools();
    _fetchUsers();
    _fetchSchoolYears();
  }

  Future<void> _fetchSchoolYears() async {
    try {
      var schoolYearData = await _schoolYearProvider.get();
      if (mounted) {
        setState(() {
          _schoolYears = schoolYearData.result;

          if (_schoolYears.isEmpty) {
            _selectedSchoolYear = null;
          } else {
            _selectedSchoolYear = widget.planProgram != null
                ? _schoolYears.firstWhere(
                    (year) =>
                        year.skolskaGodinaID ==
                        widget.planProgram?.skolskaGodinaID,
                    orElse: () => SchoolYear(),
                  )
                : null;
          }
        });
      }
    } catch (e) {
      _showErrorDialog("Failed to load school years: $e");
    }
  }

  Future<void> _fetchUsers() async {
    try {
      var userList = await _usersProvider
          .get(filter: {"isUlogeIncluded": true, "UlogaID": 1});
      if (mounted) {
        setState(() {
          _profesor = userList.result;

          if (widget.planProgram?.profesorID != null) {
            _selectedProfesor = _profesor.firstWhere(
              (profesor) =>
                  profesor.korisnikId == widget.planProgram?.profesorID,
              orElse: () => User(null, null, null, null, null, null, null, null,
                  null, null, null),
            );
            _selectedProfesorID = _selectedProfesor?.korisnikId;
          }
        });
      }
    } catch (e) {
      _showErrorDialog("Failed to load users: $e");
    }
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  Future<List<AnnualPlanProgram>> _fetchAllPlanPrograms() async {
    try {
      var planPrograms = await _planProgramProvider
          .get(filter: {"SkolaID": _selectedSchool?.skolaID});
      return planPrograms.result;
    } catch (e) {
      _showErrorDialog("Failed to load existing annual plan programs: $e");
      return [];
    }
  }

  Future<void> _fetchDepartments() async {
    if (_selectedSchool != null) {
      try {
        var allPlanPrograms = await _fetchAllPlanPrograms();
        var usedDepartmentIDs =
            allPlanPrograms.map((plan) => plan.odjeljenjeID).toSet();

        var data = await _departmentProvider.get(filter: {
          'SkolaID': _selectedSchool?.skolaID,
        });

        if (mounted) {
          setState(() {
            _departments = data.result.where((dept) {
              return dept.odjeljenjeID == widget.planProgram?.odjeljenjeID ||
                  !usedDepartmentIDs.contains(dept.odjeljenjeID);
            }).toList();

            _selectedDepartment = widget.planProgram != null
                ? _departments.firstWhere(
                    (dept) =>
                        dept.odjeljenjeID == widget.planProgram?.odjeljenjeID,
                    orElse: () => _departments.isNotEmpty
                        ? _departments.first
                        : Department(0, '', 0, 0),
                  )
                : null;
          });
        }
      } catch (e) {
        _showErrorDialog("Failed to load departments: $e");
      }
    }
  }

  Future<void> _fetchSubjects() async {
    if (_selectedSchool != null) {
      try {
        var allPlanPrograms = await _fetchAllPlanPrograms();
        var usedSubjectIDs =
            allPlanPrograms.map((plan) => plan.predmetID).toSet();

        var data = await _subjectProvider.get(filter: {
          'SkolaID': _selectedSchool?.skolaID,
        });

        if (mounted) {
          setState(() {
            _subjects = data.result.where((sub) {
              return sub.predmetID == widget.planProgram?.predmetID ||
                  !usedSubjectIDs.contains(sub.predmetID);
            }).toList();

            _selectedSubject = widget.planProgram != null
                ? _subjects.firstWhere(
                    (sub) => sub.predmetID == widget.planProgram?.predmetID,
                    orElse: () => _subjects.isNotEmpty
                        ? _subjects.first
                        : Subject(0, '', '', '', 0),
                  )
                : null;
          });
        }
      } catch (e) {
        _showErrorDialog("Failed to load subjects: $e");
      }
    }
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      setState(() {
        _schools = schools.result;
        if (_schools.isNotEmpty) {
          _selectedSchool = widget.planProgram != null
              ? _schools.firstWhere(
                  (school) => school.skolaID == widget.planProgram?.skolaID,
                  orElse: () => _schools.first)
              : _schools.first;
          _fetchDepartments();
          _fetchSubjects();
        }
      });
    } catch (e) {
      _showErrorDialog("Failed to load schools: $e");
    }
  }

  @override
  Widget build(BuildContext context) {
    final isEditMode = widget.planProgram != null;
    return MasterScreenWidget(
      child: Align(
        alignment: Alignment.topLeft,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20.0),
            ),
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: FormBuilder(
                key: _formKey,
                child: SingleChildScrollView(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      _buildScreenName(),
                      SizedBox(height: 20),
                      FormBuilderTextField(
                        name: 'naziv',
                        initialValue:
                            isEditMode ? widget.planProgram?.naziv : '',
                        decoration: InputDecoration(labelText: 'Naziv'),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Polje je obavezno'),
                          (val) {
                            if (val != null &&
                                !RegExp(r'^[A-Z].*').hasMatch(val)) {
                              return 'Naziv mora početi velikim slovom';
                            }

                            if (val != null &&
                                !val.startsWith("Plan i program za ")) {
                              return 'Naziv mora početi sa "Plan i program za "';
                            }

                            if (val != null &&
                                val.length > "Plan i program za ".length + 2) {
                              String subjectPart = val
                                  .substring("Plan i program za ".length,
                                      val.length - 2)
                                  .trim();
                              if (subjectPart.isNotEmpty &&
                                  !RegExp(r'^[A-Z].*').hasMatch(subjectPart)) {
                                return 'Predmet mora početi velikim slovom';
                              }
                            } else {
                              return 'Naziv mora imati validan predmet';
                            }

                            if (val != null &&
                                !val.endsWith(" I") &&
                                !val.endsWith(" II") &&
                                !val.endsWith(" III") &&
                                !val.endsWith(" IV")) {
                              return 'Naziv mora završiti sa razredom " I", " II", " III" ili " IV"';
                            }

                            if (val != null &&
                                !RegExp(r'^[a-zA-Z\s]+$').hasMatch(val)) {
                              return 'Mogu se uneti samo slova';
                            }

                            return null;
                          },
                        ]),
                      ),
                      SizedBox(height: 20),
                      FormBuilderTextField(
                        name: 'brojCasova',
                        initialValue: isEditMode
                            ? widget.planProgram?.brojCasova.toString()
                            : '',
                        keyboardType: TextInputType.number,
                        decoration: InputDecoration(labelText: 'Broj časova'),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Broj časova ne može biti prazan'),
                          FormBuilderValidators.numeric(
                              errorText: 'Broj časova mora biti broj'),
                          FormBuilderValidators.min(5,
                              errorText: 'Broj časova mora biti najmanje 5'),
                          FormBuilderValidators.max(10,
                              errorText: 'Broj časova mora biti najviše 10'),
                        ]),
                      ),
                      SizedBox(height: 20),
                      FormBuilderDropdown<User>(
                        name: 'profesor',
                        decoration:
                            InputDecoration(labelText: 'Izaberite profesora'),
                        initialValue: _selectedProfesor,
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Profesor je obavezan'),
                        ]),
                        onChanged: (User? newValue) {
                          setState(() {
                            _selectedProfesor = newValue;
                          });
                        },
                        items: _profesor.map((User profesor) {
                          return DropdownMenuItem<User>(
                            value: profesor,
                            child: Text('${profesor.ime} ${profesor.prezime}'),
                          );
                        }).toList(),
                      ),
                      SizedBox(height: 20),
                      FormBuilderDropdown<SchoolYear>(
                        name: 'schoolYear',
                        decoration: InputDecoration(labelText: 'Izaberite školsku godinu'),
                        initialValue: _selectedSchoolYear,
                        validator: (value) {
                          if (!isEditMode && _schoolYears.isNotEmpty && value == null) {
                            return 'Školska godina je obavezna';
                          }
                          return null;
                        },
                        onChanged: isEditMode
                            ? null
                            : (SchoolYear? newValue) {
                                setState(() {
                                  _selectedSchoolYear = newValue;
                                  _selectedSchoolYearID = newValue?.skolskaGodinaID;
                                });
                              },
                        items: _schoolYears.map((SchoolYear year) {
                          return DropdownMenuItem<SchoolYear>(
                            value: year,
                            child: Text(year.naziv ?? ""),
                          );
                        }).toList(),
                        enabled: !isEditMode,
                      ),
                      SizedBox(height: 20),
                      FormBuilderDropdown<Department>(
                        name: 'odjeljenje',
                        decoration: InputDecoration(labelText: 'Odjeljenje'),
                        initialValue: _selectedDepartment,
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Odjeljenje je obavezno'),
                        ]),
                        onChanged: isEditMode
                            ? null
                            : (Department? newValue) {
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
                        enabled: !isEditMode,
                      ),
                      SizedBox(height: 20),
                      FormBuilderDropdown<Subject>(
                        name: 'predmet',
                        decoration: InputDecoration(labelText: 'Predmet'),
                        initialValue: _selectedSubject,
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Predmet je obavezan'),
                        ]),
                        onChanged: isEditMode
                            ? null
                            : (Subject? newValue) {
                                setState(() {
                                  _selectedSubject = newValue;
                                  _selectedSubjectID = newValue?.predmetID;
                                });
                              },
                        items: _subjects.map((Subject subject) {
                          return DropdownMenuItem<Subject>(
                            value: subject,
                            child: Text(subject.naziv ?? ""),
                          );
                        }).toList(),
                        enabled: !isEditMode,
                      ),
                      SizedBox(height: 20),
                      Padding(
                        padding: const EdgeInsets.only(top: 16.0),
                        child: Row(
                          children: [
                            if (isEditMode)
                              ElevatedButton(
                                style: ElevatedButton.styleFrom(
                                  foregroundColor: Colors.white,
                                  backgroundColor: Colors.red,
                                ),
                                onPressed: () async {
                                  await _deletePlanProgram();
                                },
                                child: Text('Brisanje plana i programa'),
                              ),
                            Spacer(),
                            ElevatedButton(
                              style: ElevatedButton.styleFrom(
                                foregroundColor: Colors.black,
                                backgroundColor: Colors.white,
                              ),
                              onPressed: () {
                                Navigator.pop(context);
                              },
                              child: Text('Odustani'),
                            ),
                            SizedBox(width: 10),
                            ElevatedButton(
                              style: ElevatedButton.styleFrom(
                                foregroundColor: Colors.white,
                                backgroundColor: Colors.green,
                              ),
                              onPressed: () async {
                                await _saveForm();
                              },
                              child: Text('Sačuvaj'),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ),
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
              widget.planProgram == null
                  ? "Dodaj godišnji plan i program"
                  : "Uređivanje godišnjeg plana i programa",
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
    final isEditMode = widget.planProgram != null;
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 210,
          child: DropdownButton<School>(
            value: _selectedSchool,
            hint: Text("Select School"),
            onChanged: isEditMode
                ? null
                : (School? newValue) async {
                    setState(() {
                      _selectedSchool = newValue;
                      _selectedSchoolID = newValue?.skolaID;
                    });
                    await _fetchDepartments();
                    await _fetchSubjects();
                  },
            items: _schools.map((School school) {
              return DropdownMenuItem<School>(
                value: school,
                child: Text(school.naziv ?? ""),
              );
            }).toList(),
          ),
        ),
      ],
    );
  }

  Future<void> _saveForm() async {
    if (_formKey.currentState?.saveAndValidate() ?? false) {
      var formValues =
          Map<String, dynamic>.from(_formKey.currentState?.value ?? {});

      formValues['skolaID'] = _selectedSchool?.skolaID;
      formValues['predmetID'] = _selectedSubject?.predmetID;
      formValues['odjeljenjeID'] = _selectedDepartment?.odjeljenjeID;
      formValues['profesorID'] = _selectedProfesor?.korisnikId;
      formValues['skolskaGodinaID'] = _selectedSchoolYear?.skolskaGodinaID;

      try {
        if (widget.planProgram == null) {
          bool exists = await _planProgramProvider.checkIfExists(
              formValues['odjeljenjeID'] ?? 0, formValues['predmetID'] ?? 0);

          if (exists) {
            _showErrorDialog(
                'Plan i program za izabrano odjeljenje i predmet već postoji.');
            return;
          }
          await _planProgramProvider.Insert(formValues);
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text('Plan i program je uspješno spašen!'),
              backgroundColor: Colors.green,
            ),
          );
        } else {
          final id = widget.planProgram!.godisnjiPlanProgramID;
          if (id != null) {
            await _planProgramProvider.Update(id, formValues);
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text('Plan and program je uspješno ažuriran!'),
                backgroundColor: Colors.green,
              ),
            );
          } else {
            _showErrorDialog('Neuspješno ažuriranje podataka.');
            return;
          }
        }
        Navigator.pop(context, true);
      } catch (e) {
        _showErrorDialog("Failed to save data: $e");
      }
    }
  }

  Future<void> _deletePlanProgram() async {
    final annualPlanProgramID = widget.planProgram?.godisnjiPlanProgramID;

    if (annualPlanProgramID != null) {
      try {
        final hasClasses = await _classProvider.hasClasses(annualPlanProgramID);

        if (hasClasses) {
          _showErrorDialog(
              'Ne možete izbrisati plan i program jer postoje časovi povezani sa njim.');
          return;
        }

        bool? confirmDelete = await showDialog<bool>(
          context: context,
          builder: (context) => AlertDialog(
            title: Text('Potvrda brisanja'),
            content: Text(
                'Da li ste sigurni da želite da obrišete ovaj plan i program?'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context, false),
                style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.black,
                    backgroundColor: Colors.white),
                child: Text('Odustani'),
              ),
              TextButton(
                onPressed: () => Navigator.pop(context, true),
                style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.white, backgroundColor: Colors.red),
                child: Text('Obriši'),
              ),
            ],
          ),
        );

        if (confirmDelete == true) {
          await _planProgramProvider.delete(annualPlanProgramID);
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text('Plan i program je uspješno izbrisan!'),
              backgroundColor: Colors.green,
            ),
          );
          Navigator.pop(context, true);
        }
      } catch (e) {
        _showErrorDialog("Failed to delete data: $e");
      }
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Greška'),
        content: Text(message),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            style: ElevatedButton.styleFrom(
                foregroundColor: Colors.black, backgroundColor: Colors.white),
            child: Text('OK'),
          ),
        ],
      ),
    );
  }
}
