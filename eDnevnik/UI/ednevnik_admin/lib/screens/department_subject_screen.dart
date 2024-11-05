import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/department_subject.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class DepartmentSubjectDetailScreen extends StatefulWidget {
  final int? departmentID;

  const DepartmentSubjectDetailScreen({Key? key, this.departmentID})
      : super(key: key);

  @override
  _DepartmentSubjectDetailScreenState createState() =>
      _DepartmentSubjectDetailScreenState();
}

class _DepartmentSubjectDetailScreenState
    extends State<DepartmentSubjectDetailScreen> {
  late DepartmentProvider _departmentProvider;
  late DepartmentSubjectProvider _departmentSubjectProvider;
  late SubjectProvider _subjectProvider;

  Department? _selectedDepartment;
  List<DepartmentSubject> _departmentSubjects = [];
  List<Subject> _subjects = [];
  List<Subject> _availableSubjects = [];

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _subjectProvider = context.read<SubjectProvider>();

    _fetchDepartments();
  }

  Future<void> _fetchDepartments() async {
    if (widget.departmentID != null) {
      var departments = await _departmentProvider.get();
      setState(() {
        _selectedDepartment = departments.result.firstWhere(
          (dept) => dept.odjeljenjeID == widget.departmentID,
          orElse: () => Department(0, 'Unknown', 0, 0),
        );
      });

      if (_selectedDepartment != null) {
        _fetchDepartmentSubjects();
      }
    }
  }

  Future<void> _fetchDepartmentSubjects() async {
    if (_selectedDepartment != null) {
      var departmentSubjectsData =
          await _departmentSubjectProvider.get(filter: {
        'OdjeljenjeID': _selectedDepartment!.odjeljenjeID,
      });

      setState(() {
        _departmentSubjects = departmentSubjectsData.result;
      });

      await _fetchSubjectsForDepartmentSubjects();
      await _fetchAvailableSubjects();
    }
  }

  Future<void> _fetchSubjectsForDepartmentSubjects() async {
    List<int> subjectIDs =
        _departmentSubjects.map((ds) => ds.predmetID!).toList();

    for (int subjectID in subjectIDs) {
      var subject = await _subjectProvider.getById(subjectID);
      setState(() {
        _subjects.add(subject);
      });
    }
  }

  Future<void> _fetchAvailableSubjects() async {
    int? skolaID = _selectedDepartment?.skolaID;

    var allSubjects = await _subjectProvider.get();

    setState(() {
      _availableSubjects = allSubjects.result.where((subject) {
        return subject.skolaID == skolaID &&
            !_departmentSubjects.any((ds) => ds.predmetID == subject.predmetID);
      }).toList();
    });
  }

  void _showAddSubjectDialog() {
  final _formKey = GlobalKey<FormBuilderState>();
  showDialog(
    context: context,
    builder: (BuildContext context) {
      Subject? selectedSubject;

      return StatefulBuilder(
        builder: (context, setState) {
          return AlertDialog(
            title: Text("Dodaj predmet za odjeljenje"),
            content: FormBuilder(
              key: _formKey,
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  TextField(
                    decoration: InputDecoration(
                      labelText: "Naziv odjeljenja",
                    ),
                    controller: TextEditingController(
                      text: _selectedDepartment!.nazivOdjeljenja ?? "Unknown",
                    ),
                    enabled: false,
                  ),
                  SizedBox(height: 16),
                  FormBuilderDropdown<Subject>(
                    name: 'subject',
                    decoration: InputDecoration(
                      labelText: "Izaberite predmet",
                      border: OutlineInputBorder(),
                    ),
                    items: _availableSubjects.map((subject) {
                      return DropdownMenuItem<Subject>(
                        value: subject,
                        child: Text(subject.naziv ?? "N/A"),
                      );
                    }).toList(),
                    validator: FormBuilderValidators.required(
                      errorText: "Ovo polje je obavezno",
                    ),
                    onChanged: (Subject? newValue) {
                      setState(() {
                        selectedSubject = newValue;
                      });
                    },
                  ),
                ],
              ),
            ),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                style:
                    ElevatedButton.styleFrom(foregroundColor: Colors.black),
                child: Text("Odustani"),
              ),
              ElevatedButton(
                onPressed: () async {
                  if (_formKey.currentState?.saveAndValidate() ?? false) {
                    var newDepartmentSubject = DepartmentSubject(
                      null,
                      selectedSubject!.predmetID,
                      _selectedDepartment!.odjeljenjeID,
                    );

                    await _departmentSubjectProvider.Insert(newDepartmentSubject);
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text("Uspješno ste dodali predmet za odjeljenje."),
                        backgroundColor: Colors.green,
                      ),
                    );

                    setState(() {
                      _subjects.clear();
                      _departmentSubjects.clear();
                    });

                    await _fetchDepartmentSubjects();
                    Navigator.of(context).pop();
                  }
                },
                style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.white,
                    backgroundColor: Colors.green),
                child: Text("Dodaj"),
              ),
            ],
          );
        },
      );
    },
  );
}

  void _showDeleteConfirmationDialog(Subject subject) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Brisanje predmeta"),
          content: Text("Da li ste sigurni u brisanje predmeta iz odjeljenja?"),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
              child: Text("Odustani"),
            ),
            ElevatedButton(
              onPressed: () async {
                try {
                  await _deleteDepartmentSubject(subject);
                  Navigator.of(context).pop();
                } catch (error) {
                  Navigator.of(context).pop();
                  _showErrorDialog(
                      "Ne možete obrisati predmeta za odjeljenja gdje imate održane časove!");
                }
              },
              style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.red, foregroundColor: Colors.white),
              child: Text("Obriši"),
            ),
          ],
        );
      },
    );
  }

  Future<void> _deleteDepartmentSubject(Subject subject) async {
    DepartmentSubject? departmentSubjectToDelete;
    try {
      departmentSubjectToDelete = _departmentSubjects.firstWhere(
        (ds) => ds.predmetID == subject.predmetID,
      );
    } catch (e) {
      departmentSubjectToDelete = null;
    }

    if (departmentSubjectToDelete != null &&
        departmentSubjectToDelete.odjeljenjePredmetID != null) {
      try {
        await _departmentSubjectProvider
            .delete(departmentSubjectToDelete.odjeljenjePredmetID!);
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text("Uspješno ste izbrisali predmet iz odjeljenja."),
            backgroundColor: Colors.green,
          ),
        );

        setState(() {
          _subjects.remove(subject);
          _departmentSubjects.remove(departmentSubjectToDelete);
        });

        await _fetchAvailableSubjects();
      } catch (error) {
        throw Exception("Error deleting subject");
      }
    } else {
      throw Exception("Subject not found or cannot be deleted");
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Greška"),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("OK"),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
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
                _buildScreenName(),
                const SizedBox(height: 16.0),
                _buildCenterText(),
                const SizedBox(height: 16.0),
                Expanded(child: _buildSubjectCards()),
                _buildActionButtons(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenName() {
    return Align(
      alignment: Alignment.centerLeft,
      child: Row(
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
            child: Text(
              _selectedDepartment != null
                  ? "Predmeti za odjeljenje: ${_selectedDepartment!.nazivOdjeljenja}"
                  : "Predmeti odjeljenja",
              style: const TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildCenterText() {
    return Center(
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16.0),
        child: Text(
          "Na ovom ekranu morate dodijeliti predmete koje će odjeljenje imati za nastavu ove školske godine",
          style: TextStyle(
            color: Colors.grey[700],
            fontSize: 16,
            fontWeight: FontWeight.w500,
            fontStyle: FontStyle.italic,
          ),
          textAlign: TextAlign.center,
        ),
      ),
    );
  }

  Widget _buildSubjectCards() {
    return ListView.builder(
      itemCount: _subjects.length,
      itemBuilder: (context, index) {
        final subject = _subjects[index];
        return Card(
          margin: const EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(10.0),
          ),
          child: ListTile(
            title: Text(subject.naziv ?? "N/A"),
            trailing: Tooltip(
              message: "Brisanje predmeta iz odjeljenja",
              child: IconButton(
                icon: Icon(Icons.delete, color: Colors.red),
                onPressed: () => _showDeleteConfirmationDialog(subject),
              ),
            ),
          ),
        );
      },
    );
  }

  Widget _buildActionButtons() {
    return Padding(
      padding: const EdgeInsets.only(right: 20.0, bottom: 20.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            children: [
              SizedBox(width: 16.0),
              ElevatedButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white,
                  backgroundColor: Colors.blue,
                  padding:
                      EdgeInsets.symmetric(horizontal: 16.0, vertical: 12.0),
                ),
                child: Row(
                  children: [
                    Icon(Icons.arrow_back, color: Colors.white),
                    SizedBox(width: 8.0),
                    Text("Nazad"),
                  ],
                ),
              ),
            ],
          ),
          ElevatedButton(
            onPressed: _showAddSubjectDialog,
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
              padding: EdgeInsets.symmetric(horizontal: 16.0, vertical: 12.0),
            ),
            child: Text("Dodaj predmete za odjeljenje"),
          ),
        ],
      ),
    );
  }
}
