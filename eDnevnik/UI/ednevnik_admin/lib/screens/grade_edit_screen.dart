import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:provider/provider.dart';

class EditGradesScreen extends StatefulWidget {
  final List<Grade> grades;

  const EditGradesScreen({Key? key, required this.grades}) : super(key: key);

  @override
  _EditGradesScreenState createState() => _EditGradesScreenState();
}

class _EditGradesScreenState extends State<EditGradesScreen> {
  late GradeProvider _gradesProvider;
  final Map<int, int?> _editedGrades = {};

  final Map<int, GlobalKey<FormState>> _formKeys = {};

  bool _isDataChanged = false;

  @override
  void initState() {
    super.initState();
    _gradesProvider = context.read<GradeProvider>();
    for (var grade in widget.grades) {
      _formKeys[grade.ocjenaID!] = GlobalKey<FormState>();
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Scaffold(
            body: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Container(
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(20.0),
                ),
                child: Column(
                  children: [
                    _buildScreenHeader(),
                    const SizedBox(height: 16.0),
                    Expanded(
                      child: ListView.builder(
                        itemCount: widget.grades.length,
                        itemBuilder: (context, index) {
                          Grade grade = widget.grades[index];
                          return _buildGradeEditRow(grade);
                        },
                      ),
                    ),
                    const SizedBox(height: 60.0),
                  ],
                ),
              ),
            ),
            floatingActionButton: Padding(
              padding: const EdgeInsets.only(left: 32, right: 32, bottom: 16),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const SizedBox(width: 16),
                  FloatingActionButton(
                    heroTag: 'backButton',
                    onPressed: () {
                      Navigator.pop(context, _isDataChanged);
                    },
                    backgroundColor: Colors.blue,
                    child: Tooltip(
                        message: "Nazad", child: const Icon(Icons.arrow_back)),
                  ),
                  const Spacer(),
                  FloatingActionButton(
                    heroTag: 'saveButton',
                    child: Tooltip(
                        message: "Spasi", child: const Icon(Icons.save)),
                    onPressed: () async {
                      bool allValid = true;
                      for (var key in _formKeys.values) {
                        if (!key.currentState!.validate()) {
                          allValid = false;
                        }
                      }

                      if (allValid) {
                        await _saveEditedGrades();
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text("Uspješno ste dodali novu ocjenu."),
                            backgroundColor: Colors.green,
                          ),
                        );
                        Navigator.pop(context, true);
                      } else {
                        ScaffoldMessenger.of(context).showSnackBar(
                          const SnackBar(
                            content: Text(
                                'Molimo ispravite greške u komentarima prije spremanja.'),
                            backgroundColor: Colors.red,
                          ),
                        );
                      }
                    },
                    backgroundColor: Colors.blue,
                  ),
                  const SizedBox(width: 16),
                ],
              ),
            ),
            floatingActionButtonLocation:
                FloatingActionButtonLocation.centerFloat,
          ),
        ),
      ),
    );
  }

  Widget _buildScreenHeader() {
    return Row(
      children: [
        Container(
          decoration: const BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(5),
              topLeft: Radius.circular(20),
              topRight: Radius.elliptical(5, 5),
              bottomRight: Radius.circular(30.0),
            ),
          ),
          padding: const EdgeInsets.all(16.0),
          child: const Text(
            "Editovanje ocjena",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ],
    );
  }

  Widget _buildGradeEditRow(Grade grade) {
    return Padding(
      padding: const EdgeInsets.only(right: 32, left: 32, top: 16),
      child: Card(
        margin: const EdgeInsets.only(bottom: 16),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Form(
            key: _formKeys[grade.ocjenaID],
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Datum: ${grade.datum?.toLocal().toString().split(' ')[0] ?? 'N/A'}',
                  style: const TextStyle(color: Colors.black),
                ),
                const SizedBox(height: 8),
                TextFormField(
                  initialValue: grade.komentar ?? '',
                  decoration: const InputDecoration(
                    labelText: 'Komentar:',
                  ),
                  onChanged: (newValue) {
                    setState(() {
                      grade.komentar = newValue;
                      _isDataChanged = true;
                    });
                  },
                  validator: _validateKomentar,
                ),
                const SizedBox(height: 8),
                DropdownButtonFormField<int>(
                  value:
                      _editedGrades[grade.ocjenaID] ?? grade.vrijednostOcjene,
                  items: [1, 2, 3, 4, 5].map((int value) {
                    return DropdownMenuItem<int>(
                      value: value,
                      child: Text(value.toString()),
                    );
                  }).toList(),
                  onChanged: (int? newValue) {
                    if (mounted) {
                      setState(() {
                        _editedGrades[grade.ocjenaID!] = newValue;
                        _isDataChanged = true;
                      });
                    }
                  },
                  decoration: const InputDecoration(
                    labelText: 'Ocjena:',
                  ),
                ),
                const SizedBox(height: 8),
                Align(
                  alignment: Alignment.centerRight,
                  child: ElevatedButton.icon(
                    onPressed: () {
                      _confirmDelete(grade);
                    },
                    icon: Tooltip(
                      message: "Brisanje ocjene",
                      child: const Icon(Icons.delete, color: Colors.white),
                    ),
                    label: const Text('Obriši'),
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.red,
                      foregroundColor: Colors.white,
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Future<void> _confirmDelete(Grade grade) async {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Potvrda brisanja'),
        content:
            const Text('Da li ste sigurni da želite da obrišete ovu ocjenu?'),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context, false),
            style: ElevatedButton.styleFrom(
                foregroundColor: Colors.black, backgroundColor: Colors.white),
            child: const Text('Odustani'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white, backgroundColor: Colors.red),
            child: const Text('Obriši'),
          ),
        ],
      ),
    );

    if (confirmDelete == true) {
      try {
        await _gradesProvider.delete(grade.ocjenaID!);
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text("Uspješno ste izbrisali ocjenu."),
            backgroundColor: Colors.green,
          ),
        );
        setState(() {
          widget.grades.removeWhere((g) => g.ocjenaID == grade.ocjenaID);
          _isDataChanged = true;
          Navigator.pop(context, true);
        });
      } catch (e) {
        print("Error deleting grade: $e");
      }
    }
  }

  Future<void> _saveEditedGrades() async {
    bool allValid = true;
    for (var key in _formKeys.values) {
      if (!key.currentState!.validate()) {
        allValid = false;
      }
    }

    if (!allValid) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content:
              Text('Molimo ispravite greške u komentarima prije spremanja.'),
          backgroundColor: Colors.red,
        ),
      );
      return;
    }

    try {
      for (var grade in widget.grades) {
        if (_editedGrades.containsKey(grade.ocjenaID) ||
            grade.komentar != null) {
          int? updatedValue = _editedGrades[grade.ocjenaID];
          if (updatedValue != null && updatedValue != grade.vrijednostOcjene) {
            Grade updatedGrade = Grade(
              grade.ocjenaID,
              updatedValue,
              DateTime.now(),
              grade.korisnikID,
              grade.predmetID,
              grade.komentar,
            );
            await _gradesProvider.Update(grade.ocjenaID!, updatedGrade);
            _isDataChanged = true;
          } else if (grade.komentar != null) {
            await _gradesProvider.Update(grade.ocjenaID!, grade);
          }
        }
      }
    } catch (e) {
      print("Error saving grades: $e");
    }
  }

  bool _containsNumbers(String input) {
    return input.contains(RegExp(r'[0-9]'));
  }

  String? _validateKomentar(String? value) {
    if (value == null || value.isEmpty) {
      return 'Komentar je obavezan i ne može biti prazan.';
    }

    if (_containsNumbers(value)) {
      return 'Komentar ne može sadržavati brojeve.';
    }

    if (!RegExp(r'^[A-ZŽĐŠĆČ]').hasMatch(value)) {
      return 'Komentar mora početi velikim slovom.';
    }

    if (value.length < 4) {
      return 'Komentar mora imati minimum 4 slova.';
    }

    final sentences = value.split('. ');
    for (var i = 0; i < sentences.length; i++) {
      var sentence = sentences[i].trim();

      if (sentence.isNotEmpty && !RegExp(r'^[A-ZŽĐŠĆČ]').hasMatch(sentence)) {
        return 'Svaka rečenica mora početi velikim slovom.';
      }

      if (i == sentences.length - 1 && !sentence.endsWith('.')) {
        return 'Komentar mora završiti sa tačkom.';
      }

      if (i < sentences.length - 1 && sentence.endsWith('.')) {
        return 'Samo zadnja rečenica može završavati sa tačkom.';
      }
    }

    return null;
  }
}
