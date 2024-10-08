import 'dart:convert';
import 'dart:io';

import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class SingleSubjectListScreen extends StatefulWidget {
  Subject? subject;
  SingleSubjectListScreen({Key? key, this.subject}) : super(key: key);

  @override
  State<SingleSubjectListScreen> createState() =>
      _SingleSubjectListScreenState();
}

class _SingleSubjectListScreenState extends State<SingleSubjectListScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late DepartmentProvider _departmentProvider;
  late UserProvider _userProvider;
  late SubjectProvider _subjectProvider;
  late SchoolProvider _schoolProvider;

  List<School> _schools = [];
  School? _selectedSchool;

  SearchResult<User>? userResult;
  SearchResult<Department>? departmentResult;
  List<Subject> _subjects = [];

  @override
  void initState() {
    super.initState();

    _initialValue = {
      'naziv': widget.subject?.naziv,
      'opis': widget.subject?.opis,
      'stateMachine': widget.subject?.stateMachine,
      'SkolaID': widget.subject?.skolaID?.toString() ?? "",
    };

    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();

    _fetchSchools();
    initForm();
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = widget.subject != null
                ? _schools.firstWhere(
                    (school) => school.skolaID == widget.subject?.skolaID,
                    orElse: () => _schools.first)
                : _schools.first;
          }
        });
      }
    } catch (e) {}
  }

  Future initForm() async {
    userResult = await _userProvider.get();
    departmentResult = await _departmentProvider.get();
    var subjectResult = await _subjectProvider.get();
    setState(() {
      _subjects = subjectResult.result;
    });

    print(userResult);
    print(departmentResult);
  }

  bool _containsNumbers(String input) {
    return input.contains(RegExp(r'[0-9]'));
  }

  bool _isDuplicateSubject(String input) {
    return _subjects.any((subject) =>
        subject.naziv?.toLowerCase() == input.toLowerCase() &&
        subject.predmetID != widget.subject?.predmetID);
  }

  String? _validateNaziv(String? value) {
    if (value == null || value.isEmpty) {
      return 'Ovo polje ne može biti prazno.';
    }
    if (_containsNumbers(value)) {
      return 'Naziv ne može sadržavati brojeve.';
    }
    if (_isDuplicateSubject(value)) {
      return 'Predmet s ovim nazivom već postoji.';
    }
    return null;
  }

  String? _validateOpis(String? value) {
    if (value == null || value.isEmpty) {
      return 'Ovo polje ne može biti prazno.';
    }
    if (_containsNumbers(value)) {
      return 'Opis ne može sadržavati brojeve.';
    }
    return null;
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
                _buildForm(),
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      if (widget.subject != null &&
                          widget.subject!.predmetID != null)
                        ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.white,
                            backgroundColor: Colors.blue,
                          ),
                          onPressed: () async {await _deleteSubject();},
                          child: Text("Izbriši predmet"),
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
                        onPressed: () async {
                        await _saveForm(context);
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
    );
  }

  Future<void> _saveForm(BuildContext context) async {
    if (_formKey.currentState?.saveAndValidate() ?? false) {
      var request = Map.from(_formKey.currentState!.value);
    
      request['skolaID'] = _selectedSchool?.skolaID ?? 0;
    
      print(request);
    
      try {
        if (widget.subject == null) {
          await _subjectProvider.Insert(request);
          Navigator.pop(context, 'added');
        } else {
          await _subjectProvider.Update(
              widget.subject!.predmetID!, request);
          Navigator.pop(context, 'updated');
        }
      } on Exception catch (e) {
        showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
            title: Text("Error"),
            content: Text(e.toString()),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text("OK"),
              )
            ],
          ),
        );
      }
    }
  }

Future<void> _deleteSubject() async {
  if (widget.subject?.predmetID != null) {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Potvrda brisanja'),
        content: Text('Da li ste sigurni da želite da obrišete ovaj predmet?'),
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
        print('Deleting subject with ID: ${widget.subject!.predmetID}');
        await _subjectProvider.delete(widget.subject!.predmetID!);
        Navigator.pop(context, 'deleted');
      } catch (e) {
        _showErrorDialog("Failed to delete subject: $e");
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
              widget.subject == null ? "Dodavanje predmeta" : "Uređivanje predmeta",
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
    final isEditMode = widget.subject != null;
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
              });
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

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            FormBuilderTextField(
              decoration: InputDecoration(labelText: "Naziv predmeta"),
              name: 'naziv',
              validator: _validateNaziv,
            ),
            SizedBox(height: 20),
            FormBuilderTextField(
              decoration: InputDecoration(labelText: "Opis predmeta"),
              name: 'opis',
              validator: _validateOpis,
            ),
          ],
        ),
      ),
    );
  }
}
