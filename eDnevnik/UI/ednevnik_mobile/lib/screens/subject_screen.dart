import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/department_subject.dart';
import '../models/user.dart';
import '../models/user_detail.dart';
import '../providers/department_provider.dart';
import '../providers/department_subject_provider.dart';
import '../providers/user_detail_provider.dart';
import '../providers/user_provider.dart';

class SubjectDetailScreen extends StatefulWidget {
  const SubjectDetailScreen({Key? key}) : super(key: key);

  @override
  State<SubjectDetailScreen> createState() => _SubjectDetailScreenState();
}

class _SubjectDetailScreenState extends State<SubjectDetailScreen> {
  SearchResult<Subject>? result;
  late SubjectProvider _subjectProvider;
  late SchoolProvider _schoolProvider;
  late DepartmentProvider _departmentProvider;
  late DepartmentSubjectProvider _departmentSubjectProvider;
  late UserDetailProvider _userDetailProvider;
  late SchoolYearProvider _schoolYearProvider;

  String? godinaUpisaNaziv;
  String? upisanaSkolskaGodinaNaziv;

  SearchResult<UserDetail>? userDetail;
  School? _selectedSchool;
  List<School> _schools = [];
  User? loggedInUser;

  late int? userDepartment;
  List<DepartmentSubject> _departmentSubjects = [];
  int? _schoolIDFromDepartment;

  late Future<void> _initialLoadFuture;

  @override
  void initState() {
    super.initState();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();
    _userDetailProvider = context.read<UserDetailProvider>();
    _schoolYearProvider = context.read<SchoolYearProvider>();

    _initialLoadFuture = _initializeData();

  }

  Future<void> _initializeData() async {
    loggedInUser = context.read<UserProvider>().loggedInUser;

    if (loggedInUser != null) {
      await _fetchUserDetails();
      await _fetchSchoolYearNames();
      await _fetchDepartments();
    } else {
      throw Exception("Logged-in user is null.");
    }
  }

  Future<void> _fetchSchoolYearNames() async {
    try {
      if (userDetail?.result.isNotEmpty ?? false) {
        UserDetail detail = userDetail!.result.first;

        if (detail.godinaUpisaID != null) {
          var godinaUpisa = await _schoolYearProvider.get(filter: {
            'SkolskaGodinaID': detail.godinaUpisaID,
          });

          if (godinaUpisa.result.isNotEmpty) {
            godinaUpisaNaziv = godinaUpisa.result.first.naziv;
          }
        }

        if (detail.upisanaSkolskaGodinaID != null) {
          var upisanaGodina = await _schoolYearProvider.get(filter: {
            'SkolskaGodinaID': detail.upisanaSkolskaGodinaID,
          });

          if (upisanaGodina.result.isNotEmpty) {
            upisanaSkolskaGodinaNaziv = upisanaGodina.result.first.naziv;
          }
        }

        setState(() {});
      }
    } catch (e) {
      print("Error fetching school year names: $e");
    }
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
  }

  Future<void> _fetchUserDetails() async {
    try {
      if (loggedInUser != null) {
        print('Fetching user details for KorisnikID: ${loggedInUser!.korisnikId}');
        var detail = await _userDetailProvider.get(filter: {'KorisnikID': loggedInUser!.korisnikId});

        if (detail.result.isEmpty) {
          print('No user detail found for the given KorisnikID.');
        } else {
          print('Fetched User Details: ${detail.result}');
        }

        if (mounted) {
          setState(() {
            userDetail = detail;
          });
        }
      } else {
        print('Cannot fetch user details. loggedInUser is null.');
      }
    } catch (e) {
      print('Error fetching user details: $e');
    }
  }


  Future<void> _fetchDepartments() async {
    try {
      var departments = await _departmentProvider.get(filter: {'isUceniciIncluded': true});

      if (departments != null) {
        for (var department in departments.result) {
          if (department.ucenici != null &&
              department.ucenici!.any((user) => user.korisnikId == loggedInUser?.korisnikId)) {
            _schoolIDFromDepartment = department.skolaID;
            userDepartment = department.odjeljenjeID;

            await _fetchSchools();
            break;
          } else {
            print('User not found in department with odjeljenjeID: ${department.odjeljenjeID}');
          }
        }
      } else {
        print("No departments found.");
      }
    } catch (e) {
      print('Error fetching departments: $e');
    }
  }

  Future<void> _fetchSchools() async {
    if (_schoolIDFromDepartment != null) {
      try {
        var schools = await _schoolProvider.get(filter: {
          'SkolaID': _schoolIDFromDepartment,
        });
        if (mounted) {
          setState(() {
            _schools = schools.result;
            if (_schools.isNotEmpty) {
              _selectedSchool = _schools.first;
              _fetchDepartmentSubjects();
            }
          });
        }
      } catch (e) {
        print('Error fetching schools: $e');
      }
    } else {
      print("No skolaID available for fetching schools.");
    }
  }

  Future<void> _fetchDepartmentSubjects() async {
    try {
      var data = await _departmentSubjectProvider.get(filter: {
        'OdjeljenjeID': userDepartment,
      });
      if (mounted) {
        setState(() {
          _departmentSubjects = data.result;
        });
        _fetchSubjectsForDepartment();
      }
    } catch (e) {
      print('Error fetching department subjects: $e');
    }
  }

  Future<void> _fetchSubjectsForDepartment() async {
    List<int> predmetIDs = _departmentSubjects
        .map((ds) => ds.predmetID)
        .whereType<int>()
        .toList();

    if (predmetIDs.isNotEmpty) {
      try {
        var data = await _subjectProvider.get(filter: {
          'SkolaID': _schoolIDFromDepartment,
        });

        if (mounted) {
          var filteredSubjects = data.result
              .where((subject) => predmetIDs.contains(subject.predmetID))
              .map((subject) {
            subject.isExpanded ??= false;
            return subject;
          })
              .toList();

          setState(() {
            result = SearchResult<Subject>()
              ..count = filteredSubjects.length
              ..result = filteredSubjects;
          });
        }
      } catch (e) {
        print("Error fetching subjects: $e");
      }
    } else {
      print("No PredmetIDs available for fetching subjects.");
    }
  }


  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: Color(0xFFF7F2FA),
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
                SizedBox(height: 8.0),
                _buildUserDetailsSection(),
                SizedBox(height: 8.0),
                Expanded(child: _buildDataListView()),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildUserDetailsSection() {
    if (userDetail == null || userDetail!.result.isEmpty) {
      return Center(child: CircularProgressIndicator());
    }

    UserDetail detail = userDetail!.result.first;

    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(10.0),
          boxShadow: [
            BoxShadow(
              color: Colors.black12,
              blurRadius: 4.0,
              offset: Offset(0, 2),
            ),
          ],
        ),
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Detalji o učeniku',
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 8),
            Text('Obnavlja godinu: ${detail.obnavljaGodinu == true ? "Da" : "Ne"}'),
            Text('Prosječna ocjena: ${detail.prosjecnaOcjena?.toStringAsFixed(2) ?? "N/A"}'),
            Text('Godina upisa: ${godinaUpisaNaziv ?? "N/A"}'),
            Text('Upisana školska godina: ${upisanaSkolskaGodinaNaziv ?? "N/A"}'),
          ],
        ),
      ),
    );
  }

  Widget _buildScreenName() {
    return Align(
      alignment: Alignment.centerLeft,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
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
                  "Početna",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              Expanded(
                child: _buildSchoolDropdown(),
              ),
            ],
          ),
          SizedBox(height: 32.0),
          Center(
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: RichText(
                textAlign: TextAlign.center,
                text: TextSpan(
                  text: 'Dobrodošli ',
                  style: TextStyle(
                    fontSize: 24.0,
                    color: Colors.black87,
                  ),
                  children: [
                    TextSpan(
                      text: '${loggedInUser?.ime ?? ''} ${loggedInUser?.prezime ?? ''}',
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.black87,
                      ),
                    ),
                    TextSpan(
                      text: ' u eDnevnik. Ovdje možete vidjeti vaše predmete i informacije za ovu akademsku godinu.',
                    ),
                  ],
                ),
              ),
            ),
          ),
          SizedBox(height: 16,)
        ],
      ),
    );
  }

  Widget _buildSchoolDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 210,
          child: DropdownButton<School>(
            value: _selectedSchool,
            items: _schools.map((school) {
              return DropdownMenuItem<School>(
                value: school,
                child: Text(school.naziv ?? "N/A"),
              );
            }).toList(),
            onChanged: _schoolIDFromDepartment != null
                ? null
                : (School? newValue) {
              setState(() {
                _selectedSchool = newValue;
              });
              _fetchSubjectsForDepartment();
            },
          ),
        ),
      ],
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.only(left:16, right: 16),
        child: ExpansionPanelList(
          elevation: 1,
          expandedHeaderPadding: EdgeInsets.symmetric(vertical: 5),
          expansionCallback: (int index, bool isExpanded) {
            setState(() {
              if (index >= 0 && index < result!.result.length) {
                result!.result[index].isExpanded = !(result!.result[index].isExpanded ?? false);
              } else {
                print('Index out of bounds: $index');
              }
            });
          },
          children: result?.result
              .asMap()
              .entries
              .map((entry) {
            int index = entry.key;
            Subject subject = entry.value;

            bool expanded = subject.isExpanded ?? false;

            return ExpansionPanel(
              headerBuilder: (BuildContext context, bool isExpanded) {
                return ListTile(
                  title: Text(subject.naziv ?? "No Name"),
                );
              },
              body: ListTile(
                title: Text(subject.opis ?? "No description available"),
              ),

              isExpanded: expanded,
            );
          }).toList() ?? [],
        ),
      ),
    );
  }




}
