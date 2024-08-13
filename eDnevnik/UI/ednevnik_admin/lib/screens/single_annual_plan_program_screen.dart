import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

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

  List<DropdownMenuItem<int>> _departmentDropdownItems = [];
  List<DropdownMenuItem<int>> _subjectDropdownItems = [];
  List<DropdownMenuItem<int>> _schoolDropdownItems = [];

  School? _selectedSchool;

  @override
  void initState() {
    super.initState();
    _planProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();

    _initializeForm();
  }



  Future<void> _initializeForm() async {
    await _loadDropdownItems();
    if (widget.planProgram != null) {
      final odjeljenjeExists = _departmentDropdownItems
          .any((item) => item.value == widget.planProgram!.odjeljenjeID);
      final predmetExists = _subjectDropdownItems
          .any((item) => item.value == widget.planProgram!.predmetID);

      _formKey.currentState?.patchValue({
        'naziv': widget.planProgram?.naziv ?? '',
        'brojCasova': widget.planProgram?.brojCasova?.toString() ?? '',
        'odjeljenjeID': odjeljenjeExists ? widget.planProgram?.odjeljenjeID : null,
        'predmetID': predmetExists ? widget.planProgram?.predmetID : null,
      });
    }
  }

  Future<void> _loadDropdownItems() async {
    var departments = await _departmentProvider.get(filter: {
      'SkolaID': _selectedSchool?.skolaID,
    });

    var subjects = await _subjectProvider.get(filter: {
      'SkolaID': _selectedSchool?.skolaID,
    });

    setState(() {
      _departmentDropdownItems = departments.result?.map((department) {
            return DropdownMenuItem<int>(
              value: department.odjeljenjeID,
              child: Text(department.nazivOdjeljenja.toString()),
            );
          }).toList() ??
          [];

      _subjectDropdownItems = subjects.result?.map((subject) {
            return DropdownMenuItem<int>(
              value: subject.predmetID,
              child: Text(subject.naziv.toString()),
            );
          }).toList() ??
          [];
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      // disableSchoolDropdown: widget.planProgram != null,
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
                      FormBuilderDropdown<int>(
                        name: 'odjeljenjeID',
                        items: _departmentDropdownItems,
                        decoration: InputDecoration(labelText: 'Odjeljenje'),
                        enabled: widget.planProgram == null,
                        validator: FormBuilderValidators.required(
                            errorText: 'Odjeljenje ne može biti prazno'),
                      ),
                      SizedBox(height: 20),
                      FormBuilderDropdown<int>(
                        name: 'predmetID',
                        items: _subjectDropdownItems,
                        decoration: InputDecoration(labelText: 'Predmet'),
                        enabled: widget.planProgram == null,
                        validator: FormBuilderValidators.required(
                            errorText: 'Predmet ne može biti prazan'),
                      ),
                      SizedBox(height: 20),
                      Row(
                        children: [
                          if (widget.planProgram != null)
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
      child: Container(
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
    );
  }

  Future<void> _saveForm() async {
    if (_formKey.currentState?.saveAndValidate() ?? false) {
      var formValues = _formKey.currentState?.value;
      try {
        if (widget.planProgram == null) {
          bool exists = await _planProgramProvider.checkIfExists(
              formValues?['odjeljenjeID'] ?? 0, formValues?['predmetID'] ?? 0);

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
            throw Exception('PlanProgram ID is null');
          }
        }
        Navigator.pop(context, true);
      } catch (e) {
        _showErrorDialog(e.toString());
      }
    }
  }

  Future<void> _deletePlanProgram() async {
    final shouldDelete = await _showConfirmationDialog();
    if (shouldDelete) {
      try {
        if (widget.planProgram != null) {
          final id = widget.planProgram!.godisnjiPlanProgramID;
          if (id != null) {
            await _planProgramProvider.delete(id);
            Navigator.pop(context, true);
          } else {
            throw Exception('PlanProgram ID is null');
          }
        }
      } catch (e) {
        _showErrorDialog(e.toString());
      }
    }
  }

  Future<bool> _showConfirmationDialog() async {
    return await showDialog<bool>(
          context: context,
          barrierDismissible: false,
          builder: (BuildContext context) {
            return AlertDialog(
              title: Text('Potvrda brisanja'),
              content:
                  Text('Da li ste sigurni da želite obrisati plan i program?'),
              actions: <Widget>[
                TextButton(
                  child: Text('Otkaži'),
                  onPressed: () => Navigator.of(context).pop(false),
                ),
                TextButton(
                  child: Text('Obriši'),
                  onPressed: () => Navigator.of(context).pop(true),
                ),
              ],
            );
          },
        ) ??
        false;
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        title: Text('Greška'),
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
