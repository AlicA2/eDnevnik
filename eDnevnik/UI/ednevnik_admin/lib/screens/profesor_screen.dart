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
  final int? departmentID;

  const ProfesorDetailScreen({Key? key, this.departmentID}) : super(key: key);

  @override
  State<ProfesorDetailScreen> createState() => _ProfesorDetailScreenState();
}

class _ProfesorDetailScreenState extends State<ProfesorDetailScreen> {
  List<User> _students = [];
  List<User> _studentss = [];
  List<User> _studentsForDialog = [];
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
    _fetchUsersForDialog();
  }

  Future<void> _fetchUsers() async {
    try {
      var usersResponse = await _userProvider.get(filter: {'UlogaID': 1});
      if (mounted) {
        setState(() {
          _studentss = usersResponse.result;
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
        SizedBox(width: 32.0),
        Padding(
          padding: const EdgeInsets.only(left: 16.0, right: 16.0),
          child: ElevatedButton(
              onPressed: () => _showAddProfesorDialog(context),
              child: Text("Dodaj novog profesora"),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white, backgroundColor: Colors.blue)),
        ),
      ],
    );
  }

  void _showAddProfesorDialog(BuildContext context) {
    showDialog(
      context: context,
      builder: (context) {
        final _formKey = GlobalKey<FormState>();
        final _nameController = TextEditingController();
        final _surnameController = TextEditingController();
        final _emailController = TextEditingController();
        final _phoneController = TextEditingController();
        final _usernameController = TextEditingController();
        final _passwordController = TextEditingController();
        final _passwordConfirmController = TextEditingController();
        final userProvider = context.read<UserProvider>();
        final userRolesProvider = context.read<UserRolesProvider>();


        bool _isDuplicateUsername(String username) {
          return _studentsForDialog
              .any((student) => student.korisnickoIme == username);
        }

        bool _isDuplicatePhone(String phone) {
          return _studentsForDialog.any((student) => student.telefon == phone);
        }

        bool _isDuplicateEmail(String email) {
          return _studentsForDialog.any((student) => student.email == email);
        }

        String? _validateName(String? value) {
          final regex = RegExp(r'^[A-ZŠĐČĆŽ][a-zšđčćž]*$');
          if (value == null || value.isEmpty) {
            return "Polje je obavezno";
          }
          if (!regex.hasMatch(value)) {
            return "Morate početi ime velikim slovom, a ostala slova moraju biti mala";
          }
          if (value.length < 3) {
            return "Polje mora imati najmanje 3 karaktera";
          }
          return null;
        }

        String? _validateSurname(String? value) {
          final regex = RegExp(r'^[A-ZŠĐČĆŽ][a-zšđčćž]*$');
          if (value == null || value.isEmpty) {
            return "Polje je obavezno";
          }
          if (!regex.hasMatch(value)) {
            return "Morate početi prezime velikim slovom, a ostala slova moraju biti mala";
          }
          if (value.length < 3) {
            return "Polje mora imati najmanje 3 karaktera";
          }
          return null;
        }

        String? _validateEmail(String? value) {
          if (value == null || value.isEmpty) {
            return "Email je obavezan.";
          }
          final emailRegex = RegExp(
              r'^[a-zA-Z0-9]+\.[a-zA-Z0-9]+@(gmail|outlook|hotmail)\.com$');
          if (!emailRegex.hasMatch(value)) {
            return "Email mora biti u formatu ime.prezime@gmail.com, outlook.com ili hotmail.com.";
          }
          if (_isDuplicateEmail(value)) {
            return "Ovaj email već postoji";
          }
          return null;
        }

        String? _validatePhone(String? value) {
          final phoneRegex = RegExp(r'^\d{3} \d{3} \d{3}$');
          if (value == null || value.isEmpty) {
            return "Unesite broj telefona";
          }
          if (!phoneRegex.hasMatch(value)) {
            return "Telefon mora biti u formatu 000 000 000";
          }
          if (_isDuplicatePhone(value)) {
            return "Ovaj telefon se već koristi";
          }
          return null;
        }

        String? _validateUsername(String? value) {
          final regex = RegExp(r'^[a-zšđčćž]+(\d{1,2})?$');
          if (value == null || value.isEmpty) {
            return "Polje je obavezno";
          }
          if (!regex.hasMatch(value)) {
            return "Korisničko ime mora sadržati samo mala slova i opcionalno jednocifreni ili dvocifreni broj na kraju.";
          }
          if (value.length < 3) {
            return "Polje mora imati najmanje 3 karaktera";
          }
          if (_isDuplicateUsername(value)) {
            return "Korisničko ime već postoji. Opcionalno možete dodati jednocifreni ili dvocifreni broj na kraju.";
          }
          return null;
        }

        String? _validatePassword(String? value) {
          if (value == null || value.isEmpty) {
            return "Polje je obavezno.";
          }
          if (value.length < 6) {
            return "Minimalno 6 karaktera.";
          }
          return null;
        }

        String? _validateConfirmPassword(String? value) {
          if (value == null || value != _passwordController.text) {
            return "Lozinke se ne podudaraju";
          }
          return null;
        }

        return AlertDialog(
          title: Text("Dodaj učenika/cu"),
          content: SizedBox(
            width: 600,
            height: 350,
            child: Form(
              key: _formKey,
              child: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Row(
                      children: [
                        Expanded(
                          child: TextFormField(
                              controller: _nameController,
                              decoration: InputDecoration(
                                  labelText: "Ime", errorMaxLines: 2),
                              validator: _validateName),
                        ),
                        SizedBox(width: 35.0),
                        Expanded(
                          child: TextFormField(
                            controller: _surnameController,
                            decoration: InputDecoration(
                                labelText: "Prezime", errorMaxLines: 2),
                            validator: _validateSurname,
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      controller: _emailController,
                      decoration: InputDecoration(labelText: "Email"),
                      validator: _validateEmail,
                    ),
                    SizedBox(height: 16.0),
                    Row(
                      children: [
                        Expanded(
                          child: TextFormField(
                            controller: _phoneController,
                            decoration: InputDecoration(labelText: "Telefon"),
                            validator: _validatePhone,
                          ),
                        ),
                        SizedBox(width: 35.0),
                        Expanded(
                          child: TextFormField(
                            controller: _usernameController,
                            decoration: InputDecoration(
                                labelText: "Korisničko ime", errorMaxLines: 3),
                            validator: _validateUsername,
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      controller: _passwordController,
                      decoration: InputDecoration(labelText: "Lozinka"),
                      obscureText: true,
                      validator: _validatePassword,
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      controller: _passwordConfirmController,
                      decoration: InputDecoration(labelText: "Potvrda lozinke"),
                      obscureText: true,
                      validator: _validateConfirmPassword,
                    ),
                  ],
                ),
              ),
            ),
          ),
          actions: [
            TextButton(
                onPressed: () => Navigator.of(context).pop(),
                child: Text("Otkaži"),
                style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.black,
                    backgroundColor: Colors.white)),
            SizedBox(width: 8.0),
            ElevatedButton(
              onPressed: () async {
                if (_formKey.currentState?.validate() ?? false) {
                  try {
                    var newUser = {
                      'Ime': _nameController.text.trim(),
                      'Prezime': _surnameController.text.trim(),
                      'Email': _emailController.text.trim(),
                      'Telefon': _phoneController.text.trim(),
                      'KorisnickoIme': _usernameController.text.trim(),
                      'Password': _passwordController.text.trim(),
                      'PasswordPotvrda': _passwordConfirmController.text.trim(),
                    };

                    var addedUser = await userProvider.Insert(newUser);

                    var newRoleAssignment = {
                    'KorisnikID': addedUser.korisnikId,
                    'UlogaID': 1,
                    'DatumIzmjene': DateTime.now().toIso8601String(),
                  };

                  try {
                    await userRolesProvider.Insert(newRoleAssignment);
                  } catch (e) {
                    print("Error inserting role assignment: $e");
                  }

                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text("Profesor uspješno dodat!"),
                        backgroundColor: Colors.green,
                      ),
                    );

                  _fetchUsers();

                    Navigator.of(context).pop();
                  } catch (e) {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text("Greška prilikom dodavanja učenika: $e"),
                        backgroundColor: Colors.red,
                      ),
                    );
                  }
                }
              },
              child: Text("Dodaj"),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white, backgroundColor: Colors.green),
            ),
          ],
        );
      },
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
                "",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
        ],
        rows: _students.map((profesor) {
          return DataRow(
            cells: [
              DataCell(Text("${profesor.ime} ${profesor.prezime}")),
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