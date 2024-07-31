import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:provider/provider.dart';

class SingleAnnualPlanProgramScreen extends StatefulWidget {
  final AnnualPlanProgram? planProgram;

  const SingleAnnualPlanProgramScreen({Key? key, this.planProgram}) : super(key: key);

  @override
  _SingleAnnualPlanProgramScreenState createState() => _SingleAnnualPlanProgramScreenState();
}

class _SingleAnnualPlanProgramScreenState extends State<SingleAnnualPlanProgramScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late AnnualPlanProgramProvider _planProgramProvider;
  late DepartmentProvider _departmentProvider;
  late SubjectProvider _subjectProvider;
  List<DropdownMenuItem<int>> _departmentDropdownItems = [];
  List<DropdownMenuItem<int>> _subjectDropdownItems = [];

  @override
  void initState() {
    super.initState();
    _planProgramProvider = context.read<AnnualPlanProgramProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _initializeForm();
  }

  Future<void> _initializeForm() async {
    await _loadDropdownItems();
    if (widget.planProgram != null) {
      _formKey.currentState?.patchValue({
        'naziv': widget.planProgram?.naziv ?? '',
        'brojCasova': widget.planProgram?.brojCasova?.toString() ?? '',
        'odjeljenjeID': widget.planProgram?.odjeljenjeID,
        'predmetID': widget.planProgram?.predmetID,
      });
    }
  }

  Future<void> _loadDropdownItems() async {
    var departments = await _departmentProvider.get();
    var subjects = await _subjectProvider.get();

    setState(() {
      _departmentDropdownItems = departments.result?.map((department) {
        return DropdownMenuItem<int>(
          value: department.odjeljenjeID,
          child: Text(department.nazivOdjeljenja.toString()),
        );
      }).toList() ?? [];

      _subjectDropdownItems = subjects.result?.map((subject) {
        return DropdownMenuItem<int>(
          value: subject.predmetID,
          child: Text(subject.naziv.toString()),
        );
      }).toList() ?? [];
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.planProgram?.naziv ?? 'Novi plan i program'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: FormBuilder(
          key: _formKey,
          initialValue: {
            'naziv': widget.planProgram?.naziv ?? '',
            'brojCasova': widget.planProgram?.brojCasova?.toString() ?? '',
            'odjeljenjeID': widget.planProgram?.odjeljenjeID,
            'predmetID': widget.planProgram?.predmetID,
          },
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                FormBuilderTextField(
                  name: 'naziv',
                  decoration: InputDecoration(labelText: 'Naziv'),
                ),
                SizedBox(height: 20),
                FormBuilderTextField(
                  name: 'brojCasova',
                  keyboardType: TextInputType.number,
                  decoration: InputDecoration(labelText: 'Broj časova'),
                ),
                SizedBox(height: 20),
                FormBuilderDropdown<int>(
                  name: 'odjeljenjeID',
                  items: _departmentDropdownItems,
                  decoration: InputDecoration(labelText: 'Odjeljenje'),
                ),
                SizedBox(height: 20),
                FormBuilderDropdown<int>(
                  name: 'predmetID',
                  items: _subjectDropdownItems,
                  decoration: InputDecoration(labelText: 'Predmet'),
                ),
                SizedBox(height: 20),
                Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    ElevatedButton(
                      onPressed: _saveForm,
                      child: Text('Spasi'),
                    ),
                    SizedBox(width: 10),
                    if (widget.planProgram != null)
                      ElevatedButton(
                        onPressed: _deletePlanProgram,
                        child: Text('Izbriši'),
                      ),
                  ],
                ),
              ],
            ),
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
          await _planProgramProvider.Insert(formValues); 
        } else {
          final id = widget.planProgram!.godisnjiPlanProgramID;
          if (id != null) {
            await _planProgramProvider.Update(id, formValues);
          } else {
            throw Exception('PlanProgram ID is null');
          }
        }
        Navigator.pop(context);
      } catch (e) {
        _showErrorDialog(e.toString());
      }
    }
  }

  Future<void> _deletePlanProgram() async {
    try {
      if (widget.planProgram != null) {
        final id = widget.planProgram!.godisnjiPlanProgramID;
        if (id != null) {
          await _planProgramProvider.delete(id); 
          Navigator.pop(context);
        } else {
          throw Exception('PlanProgram ID is null');
        }
      }
    } catch (e) {
      _showErrorDialog(e.toString());
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
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
