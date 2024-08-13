import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
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

  Department? _selectedDepartment;
  Subject? _selectedSubject;
  School? _selectedSchool;

  int? _selectedDepartmentID;
  int? _selectedSchoolID;
  int? _selectedSubjectID;

  List<Department> _departments = [];
  List<Subject> _subjects = [];
  List<School> _schools = [];

  @override
  void initState() {
    super.initState();
    _planProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();

    _fetchSchools();
  }

 Future<void> _fetchDepartments() async {
  if (_selectedSchool != null) {
    try {
      var data = await _departmentProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });
      if (mounted) {
        setState(() {
          _departments = data.result;
          _selectedDepartment = widget.planProgram != null
              ? _departments.firstWhere(
                  (dept) => dept.odjeljenjeID == widget.planProgram?.odjeljenjeID,
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
      var data = await _subjectProvider.get(filter: {
        'SkolaID': _selectedSchool?.skolaID,
      });
      if (mounted) {
        setState(() {
          _subjects = data.result;
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
                      initialValue: isEditMode ? widget.planProgram?.naziv : '',
                      decoration: InputDecoration(labelText: 'Naziv'),
                      validator: FormBuilderValidators.compose([
                        FormBuilderValidators.required(
                            errorText: 'Polje je obavezno'),
                        (val) {
                          if (val != null &&
                              !RegExp(r'^[a-zA-Z\s]*$').hasMatch(val)) {
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
                    FormBuilderDropdown<Department>(
                      name: 'odjeljenje',
                      decoration: InputDecoration(labelText: 'Odjeljenje'),
                      initialValue: _selectedDepartment,
                      validator: FormBuilderValidators.compose([
                        FormBuilderValidators.required(errorText: 'Odjeljenje je obavezno'),
                      ]),
                      onChanged: isEditMode ? null : (Department? newValue) {
                        setState(() {
                          _selectedDepartment = newValue;
                          _selectedDepartmentID = newValue?.odjeljenjeID;
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
                      FormBuilderValidators.required(errorText: 'Predmet je obavezan'),
                      ]),
                      onChanged: isEditMode ? null : (Subject? newValue) {
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
                    Row(
                      children: [
                        if (isEditMode)
                          ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              foregroundColor: Colors.white,
                              backgroundColor: Colors.blue,
                            ),
                            onPressed: _deletePlanProgram,
                            child: Text('Brisanje plana i programa'),
                          ),
                        Spacer(),
                        ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.blue,
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
                            backgroundColor: Colors.blue,
                          ),
                          onPressed: _saveForm,
                          child: Text('Sačuvaj'),
                        ),
                      ],
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
          width: 300,
          child: DropdownButton<School>(
            value: _selectedSchool,
            hint: Text("Select School"),
            onChanged: isEditMode ? null :(School? newValue) async {
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
    var formValues = Map<String, dynamic>.from(_formKey.currentState?.value ?? {});

    formValues['skolaID'] = _selectedSchool?.skolaID;
    formValues['predmetID'] = _selectedSubject?.predmetID;
    formValues['odjeljenjeID'] = _selectedDepartment?.odjeljenjeID;

    print('Form values: $formValues');

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
      } else {
        final id = widget.planProgram!.godisnjiPlanProgramID;
        if (id != null) {
          await _planProgramProvider.Update(id, formValues);
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
  if (widget.planProgram?.godisnjiPlanProgramID != null) {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Potvrda brisanja'),
        content: Text('Da li ste sigurni da želite da obrišete ovaj plan i program?'),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context, false),
            child: Text('Odustani'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            child: Text('Obriši'),
          ),
        ],
      ),
    );

    if (confirmDelete == true) {
      try {
        await _planProgramProvider.delete(widget.planProgram!.godisnjiPlanProgramID!);
        Navigator.pop(context, true);
      } catch (e) {
        _showErrorDialog("Failed to delete data: $e");
      }
    }
  }
}


  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Error'),
        content: Text(message),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text('OK'),
          ),
        ],
      ),
    );
  }
}
