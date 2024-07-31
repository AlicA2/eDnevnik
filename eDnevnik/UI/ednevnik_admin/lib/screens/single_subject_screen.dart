import 'dart:convert';
import 'dart:io';

import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
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

  SearchResult<User>? userResult;
  SearchResult<Department>? departmentResult;
  List<Subject> _subjects = [];

  @override
  void initState() {
    super.initState();

    _initialValue = {
      'naziv': widget.subject?.naziv,
      'opis': widget.subject?.opis,
      'stateMachine': widget.subject?.stateMachine
    };

    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _subjectProvider = context.read<SubjectProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
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
      child: Column(
        children: [
          _buildForm(),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              ElevatedButton(
                onPressed: () async {
                  if (widget.subject != null &&
                      widget.subject!.predmetID != null) {
                    try {
                      print(
                          'Deleting subject with ID: ${widget.subject!.predmetID}');
                      await _subjectProvider.delete(widget.subject!.predmetID!);
                      Navigator.pop(context, 'deleted');
                    } catch (e) {
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
                },
                child: Text("Izbriši predmet"),
              ),
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState?.saveAndValidate() ?? false) {
                      print(_formKey.currentState?.value);

                      var request = new Map.from(_formKey.currentState!.value);

                      try {
                        if (widget.subject == null) {
                          await _subjectProvider.Insert(request);
                          Navigator.pop(context, 'added');
                        } else {
                          await _subjectProvider.Update(
                              widget.subject!.predmetID!,
                              _formKey.currentState?.value);
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
                  },
                  child: Text('Sačuvaj'),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  child: Text('Odustani'),
                ),
              ),
            ],
          )
        ],
      ),
      tittle: this.widget.subject?.naziv ?? "Lista Predmeta",
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
              decoration: InputDecoration(labelText: "Naziv ili šifra predmeta"),
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

  File? _image;
  String? _base64Image;

  Future getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null && result.files.single.path != null) {
      _image = File(result.files.single.path!);
      _base64Image = base64Encode(_image!.readAsBytesSync());
    }
  }
}
