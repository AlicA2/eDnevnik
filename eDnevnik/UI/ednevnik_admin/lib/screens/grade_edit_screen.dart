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

  bool _isDataChanged = false;

  @override
  void initState() {
    super.initState();
    _gradesProvider = context.read<GradeProvider>();
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
                      await _saveEditedGrades();
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(
                          content: Text("Uspješno ste dodali novu ocjenu."),
                          backgroundColor: Colors.green,
                        ),
                      );
                      Navigator.pop(context, true);
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
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                'Datum: ${grade.datum?.toLocal().toString().split(' ')[0] ?? 'N/A'}',
                style: const TextStyle(color: Colors.black),
              ),
              const SizedBox(height: 8),
              DropdownButtonFormField<int>(
                value: _editedGrades[grade.ocjenaID] ?? grade.vrijednostOcjene,
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
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text("Uspješno ste izbrisali ocjenu."),
                        backgroundColor: Colors.green,
                      ),
                    );
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
    try {
      for (var grade in widget.grades) {
        if (_editedGrades.containsKey(grade.ocjenaID)) {
          int? updatedValue = _editedGrades[grade.ocjenaID];
          if (updatedValue != null && updatedValue != grade.vrijednostOcjene) {
            Grade updatedGrade = Grade(
              grade.ocjenaID,
              updatedValue,
              DateTime.now(),
              grade.korisnikID,
              grade.predmetID,
            );
            await _gradesProvider.Update(grade.ocjenaID!, updatedGrade);
            _isDataChanged = true;
          }
        }
      }
    } catch (e) {
      print("Error saving grades: $e");
    }
  }
}
