import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/grade_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';

class StudentDetailScreen extends StatefulWidget {
  final int? departmentID;

  const StudentDetailScreen({Key? key, this.departmentID}) : super(key: key);

  @override
  State<StudentDetailScreen> createState() => _StudentDetailScreenState();
}

class _StudentDetailScreenState extends State<StudentDetailScreen> {
  List<User> _students = [];
  List<User> _studentss = [];
  bool _isLoading = true;

  List<School> _schools = [];
  School? _selectedSchool;

  List<Department> _departments = [];
  Department? _selectedDepartment;

  late UserProvider _userProvider;
  late SchoolProvider _schoolProvider;
  late DepartmentProvider _departmentProvider;

  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _fetchUsers();

    _fetchSchools();
  }

  Future<void> _fetchUsers() async {
  try {
    var usersResponse = await _userProvider.get(filter: {'UlogaID': 2});
    if (mounted) {
      setState(() {
        _studentss = usersResponse.result;

      });
    }
  } catch (e) {
    print('Error fetching users: $e');
  }
}


  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;

          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchDepartmentsAndInitialize(schoolID: _selectedSchool!.skolaID);
          } else {
            _isLoading = false;
          }
        });
      }
    } catch (e) {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _fetchDepartmentsAndInitialize({int? schoolID}) async {
    try {
      var allDepartments =
          await _departmentProvider.getDepartmentsWithStudents();
      List<Department> filteredDepartments = schoolID != null
          ? allDepartments.where((dept) => dept.skolaID == schoolID).toList()
          : allDepartments;

      setState(() {
        _departments = filteredDepartments;

        if (widget.departmentID != null) {
          _selectedDepartment = _departments.firstWhere(
            (dept) => dept.odjeljenjeID == widget.departmentID,
            orElse: () => _departments.isNotEmpty
                ? _departments.first
                : Department(0, 'Default', 0, 0),
          );
          _selectedSchool = _schools.firstWhere(
            (school) => school.skolaID == _selectedDepartment?.skolaID,
            orElse: () => _schools.isNotEmpty ? _schools.first : School(),
          );
          _students = _selectedDepartment?.ucenici ?? [];
        } else {
          _selectedDepartment = _departments.isNotEmpty
              ? _departments.first
              : Department(0, 'Default', 0, 0);
          _students = _selectedDepartment?.ucenici ?? [];
        }
        _isLoading = false;
      });
    } catch (e) {
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _confirmDelete(User student) async {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Potvrda brisanja'),
        content: Text(
            'Da li ste sigurni da želite da uklonite ovog učenika iz odjeljenja?'),
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
        if (_selectedDepartment != null && student.korisnikId != null) {
          await _departmentProvider.removeStudentFromDepartment(
            _selectedDepartment!.odjeljenjeID!,
            student.korisnikId!,
          );
          setState(() {
            _students.remove(student);
          });
          await _fetchDepartmentsAndInitialize(
              schoolID: _selectedSchool?.skolaID);
        }
      } on FormatException catch (e) {
        if (e.source.contains("Ne možete obrisati učenika koji ima ocjene.")) {
          _showErrorDialog('Ne možete obrisati učenika koji ima ocjene.');
        } else {
          _showErrorDialog('Došlo je do greške u formatu odgovora.');
        }
        print(e.toString());
      } on Exception catch (e) {
        _showErrorDialog('${e.toString()}');
        print(e.toString());
      } catch (e) {
        _showErrorDialog('Došlo je do neočekivane greške.');
      }
    }
  }

  void _showErrorDialog(String message) {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Greška'),
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
                SizedBox(height:16),
                _buildActionButton(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildActionButton() {
  return Padding(
    padding: const EdgeInsets.all(8.0),
    child: ElevatedButton(
      onPressed: () {
        _openDialog();
      },
      style: ElevatedButton.styleFrom(
        backgroundColor: Colors.blue,
        padding: EdgeInsets.symmetric(horizontal: 32, vertical: 16),
      ),
      child: Text("Dodaj učenika u odjeljenje", style: TextStyle(color: Colors.white)),
    ),
  );
}

void _openDialog() {
  Department? selectedDepartment;
  User? selectedStudent;
  List<User> availableStudents = [];

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return StatefulBuilder(
        builder: (context, setState) {
          List<Object?> assignedStudentIds = _departments
              .expand((department) => department.ucenici?.map((student) => student.korisnikId) ?? [])
              .toList();

           availableStudents = _studentss.where((student) => !assignedStudentIds.contains(student.korisnikId)).toList();

          return AlertDialog(
            title: Text('Dodaj učenika u odjeljenje'),
            content: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                DropdownButton<Department>(
                  value: selectedDepartment,
                  hint: Text('Odaberite odjeljenje'),
                  items: _departments.map((department) {
                    return DropdownMenuItem<Department>(
                      value: department,
                      child: Text(department.nazivOdjeljenja ?? "N/A"),
                    );
                  }).toList(),
                  onChanged: (Department? newValue) {
                    setState(() {
                      selectedDepartment = newValue;
                    });
                  },
                ),
                SizedBox(height: 16.0),
                DropdownButton<User>(
                  value: selectedStudent,
                  hint: Text('Odaberite učenika'),
                  items: availableStudents.map((student) {
                    return DropdownMenuItem<User>(
                      value: student,
                      child: Text('${student.ime} ${student.prezime}'),
                    );
                  }).toList(),
                  onChanged: (User? newValue) {
                    setState(() {
                      selectedStudent = newValue;
                    });
                  },
                ),
              ],
            ),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: Text('Odustani'),
              ),
              TextButton(
  onPressed: () async {
    if (selectedDepartment != null && selectedStudent != null) {
      try {
        await _departmentProvider.addStudentToDepartment(
          selectedDepartment!.odjeljenjeID!,
          selectedStudent!.korisnikId!,
        );

        _fetchDepartmentsAndInitialize(schoolID: _selectedSchool?.skolaID);

        Navigator.of(context).pop();

        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('${selectedStudent?.ime} ${selectedStudent?.prezime} je dodan u ${selectedDepartment?.nazivOdjeljenja}'))
        );
      } catch (e) {
        print('Error adding student to department: $e');
        showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: Text('Greška'),
            content: Text('Dodavanje učenika nije uspjelo.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          ),
        );
      }
    } else {
      if (selectedDepartment == null) {
        print('No department selected');
      }
      if (selectedStudent == null) {
        print('No student selected');
      }

      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Greška'),
          content: Text('Morate odabrati odjeljenje i učenika.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
    }
  },
  child: Text('Dodaj'),
),

            ],
          );
        },
      );
    },
  );
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
            "Učenici",
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
        SizedBox(width: 16.0),
        Expanded(
          child: _buildDepartmentDropdown(),
        ),
      ],
    );
  }

  Widget _buildSchoolDropdown() {
    return DropdownButton<School>(
      value: _selectedSchool,
      items: _schools.map((school) {
        return DropdownMenuItem<School>(
          value: school,
          child: Text(school.naziv ?? "N/A"),
        );
      }).toList(),
      onChanged: (School? newValue) {
        setState(() {
          _selectedSchool = newValue;
          _selectedDepartment = null;
          _students = [];
        });

        _fetchDepartmentsAndInitialize(schoolID: newValue?.skolaID);
      },
    );
  }

  Widget _buildDepartmentDropdown() {
    return DropdownButton<Department>(
      value: _selectedDepartment,
      items: _departments.map((department) {
        return DropdownMenuItem<Department>(
          value: department,
          child: Text(department.nazivOdjeljenja ?? "N/A"),
        );
      }).toList(),
      onChanged: (Department? newValue) {
        setState(() {
          _selectedDepartment = newValue;
          _students = newValue?.ucenici ?? [];
        });
      },
    );
  }

  Widget _buildLoading() {
    return Center(
      child: CircularProgressIndicator(),
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: DataTable(
        columns: const [
          DataColumn(
            label: Expanded(
              child: Text(
                "Ime i prezime učenika",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Odjeljenje",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Prikaži ocjene za učenika",
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
        ],
        rows: _students.map((student) {
          var department = _departments.firstWhere(
            (dept) => dept.ucenici?.contains(student) ?? false,
            orElse: () => Department(null, 'Unknown', null, null),
          );

          return DataRow(
            cells: [
              DataCell(Text("${student.ime} ${student.prezime}")),
              DataCell(Text(department.nazivOdjeljenja ?? "N/A")),
              DataCell(
                ElevatedButton(
                  onPressed: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => GradeDetailScreen(
                          userID: student.korisnikId,
                        ),
                      ),
                    );
                  },
                  style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.white,
                    backgroundColor: Colors.blue,
                  ),
                  child: Text("Prikaz ocjena"),
                ),
              ),
              DataCell(
                IconButton(
                  icon: Icon(Icons.delete, color: Colors.red),
                  onPressed: () {
                    _confirmDelete(student);
                  },
                ),
              ),
            ],
          );
        }).toList(),
      ),
    );
  }
}
