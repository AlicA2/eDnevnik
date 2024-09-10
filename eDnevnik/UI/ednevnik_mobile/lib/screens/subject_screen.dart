import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/department_subject.dart';
import '../models/user.dart';
import '../providers/department_provider.dart';
import '../providers/department_subject_provider.dart';
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
  School? _selectedSchool;
  List<School> _schools = [];
  User? loggedInUser;
  TextEditingController _ftsController = TextEditingController();
  late int? userDepartment;
  List<DepartmentSubject> _departmentSubjects = [];
  int? _schoolIDFromDepartment;

  @override
  void initState() {
    super.initState();
    _subjectProvider = context.read<SubjectProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _departmentSubjectProvider = context.read<DepartmentSubjectProvider>();

    _fetchDepartments();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
    print("Logged-in user: ${loggedInUser?.ime}");
  }

  Future<void> _fetchDepartments() async {
    try {
      var departments = await _departmentProvider.get(filter: {'isUceniciIncluded': true});

      if (departments != null) {
        for (var department in departments.result) {
          if (department.ucenici != null &&
              department.ucenici!.any((user) => user.korisnikId == loggedInUser?.korisnikId)) {
            print('User is in department with odjeljenjeID: ${department.odjeljenjeID}');

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
    print("Predmeti u predmetIDs su : $predmetIDs");

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
                SizedBox(height: 16.0),
                Expanded(child: _buildDataListView()),
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
                  "Predmeti",
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
                      text: ' u eDnevnik. Ovdje možete vidjeti vaše predmete za ovu akademsku godinu.',
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
      child: ExpansionPanelList(
        elevation: 1,
        expandedHeaderPadding: EdgeInsets.symmetric(vertical: 5),
        expansionCallback: (int index, bool isExpanded) {
          setState(() {
            if (index >= 0 && index < result!.result.length) {
              result!.result[index].isExpanded = !(result!.result[index].isExpanded ?? false);
              print('Expanding index: $index, new expanded state: ${result!.result[index].isExpanded}');
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

          print('Index: $index, Subject: ${subject.naziv}, IsExpanded: $expanded');

          return ExpansionPanel(
            headerBuilder: (BuildContext context, bool isExpanded) {
              return ListTile(
                title: Text(subject.naziv ?? "No Name"),
              );
            },
            body: ListTile(
              title: Text(subject.opis ?? "No description available"),
              trailing: subject.isExpanded == false
                  ? IconButton(
                icon: Icon(Icons.edit),
                onPressed: () async {
                  final result = await Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => SingleSubjectListScreen(subject: subject),
                    ),
                  );
                  if (result == 'updated' || result == 'deleted') {
                    _fetchSubjectsForDepartment();
                  }
                },
              )
                  : null,
            ),

            isExpanded: expanded,
          );
        }).toList() ?? [],
      ),
    );
  }




}
