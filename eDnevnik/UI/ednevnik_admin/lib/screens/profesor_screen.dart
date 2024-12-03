import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/providers/user_roles_provider.dart';
import 'package:ednevnik_admin/screens/grade_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';

class ProfesorDetailScreen extends StatefulWidget {

  const ProfesorDetailScreen({Key? key}) : super(key: key);

  @override
  State<ProfesorDetailScreen> createState() => _ProfesorDetailScreenState();
}

class _ProfesorDetailScreenState extends State<ProfesorDetailScreen> {
  List<User> _students = [];
  List<User> _studentss = [];
  List<User> _studentsForDialog = [];
  List<User> _allUsers = [];
  bool _isLoading = true;

  List<School> _schools = [];
  School? _selectedSchool;

  List<Department> _departments = [];
  Department? _selectedDepartment;

  late UserProvider _userProvider;
  late SchoolProvider _schoolProvider;
  late DepartmentProvider _departmentProvider;

  bool _showUnassignedProfessors = false;

  @override
  void initState() {
    super.initState();
    _selectedSchool = null;
    _userProvider = context.read<UserProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    // _fetchUsers();
    _fetchSchools();
    // _fetchUsersForDialog();
    _fetchDepartmentsAndInitialize();
  }

  Future<void> _fetchUsers() async {
    try {
      var usersResponse = await _userProvider.get(filter: {'UlogaID': 1});
      if (mounted) {
        setState(() {
          _studentss = usersResponse.result;
          _allUsers = usersResponse.result;
        });
      }
    } catch (e) {
      print('Error fetching users: $e');
    }
  }

  Future<void> _fetchUsersForDialog() async {
    try {
      var usersResponse = await _userProvider.get();
      if (mounted) {
        setState(() {
          _studentsForDialog = usersResponse.result;
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
          _isLoading = false;
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
    setState(() {
      _isLoading = true;
    });

    if (schoolID == null) {
      var allDepartmentsResponse = await _departmentProvider.get();
      List<Department> combinedDepartments = allDepartmentsResponse.result;

      var allUsersResponse = await _userProvider.get();
      List<User> allUsers = allUsersResponse.result;

      List<User> filteredUsers = allUsers.where((user) {
        return user.korisniciUloge?.any((role) => role.ulogaID == 1) ?? false;
      }).toList();

      setState(() {
        _departments = combinedDepartments;
        _students = filteredUsers;
        _allUsers = allUsers;
        _isLoading = false;
      });
    } else {
      var departmentsResponse = await _departmentProvider.get(filter: {'SkolaID': schoolID});
      List<Department> filteredDepartments = departmentsResponse.result;

      List<int?> razrednikIDs = filteredDepartments.map((dept) => dept.razrednikID).toList();

      var allUsersResponse = await _userProvider.get();
      List<User> filteredUsers = allUsersResponse.result
          .where((user) => razrednikIDs.contains(user.korisnikId))
          .toList();

      setState(() {
        _departments = filteredDepartments;
        _students = filteredUsers;
        _allUsers = allUsersResponse.result;
        _isLoading = false;
      });
    }
  } catch (e) {
    setState(() {
      _isLoading = false;
    });
    print('Error fetching departments and users: $e');
  }
}


void _toggleShowUnassignedProfessors(bool value) async {
  setState(() {
    _showUnassignedProfessors = value;
    _isLoading = true;
  });

  if (value) {
    try {
      var allUsersResponse = await _userProvider.get(filter: {'isUlogeIncluded': true});
      var departmentsResponse = await _departmentProvider.get();

      List<int?> mentionedRazrednikIDs = departmentsResponse.result
          .map((dept) => dept.razrednikID)
          .where((id) => id != null)
          .toList();

      List<User> unassignedUsers = allUsersResponse.result.where((user) {
        bool isRazrednik = mentionedRazrednikIDs.contains(user.korisnikId);
        bool hasOdjeljenje = user.odjeljenjeID != null;

        bool isCorrectRole = user.korisniciUloge?.any((role) => role.ulogaID == 1) ?? false;

        return !isRazrednik && !hasOdjeljenje && isCorrectRole;
      }).toList();

      setState(() {
        _students = unassignedUsers;
        _isLoading = false;
      });
    } catch (e) {
      print('Error fetching unassigned professors: $e');
      setState(() {
        _isLoading = false;
      });
    }
  } else {
    await _fetchDepartmentsAndInitialize(schoolID: _selectedSchool?.skolaID);
  }
}




  Future<void> _confirmDelete(User profesor) async {
    bool? confirmDelete = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Potvrda brisanja'),
        content: Text(
            'Da li ste sigurni da želite da uklonite ovog profesora iz škole?'),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context, false),
            style: ElevatedButton.styleFrom(foregroundColor: Colors.black),
            child: Text('Odustani'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.red,
            ),
            child: Text('Obriši'),
          ),
        ],
      ),
    );

    if (confirmDelete == true) {
      try {
        if (_selectedDepartment != null && profesor.korisnikId != null) {
          await _departmentProvider.removeStudentFromDepartment(
            _selectedDepartment!.odjeljenjeID!,
            profesor.korisnikId!,
          );
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text("Uspješno ste izbrisali profesora iz škole."),
              backgroundColor: Colors.green,
            ),
          );
          setState(() {
            _students.remove(profesor);
          });
          await _fetchDepartmentsAndInitialize(
              schoolID: _selectedSchool?.skolaID);
        }
      } on FormatException catch (e) {
        if (e.source.contains("Ne možete obrisati profesor koji predaju u odjeljenju.")) {
          _showErrorDialog('Ne možete obrisati profesor koji predaju u odjeljenju.');
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
            style: ElevatedButton.styleFrom(
                backgroundColor: Colors.white, foregroundColor: Colors.black),
            child: Text('OK'),
          ),
        ],
      ),
    );
  }

  Widget _buildUnassignedCheckbox() {
  return Row(
    children: [
      Checkbox(
        value: _showUnassignedProfessors,
        onChanged: (bool? value) {
          if (value != null) {
            _toggleShowUnassignedProfessors(value);
          }
        },
      ),
      Text("Slobodni profesori"),
    ],
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
                if (_selectedSchool == null) _buildUnassignedCheckbox(),
                SizedBox(height: 16.0),
                Expanded(
                  child: _isLoading ? _buildLoading() : _buildDataListView(),
                ),
              ],
            ),
          ),
        ),
      ),
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
            "Profesori",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 32.0),
        Expanded(
          child: _buildSchoolDropdown(),
        ),
        
      ],
    );
  }

  Widget _buildSchoolDropdown() {
  return DropdownButton<School?>(
    value: _selectedSchool,
    items: [
      DropdownMenuItem<School?>(
        value: null,
        child: Text("Svi profesori"),
      ),
      ..._schools.map((school) {
        return DropdownMenuItem<School?>(
          value: school,
          child: Text(school.naziv ?? "N/A"),
        );
      }).toList(),
    ],
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
              "Ime i prezime profesora",
              style: TextStyle(fontStyle: FontStyle.italic),
            ),
          ),
        ),
        DataColumn(
          label: Expanded(
            child: Text(
              "Razrednik u odjeljenju",
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
      rows: _students.map((profesor) {
        Department? assignedDepartment = _departments.firstWhere(
          (dept) => dept.razrednikID == profesor.korisnikId,
          orElse: () => Department(null,null,null,null),
        );

        String departmentStatus;
        if (assignedDepartment != null && assignedDepartment.nazivOdjeljenja != null) {
          departmentStatus = assignedDepartment.nazivOdjeljenja!;
        } else {
          departmentStatus = "Nije razrednik";
        }

        return DataRow(
          cells: [
            DataCell(Text("${profesor.ime} ${profesor.prezime}")),
            DataCell(
              Text(
                departmentStatus,
                style: TextStyle(
                  color: assignedDepartment != null ? Colors.black : Colors.red,
                ),
              ),
            ),
            DataCell(
              Tooltip(
                message: "Brisanje profesora",
                child: IconButton(
                  icon: Icon(Icons.delete, color: Colors.red),
                  onPressed: () {
                    _confirmDelete(profesor);
                  },
                ),
              ),
            ),
          ],
        );
      }).toList(),
    ),
  );
}


}
