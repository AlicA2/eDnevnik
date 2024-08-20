import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/grade.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:ednevnik_admin/models/result.dart';

class GradeDetailScreen extends StatefulWidget {
  final int? userID;

  const GradeDetailScreen({Key? key, required this.userID}) : super(key: key);

  @override
  State<GradeDetailScreen> createState() => _GradeDetailScreenState();
}

class _GradeDetailScreenState extends State<GradeDetailScreen> {
  List<Grade> _grades = [];
  Map<int, Subject?> _subjects = {};
  List<Subject> _availableSubjects = [];
  Subject? _selectedSubject;
  bool _isLoading = true;
  String _userFullName = '';

  late UserProvider _userProvider;
  late GradeProvider _gradesProvider;
  late SubjectProvider _subjectProvider;
  late DepartmentProvider _departmentProvider;

  @override
  void initState() {
    super.initState();
    _gradesProvider = context.read<GradeProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _initializeData();
  }

  Future<void> _initializeData() async {
    if (mounted) {
      setState(() {
        _isLoading = true;
      });
    }
    try {
      SearchResult<Department> departmentResult =
          await _departmentProvider.get(filter: {'KorisnikID': widget.userID});
      Department department = departmentResult.result.first;
      int? skolaID = department.skolaID;

      SearchResult<Subject> subjectsResult =
          await _subjectProvider.get(filter: {'SkolaID': skolaID});
      _availableSubjects = subjectsResult.result;

      if (_availableSubjects.isNotEmpty) {
        _selectedSubject = null;
      }

      var data = await _gradesProvider.get(filter: {
        'KorisnikID': widget.userID,
      });
      if (mounted) {
        setState(() {
          _grades = data.result;
          _isLoading = false;
        });
      }

      var userDetails = await _userProvider.getById(widget.userID ?? 0);
      if (mounted) {
        setState(() {
          _userFullName = "${userDetails.ime} ${userDetails.prezime}";
        });
      }
      await _fetchSubjects();
    } catch (e) {
      if (mounted) {
        setState(() {
          _isLoading = false;
        });
      }
      print("Error initializing data: $e");
    }
  }

  Future<void> _fetchSubjects() async {
    for (var grade in _grades) {
      if (grade.predmetID != null) {
        try {
          var subjectResult = await _subjectProvider.get(filter: {
            'PredmetID': grade.predmetID!,
            'isOcjeneIncluded': true,
          });

          Subject? subject = subjectResult.result.isNotEmpty
              ? subjectResult.result.first
              : null;

          if (mounted) {
            setState(() {
              _subjects[grade.predmetID!] = subject;
            });
          }
        } catch (e) {
          print("Error fetching subject for predmetID ${grade.predmetID}: $e");
        }
      }
    }
  }

  void _filterGradesBySubject(Subject? subject) {
    if (mounted) {
      setState(() {
        _selectedSubject = subject;
      });
    }
  }

  String _getGradeValues(Subject? subject) {
    if (subject?.ocjene == null || subject!.ocjene!.isEmpty) {
      return "N/A";
    }

    var filteredOcjene = subject.ocjene!
        .where((ocjena) => ocjena.korisnikID == widget.userID)
        .map((grade) => grade.vrijednostOcjene.toString());

    return filteredOcjene.isNotEmpty ? filteredOcjene.join(", ") : "N/A";
  }

  Future<void> _addGradeDialog(BuildContext context) async {
    Subject? selectedSubject =
        _availableSubjects.isNotEmpty ? _availableSubjects.first : null;
    int selectedGradeValue = 1;

    return showDialog<void>(
      context: context,
      barrierDismissible: false,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Dodaj ocjenu za učenika'),
          content: SingleChildScrollView(
            child: ListBody(
              children: <Widget>[
                TextFormField(
                  initialValue: _userFullName,
                  enabled: false,
                  decoration: InputDecoration(
                    labelText: 'Učenik',
                  ),
                ),
                SizedBox(height: 16),
                DropdownButtonFormField<Subject?>(
                  value: selectedSubject,
                  items: _availableSubjects.map((subject) {
                    return DropdownMenuItem<Subject?>(
                      value: subject,
                      child: Text(subject.naziv ?? ""),
                    );
                  }).toList(),
                  onChanged: (Subject? newValue) {
                    if (mounted) {
                      setState(() {
                        selectedSubject = newValue;
                      });
                    }
                  },
                  decoration: InputDecoration(
                    labelText: 'Predmet',
                  ),
                ),
                SizedBox(height: 16),
                DropdownButtonFormField<int>(
                  value: selectedGradeValue,
                  items: [1, 2, 3, 4, 5].map((int value) {
                    return DropdownMenuItem<int>(
                      value: value,
                      child: Text(value.toString()),
                    );
                  }).toList(),
                  onChanged: (int? newValue) {
                    if (mounted) {
                      setState(() {
                        selectedGradeValue = newValue!;
                      });
                    }
                  },
                  decoration: InputDecoration(
                    labelText: 'Ocjena',
                  ),
                ),
              ],
            ),
          ),
          actions: <Widget>[
            TextButton(
              child: Text('Odustani'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: Text('Dodaj'),
              onPressed: () async {
                if (selectedSubject != null) {
                  Grade newGrade = Grade(
                    null,
                    selectedGradeValue,
                    DateTime.now(),
                    widget.userID,
                    selectedSubject!.predmetID,
                  );

                  try {
                    bool success = await _subjectProvider.addOcjena(
                        selectedSubject!.predmetID ?? 0, newGrade);
                    if (success) {
                      _initializeData();
                      Navigator.of(context).pop();
                    }
                  } catch (e) {
                    print("Error adding grade: $e");
                  }
                } else {
                  print("No subject selected. Grade cannot be added.");
                }
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20.0),
            ),
            child: Column(
              children: [
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                Expanded(
                  child: _isLoading ? _buildLoading() : _buildDataListView(),
                ),
                SizedBox(height: 16.0),
                _buildActionButtons(),
                SizedBox(
                  height: 16,
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildActionButtons() {
    return Row(mainAxisAlignment: MainAxisAlignment.end, children: [
      SizedBox(
        width: 16,
      ),
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
      Spacer(),
      ElevatedButton(
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.blue,
        ),
        onPressed: () {
          _addGradeDialog(context);
        },
        child: Text('Dodaj ocjenu'),
      ),
      SizedBox(
        width: 16,
      )
    ]);
  }

  Widget _buildScreenHeader() {
    return Row(
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
            "Ocjene za $_userFullName",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 16.0),
        Expanded(
          child: _buildSubjectDropdown(),
        )
      ],
    );
  }

  Widget _buildSubjectDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 200,
          child: DropdownButton<Subject?>(
            hint: Text("Filtriraj po predmetu"),
            value: _selectedSubject,
            items: [null, ..._availableSubjects].map((subject) {
              return DropdownMenuItem<Subject?>(
                value: subject,
                child: Text(subject?.naziv ?? "Svi Predmeti"),
              );
            }).toList(),
            onChanged: (Subject? newValue) {
              if (mounted) {
                setState(() {
                  _selectedSubject = newValue;
                });
              }
              _filterGradesBySubject(newValue);
            },
          ),
        ),
      ],
    );
  }

  Widget _buildLoading() {
    return Center(
      child: CircularProgressIndicator(),
    );
  }

  Widget _buildDataListView() {
    final Map<int, List<Grade>> gradesBySubject = {};
    for (var grade in _grades) {
      if (gradesBySubject.containsKey(grade.predmetID)) {
        gradesBySubject[grade.predmetID!]!.add(grade);
      } else {
        gradesBySubject[grade.predmetID!] = [grade];
      }
    }

    List<DataRow> dataRows = [];
    gradesBySubject.forEach((predmetID, grades) {
      if (_selectedSubject == null ||
          _selectedSubject!.predmetID == predmetID) {
        Subject? subject = _subjects[predmetID];
        String zakljucnaOcjena = subject?.zakljucnaOcjena?.toString() ?? "N/A";

        dataRows.add(DataRow(
          cells: [
            DataCell(Text(subject?.naziv ?? "N/A")),
            DataCell(Text(zakljucnaOcjena)),
            DataCell(Text(_getGradeValues(subject))),
            DataCell(
              IconButton(
                icon: Icon(Icons.info_outline),
                onPressed: () {
                  _showGradeDetailsDialog(context, subject, grades);
                },
              ),
            ),
            DataCell(
              IconButton(
                icon: Icon(Icons.edit),
                onPressed: () {
                  _showEditGradeDialog(context, grades.first);
                },
              ),
            ),
          ],
        ));
      }
    });

    return SingleChildScrollView(
      child: DataTable(
        columns: const [
          DataColumn(
            label: Expanded(
              child: Text(
                "Naziv Predmeta",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Zaključna Ocjena",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Sve Ocjene",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Edit",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
        ],
        rows: dataRows,
      ),
    );
  }

  Future<void> _showEditGradeDialog(BuildContext context, Grade grade) async {
  int? selectedGradeValue = grade.vrijednostOcjene;
  Subject? selectedSubject = _subjects[grade.predmetID];

  return showDialog<void>(
    context: context,
    barrierDismissible: false,
    builder: (BuildContext context) {
      return AlertDialog(
        title: Text('Uredi ocjenu'),
        content: SingleChildScrollView(
          child: ListBody(
            children: <Widget>[
              TextFormField(
                initialValue: _userFullName,
                enabled: false,
                decoration: InputDecoration(
                  labelText: 'Učenik',
                ),
              ),
              SizedBox(height: 16),
              DropdownButtonFormField<int>(
                value: selectedGradeValue,
                items: [1, 2, 3, 4, 5].map((int value) {
                  return DropdownMenuItem<int>(
                    value: value,
                    child: Text(value.toString()),
                  );
                }).toList(),
                onChanged: (int? newValue) {
                  if (mounted) {
                    setState(() {
                      selectedGradeValue = newValue!;
                    });
                  }
                },
                decoration: InputDecoration(
                  labelText: 'Ocjena',
                ),
              ),
              SizedBox(height: 16),
              Text("Datum: ${grade.datum?.toLocal().toString().split(' ')[0] ?? 'N/A'}"),
              SizedBox(height: 16),
              Text("PredmetID: ${grade.predmetID}"),
            ],
          ),
        ),
        actions: <Widget>[
          TextButton(
            child: Text('Obriši'),
            onPressed: () async {
              try {
                await _gradesProvider.delete(grade.ocjenaID!);
                Navigator.of(context).pop();
                _initializeData();
              } catch (e) {
                print("Error deleting grade: $e");
              }
            },
          ),
          TextButton(
            child: Text('Odustani'),
            onPressed: () {
              Navigator.of(context).pop();
            },
          ),
          TextButton(
            child: Text('Spremi'),
            onPressed: () async {
              try {
                Grade updatedGrade = Grade(
                  grade.ocjenaID,
                  selectedGradeValue,
                  grade.datum,
                  grade.korisnikID,
                  grade.predmetID,
                );

                await _gradesProvider.Update(grade.ocjenaID!, updatedGrade);
                Navigator.of(context).pop();
                _initializeData();
              } catch (e) {
                print("Error updating grade: $e");
              }
            },
          ),
        ],
      );
    },
  );
}


  void _showGradeDetailsDialog(
      BuildContext context, Subject? subject, List<Grade> grades) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text(subject?.naziv ?? "Detalji Ocjena"),
          content: SingleChildScrollView(
            child: ListBody(
              children: grades.map((grade) {
                String datum =
                    grade.datum?.toLocal().toString().split(' ')[0] ?? "N/A";
                String vrijednostOcjene = grade.vrijednostOcjene.toString();
                return ListTile(
                  title: Text("Datum: $datum"),
                  subtitle: Text("Ocjena: $vrijednostOcjene"),
                );
              }).toList(),
            ),
          ),
          actions: <Widget>[
            TextButton(
              child: Text('Zatvori'),
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
