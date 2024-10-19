import 'package:ednevnik_admin/utils/custom_exception_util.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class SingleClassListScreen extends StatefulWidget {
  final Classes? classes;
  final int? annualPlanProgramID;

  const SingleClassListScreen(
      {Key? key, this.classes, this.annualPlanProgramID})
      : super(key: key);

  @override
  _SingleClassListScreenState createState() => _SingleClassListScreenState();
}

class _SingleClassListScreenState extends State<SingleClassListScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late ClassesProvider _classProvider;

  @override
  void initState() {
    super.initState();
    _classProvider = context.read<ClassesProvider>();
    _initializeForm();
  }

  void _initializeForm() {
    if (widget.classes != null) {
      _formKey.currentState?.patchValue({
        'nazivCasa': widget.classes?.nazivCasa ?? '',
        'opis': widget.classes?.opis ?? '',
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(20.0),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildScreenName(),
              SizedBox(height: 16.0),
              Expanded(
                child: FormBuilder(
                  key: _formKey,
                  initialValue: {
                    'nazivCasa': widget.classes?.nazivCasa ?? '',
                    'opis': widget.classes?.opis ?? '',
                  },
                  child: SingleChildScrollView(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Padding(
                          padding: const EdgeInsets.symmetric(
                              vertical: 8.0, horizontal: 16.0),
                          child: FormBuilderTextField(
                            name: 'nazivCasa',
                            decoration:
                                InputDecoration(labelText: 'Naziv časa'),
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: 'Polje je obavezno'),
                              FormBuilderValidators.match(
                                  RegExp(r'^[a-zA-Z\s.,!]*$'),
                                  errorText:
                                      'Možete koristiti samo slova i znakove: .,!'),
                              (val) {
                                if (val != null &&
                                    !RegExp(r'^[A-Z].*').hasMatch(val)) {
                                  return 'Naziv časa mora početi velikim slovom';
                                }
                                if (val != null && val.length < 4) {
                                  return 'Naziv časa mora imati minimum 4 slova';
                                }
                                return null;
                                return null;
                              },
                            ]),
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.symmetric(
                              vertical: 8.0, horizontal: 16.0),
                          child: FormBuilderTextField(
                            name: 'opis',
                            decoration: InputDecoration(labelText: 'Opis'),
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: 'Polje je obavezno'),
                              FormBuilderValidators.match(
                                  RegExp(r'^[a-zA-Z\s.,!]*$'),
                                  errorText:
                                      'Možete koristiti samo slova i znakove: .,!'),
                              (val) {
                                if (val != null) {
                                  if (!RegExp(r'^[A-Z].*').hasMatch(val)) {
                                    return 'Opis mora početi velikim slovom';
                                  }
                                  if (val.length < 4) {
                                    return 'Opis mora imati minimum 4 slova';
                                  }
                                  if (!val.endsWith('.')) {
                                    return 'Opis mora završiti tačkom.';
                                  }
                                }
                                return null;
                              },
                            ]),
                          ),
                        ),
                        SizedBox(height: 20),
                        if (widget.classes != null)
                          Padding(
                            padding:
                                const EdgeInsets.symmetric(horizontal: 16.0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              children: [
                                ElevatedButton(
                                  style: ElevatedButton.styleFrom(
                                    foregroundColor: Colors.white,
                                    backgroundColor: Colors.red,
                                  ),
                                  onPressed: () async {
                                    await _showDeleteConfirmationDialog();
                                  },
                                  child: Text('Izbriši čas'),
                                ),
                              ],
                            ),
                          ),
                        Padding(
                          padding: const EdgeInsets.symmetric(horizontal: 16.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.end,
                            children: [
                              ElevatedButton(
                                style: ElevatedButton.styleFrom(
                                  foregroundColor: Colors.black,
                                  backgroundColor: Colors.white,
                                ),
                                onPressed: () {
                                  Navigator.pop(context, true);
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
                                child: widget.classes == null
                                    ? Text('Dodaj čas')
                                    : Text('Sačuvaj'),
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ],
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
          widget.classes == null ? "Dodaj čas" : "Uređivanje časa",
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
      var formValues =
          Map<String, dynamic>.from(_formKey.currentState?.value ?? {});
      formValues['godisnjiPlanProgramID'] = widget.annualPlanProgramID;
      print('Form values to be sent to backend: $formValues');
      try {
        if (widget.classes == null) {
          print(formValues);
          await _classProvider.Insert(formValues);
        } else {
          final id = widget.classes!.casoviID;
          if (id != null) {
            await _classProvider.Update(id, formValues);
          } else {
            throw Exception('Class ID is null');
          }
        }
        Navigator.pop(context, true);
      } on MaxItemsExceededException catch (e) {
        _showErrorDialog(e.message);
      } catch (e) {
        _showErrorDialog(e.toString());
      }
    }
  }

  Future<void> _showDeleteConfirmationDialog() async {
    final bool? confirmed = await showDialog<bool>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Potvrda brisanja'),
          content: Text('Da li ste sigurni da želite izbrisati čas?'),
          actions: <Widget>[
            TextButton(
              onPressed: () => Navigator.pop(context, false),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
              child: Text('Otkaži'),
            ),
            TextButton(
              onPressed: () => Navigator.pop(context, true),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white, backgroundColor: Colors.red),
              child: Text('Obriši'),
            ),
          ],
        );
      },
    );

    if (confirmed == true) {
      _deleteClass();
    }
  }

  Future<void> _deleteClass() async {
    try {
      if (widget.classes != null) {
        final id = widget.classes!.casoviID;
        if (id != null) {
          await _classProvider.delete(id);
          Navigator.pop(context, true);
        } else {
          throw Exception('Class ID is null');
        }
      }
    } catch (e) {
      _showErrorDialog(e.toString());
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Greška'),
          content: Text(message),
          actions: <Widget>[
            TextButton(
              child: Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
