import 'package:ednevnik_admin/models/school_year.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/models/user_detail.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/providers/user_detail_provider.dart';
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

class StudentDetailScreen extends StatefulWidget {
  final int? departmentID;

  const StudentDetailScreen({Key? key, this.departmentID}) : super(key: key);

  @override
  State<StudentDetailScreen> createState() => _StudentDetailScreenState();
}

class _StudentDetailScreenState extends State<StudentDetailScreen> {
  List<User> _students = [];
  List<User> _studentss = [];
  List<UserDetail> _userDetailData = [];
  List<SchoolYear> _schoolYearData = [];
  List<User> _studentsForDialog = [];
  bool _isLoading = true;

  List<School> _schools = [];
  School? _selectedSchool;

  List<Department> _departments = [];
  Department? _selectedDepartment;

  late UserProvider _userProvider;
  late SchoolProvider _schoolProvider;
  late DepartmentProvider _departmentProvider;
  late SchoolYearProvider _schoolYearProvider;
  late UserDetailProvider _userDetailProvider;

  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _schoolYearProvider = context.read<SchoolYearProvider>();
    _userDetailProvider = context.read<UserDetailProvider>();

    _fetchSchoolYear();
    _fetchUserDetails();
    _fetchUsers();
    _fetchSchools();
    _fetchUsersForDialog();
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

  Future<void> _fetchUserDetails() async {
    try {
      var userDetailResponse = await _userDetailProvider.get();
      if (mounted) {
        setState(() {
          _userDetailData = userDetailResponse.result;
        });
      }
    } catch (e) {
      print('Error fetching users: $e');
    }
  }

  Future<void> _fetchSchoolYear() async {
    try {
      var schoolYearResponse = await _schoolYearProvider.get();
      if (mounted) {
        setState(() {
          _schoolYearData = schoolYearResponse.result;
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
        if (_selectedDepartment != null && student.korisnikId != null) {
          await _departmentProvider.removeStudentFromDepartment(
            _selectedDepartment!.odjeljenjeID!,
            student.korisnikId!,
          );
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text("Uspješno ste izbrisali učenika iz odjeljenja."),
              backgroundColor: Colors.green,
            ),
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
        } else if (e.source.contains(
            "Ne možete obrisati učenika koji je bio prisutan na održanim časovima.")) {
          _showErrorDialog(
              'Ne možete obrisati učenika koji je bio na časovima koji su održani.');
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
                SizedBox(height: 16),
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
        child: Text("Dodaj učenika u odjeljenje",
            style: TextStyle(color: Colors.white)),
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
            "Učenici",
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
        Expanded(
          child: _buildDepartmentDropdown(),
        ),
        SizedBox(width: 32.0),
        Padding(
          padding: const EdgeInsets.only(left: 16.0, right: 16.0),
          child: ElevatedButton(
              onPressed: () => _showAddStudentDialog(context),
              child: Text("Dodaj učenika/cu"),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white, backgroundColor: Colors.blue)),
        ),
      ],
    );
  }

  void _openDialog() {
    final GlobalKey<FormBuilderState> _formKey = GlobalKey<FormBuilderState>();
    Department? selectedDepartment;
    User? selectedStudent;
    List<User> availableStudents = [];

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return StatefulBuilder(
          builder: (context, setState) {
            List<Object?> assignedStudentIds = _departments
                .expand((department) =>
                    department.ucenici?.map((student) => student.korisnikId) ??
                    [])
                .toList();

            availableStudents = _studentss
                .where((student) =>
                    !assignedStudentIds.contains(student.korisnikId))
                .toList();

            return AlertDialog(
              title: Text('Dodaj učenika u odjeljenje'),
              content: FormBuilder(
                key: _formKey,
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    FormBuilderDropdown<Department>(
                      name: 'department',
                      decoration:
                          InputDecoration(labelText: 'Odaberite odjeljenje'),
                      validator: FormBuilderValidators.required(
                          errorText: 'Ovo polje je obavezno'),
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
                    FormBuilderDropdown<User>(
                      name: 'student',
                      decoration:
                          InputDecoration(labelText: 'Odaberite učenika'),
                      validator: FormBuilderValidators.required(
                          errorText: 'Ovo polje je obavezno'),
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
              ),
              actions: [
                TextButton(
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  style:
                      ElevatedButton.styleFrom(foregroundColor: Colors.black),
                  child: Text('Odustani'),
                ),
                TextButton(
                  onPressed: () async {
                    if (_formKey.currentState?.saveAndValidate() ?? false) {
                      try {
                        await _departmentProvider.addStudentToDepartment(
                          selectedDepartment!.odjeljenjeID!,
                          selectedStudent!.korisnikId!,
                        );

                        _fetchDepartmentsAndInitialize(
                            schoolID: _selectedSchool?.skolaID);

                        Navigator.of(context).pop();

                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text(
                                '${selectedStudent?.ime} ${selectedStudent?.prezime} je dodan u ${selectedDepartment?.nazivOdjeljenja}'),
                            backgroundColor: Colors.green,
                          ),
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
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    foregroundColor: Colors.white,
                    backgroundColor: Colors.green,
                  ),
                  child: Text('Dodaj'),
                ),
              ],
            );
          },
        );
      },
    );
  }

  void _showAddStudentDialog(BuildContext context) {
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

        int? _selectYearOfPlan;
        int? _selectedEnrollmentYear;
        int? _selectedStudyYear;

        Department? selectedDepartment;

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
            return "Morate početi ime velikim slovom, a ostala slova moraju biti mala. Nisu dozvoljeni brojevi i specijalni karakteri.";
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
            return "Morate početi prezime velikim slovom, a ostala slova moraju biti mala. Nisu dozvoljeni brojevi i specijalni karakteri.";
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
                                  labelText: "Ime", errorMaxLines: 3),
                              validator: _validateName),
                        ),
                        SizedBox(width: 35.0),
                        Expanded(
                          child: TextFormField(
                            controller: _surnameController,
                            decoration: InputDecoration(
                                labelText: "Prezime", errorMaxLines: 3),
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
                    Row(
                      children: [
                        Expanded(
                          child: DropdownButtonFormField<int>(
                            decoration: InputDecoration(
                              labelText: "Godina upisa u školu",
                            ),
                            items: _schoolYearData
                                .map((year) => DropdownMenuItem<int>(
                                      value: year.skolskaGodinaID,
                                      child: Text(year.naziv ?? ""),
                                    ))
                                .toList(),
                            onChanged: (value) {
                              setState(() {
                                _selectedEnrollmentYear = value;
                              });
                            },
                            validator: (value) => value == null
                                ? "Odaberite godinu kada se učenik upisao u školu"
                                : null,
                          ),
                        ),
                        SizedBox(width: 35.0),
                        Expanded(
                          child: DropdownButtonFormField<int>(
                            decoration: InputDecoration(
                              labelText: "Godina studija",
                            ),
                            items: [1, 2, 3, 4]
                                .map((year) => DropdownMenuItem<int>(
                                      value: year,
                                      child: Text(year.toString()),
                                    ))
                                .toList(),
                            onChanged: (value) {
                              setState(() {
                                _selectedStudyYear = value;
                              });
                            },
                            validator: (value) => value == null
                                ? "Odaberite godinu studija"
                                : null,
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    Row(
                      children: [
                        Expanded(
                          child: FormBuilderDropdown<Department>(
                            name: 'department',
                            decoration: InputDecoration(
                                labelText: 'Izaberite odjeljenje učeniku'),
                            validator: (value) =>
                                value == null ? "Odaberite odjeljenje" : null,
                            items: _departments.map((department) {
                              return DropdownMenuItem<Department>(
                                value: department,
                                child:
                                    Text(department.nazivOdjeljenja ?? "N/A"),
                              );
                            }).toList(),
                            onChanged: (Department? newValue) {
                              setState(() {
                                selectedDepartment = newValue;
                              });
                            },
                          ),
                        ),
                        SizedBox(width: 35.0),
                        Expanded(
                          child: DropdownButtonFormField<int>(
                            decoration: InputDecoration(
                              labelText: "Školska godina koju učenik upisuje",
                            ),
                            items: _schoolYearData
                                .map((year) => DropdownMenuItem<int>(
                                      value: year.skolskaGodinaID,
                                      child: Text(year.naziv ?? ""),
                                    ))
                                .toList(),
                            onChanged: (value) {
                              setState(() {
                                _selectYearOfPlan = value;
                              });
                            },
                            validator: (value) =>
                                value == null ? "Odaberite godinu upisa" : null,
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
                      'UlogaID': 2,
                      'DatumIzmjene': DateTime.now().toIso8601String(),
                    };

                    try {
                      await userRolesProvider.Insert(newRoleAssignment);
                    } catch (e) {
                      print("Error inserting role assignment: $e");
                    }

                    var userDetails = {
                      'KorisnikID': addedUser.korisnikId,
                      'GodinaUpisaID': _selectedEnrollmentYear,
                      'GodinaStudija': _selectedStudyYear,
                      'UpisanaSkolskaGodinaID': _selectYearOfPlan,
                      'ProsjecnaOcjena' : 0.00,
                    };

                    try {
                      await _userDetailProvider.Insert(userDetails);
                    } catch (e) {
                      print("Error inserting user details: $e");
                    }

                    try {
                      await _departmentProvider.addStudentToDepartment(
                        selectedDepartment!.odjeljenjeID!,
                        addedUser!.korisnikId!,
                      );

                      _fetchDepartmentsAndInitialize(
                          schoolID: _selectedSchool?.skolaID);
                    } catch (e) {
                      print("Error inserting student in department: $e");
                    }

                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(
                        content: Text("Učenik uspješno dodat!"),
                        backgroundColor: Colors.green,
                      ),
                    );

                    _fetchUsers();
                    _fetchUserDetails();

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

  void _showStudentInfoDialog(BuildContext context, User student,
      List<UserDetail> userDetails, List<SchoolYear> schoolYears) {
    final userDetail = userDetails.firstWhere(
      (detail) => detail.korisnikID == student.korisnikId,
      orElse: () => UserDetail(null, null, null, null, null, null, null),
    );

    final enrollmentYear = userDetail != null
        ? schoolYears
            .firstWhere(
              (year) => year.skolskaGodinaID == userDetail.godinaUpisaID,
              orElse: () => SchoolYear(),
            )
            ?.naziv
        : "N/A";

    final enrollmentInSchoolYear = userDetail != null
        ? schoolYears
            .firstWhere(
              (year) =>
                  year.skolskaGodinaID == userDetail.upisanaSkolskaGodinaID,
              orElse: () => SchoolYear(),
            )
            ?.naziv
        : "N/A";

    final studyYear = userDetail?.godinaStudija?.toString() ?? "N/A";
    final medianGrade = userDetail?.prosjecnaOcjena?.toString() ?? "N/A";

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: Text("Informacije o učeniku"),
          content: SizedBox(
            width: 600,
            child: SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Ime: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${student.ime}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Prezime: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${student.prezime}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Email: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${student.email ?? "N/A"}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Telefon: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${student.telefon ?? "N/A"}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Korisničko ime: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${student.korisnickoIme}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Odjeljenje: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "${_departments.firstWhere(
                                (dept) =>
                                    dept.ucenici?.contains(student) ?? false,
                                orElse: () =>
                                    Department(null, 'Unknown', null, null),
                              ).nazivOdjeljenja ?? "N/A"}",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Godina upisa učenika u školu: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "$enrollmentYear",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Godina studija: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "$studyYear",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Upisana školska godina: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "$enrollmentInSchoolYear",
                        ),
                      ],
                    ),
                  ),
                  SizedBox(height: 8.0),
                  Text.rich(
                    TextSpan(
                      children: [
                        TextSpan(
                          text: "Prosječna ocjena: ",
                          style: TextStyle(fontWeight: FontWeight.bold),
                        ),
                        TextSpan(
                          text: "$medianGrade",
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
          actions: [
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: Text("Zatvori"),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
            ),
          ],
        );
      },
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
              child: Center(
                child: Text(
                  "Info",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
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
              DataCell(
                  Center(child: Text(department.nazivOdjeljenja ?? "N/A"))),
              DataCell(
                Center(
                  child: ElevatedButton(
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
              ),
              DataCell(
                Tooltip(
                  message: "Informacije o učeniku",
                  child: IconButton(
                    icon: Icon(Icons.info_outline),
                    onPressed: () {
                      _showStudentInfoDialog(
                          context, student, _userDetailData, _schoolYearData);
                    },
                  ),
                ),
              ),
              DataCell(
                Tooltip(
                  message: "Uređivanje učenika",
                  child: Center(
                    child: IconButton(
                      icon: Icon(Icons.edit),
                      onPressed: () {
                      },
                    ),
                  ),
                ),
              ),
              DataCell(
                Tooltip(
                  message: "Brisanje učenika iz odjeljanja",
                  child: IconButton(
                    icon: Icon(Icons.delete, color: Colors.red),
                    onPressed: () {
                      _confirmDelete(student);
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
