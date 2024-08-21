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
            floatingActionButton: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const SizedBox(width: 16),
                FloatingActionButton(
                  heroTag: 'backButton',
                  onPressed: () {
                    Navigator.pop(context, _isDataChanged);
                  },
                  backgroundColor: Colors.blue,
                  child: const Icon(Icons.arrow_back),
                ),
                const Spacer(),
                FloatingActionButton(
                  heroTag: 'saveButton',
                  child: const Icon(Icons.save),
                  onPressed: () async {
                    await _saveEditedGrades();
                    Navigator.pop(context, true);
                  },
                  backgroundColor: Colors.blue,
                ),
                const SizedBox(width: 16),
              ],
            ),
            floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
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
    return Card(
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
                onPressed: () => _confirmDelete(grade),
                icon: const Icon(Icons.delete, color: Colors.white),
                label: const Text('Obriši'),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.red,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _confirmDelete(Grade grade) async {
  bool? confirmDelete = await showDialog<bool>(
    context: context,
    builder: (context) => AlertDialog(
      title: const Text('Potvrda brisanja'),
      content: const Text('Da li ste sigurni da želite da obrišete ovu ocjenu?'),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context, false),
          child: const Text('Odustani'),
        ),
        TextButton(
          onPressed: () => Navigator.pop(context, true),
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
