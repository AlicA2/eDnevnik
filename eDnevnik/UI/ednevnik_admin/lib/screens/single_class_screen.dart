import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class SingleClassListScreen extends StatefulWidget {
  final Classes? classes;

  const SingleClassListScreen({Key? key, this.classes}) : super(key: key);

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
                initialValue: {
                  'nazivCasa': widget.classes?.nazivCasa ?? '',
                  'opis': widget.classes?.opis ?? '',
                },
                child: SingleChildScrollView(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      _buildScreenName(),
                      SizedBox(height: 20),
                      FormBuilderTextField(
                        name: 'nazivCasa',
                        decoration: InputDecoration(labelText: 'Naziv časa'),
                      ),
                      SizedBox(height: 20),
                      FormBuilderTextField(
                        name: 'opis',
                        decoration: InputDecoration(labelText: 'Opis'),
                      ),
                      SizedBox(height: 20),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        children: [
                          ElevatedButton(
                            onPressed: () {
                              Navigator.pop(context);
                            },
                            child: Text('Odustani'),
                          ),
                          SizedBox(width: 10),
                          if (widget.classes != null)
                            ElevatedButton(
                              onPressed: _deleteClass,
                              child: Text('Izbriši'),
                            ),
                          SizedBox(width: 10),
                          ElevatedButton(
                            onPressed: _saveForm,
                            child: Text(widget.classes == null ? 'Dodaj' : 'Ažuriraj'),
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
      var formValues = _formKey.currentState?.value;
      try {
        if (widget.classes == null) {
          await _classProvider.Insert(formValues);
        } else {
          final id = widget.classes!.casoviID;
          if (id != null) {
            await _classProvider.Update(id, formValues);
          } else {
            throw Exception('Class ID is null');
          }
        }
        Navigator.pop(context);
      } catch (e) {
        _showErrorDialog(e.toString());
      }
    }
  }

  Future<void> _deleteClass() async {
    try {
      if (widget.classes != null) {
        final id = widget.classes!.casoviID;
        if (id != null) {
          await _classProvider.delete(id);
          Navigator.pop(context);
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
