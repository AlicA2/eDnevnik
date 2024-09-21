import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:percent_indicator/percent_indicator.dart';

import '../models/annual_plan_program.dart';
import '../models/user.dart';
import '../models/subject.dart';
import '../models/classes.dart';
import '../models/classes_students.dart';
import '../providers/annual_plan_program_provider.dart';
import '../providers/department_provider.dart';
import '../providers/user_provider.dart';
import '../providers/subject_provider.dart';
import '../providers/classes_provider.dart';
import '../providers/classes_students_provider.dart';
import '../widgets/master_screen.dart';

class InfoAttendanceDetailScreen extends StatefulWidget {
  const InfoAttendanceDetailScreen({super.key});

  @override
  State<InfoAttendanceDetailScreen> createState() =>
      _InfoAttendanceDetailScreenState();
}

class _InfoAttendanceDetailScreenState
    extends State<InfoAttendanceDetailScreen> {
  User? loggedInUser;
  late int? userDepartment;

  late DepartmentProvider _departmentProvider;
  late AnnualPlanProgramProvider _annualPlanProgramProvider;
  late SubjectProvider _subjectProvider;
  late ClassesProvider _classesProvider;
  late ClassesStudentsProvider _classesStudentsProvider;

  List<AnnualPlanProgram> annualPlanPrograms = [];
  List<Subject> subjects = [];
  List<Classes> odrzaniCasovi = [];
  List<int> casoviIDs = [];
  List<ClassesStudents> zakljucaniClassesStudents = [];

  Map<int, double> attendancePercentage = {};
  bool isLoading = true;

  @override
  void initState() {
    super.initState();

    _departmentProvider = context.read<DepartmentProvider>();
    _annualPlanProgramProvider = context.read<AnnualPlanProgramProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _classesProvider = context.read<ClassesProvider>();
    _classesStudentsProvider = context.read<ClassesStudentsProvider>();

    _fetchDepartments();
  }

  Future<void> _fetchDepartments() async {
    try {
      var departments = await _departmentProvider.get(filter: {
        'isUceniciIncluded': true
      });

      if (departments != null) {
        for (var department in departments.result) {
          if (department.ucenici != null &&
              department.ucenici!.any((user) =>
              user.korisnikId == loggedInUser?.korisnikId)) {
            userDepartment = department.odjeljenjeID;

            await _fetchAnnualPlanPrograms();
            break;
          }
        }
      }
    } catch (e) {
      print('Error fetching departments: $e');
    }
  }

  Future<void> _fetchAnnualPlanPrograms() async {
    try {
      var annualPlanResponse = await _annualPlanProgramProvider.get(filter: {
        'OdjeljenjeID': userDepartment,
      });

      if (annualPlanResponse.result != null) {
        setState(() {
          annualPlanPrograms = annualPlanResponse.result;
        });

        await _fetchSubjectsForAnnualPlans();
        await _fetchClassesForAnnualPlans();
        await _fetchClassesStudentsForOdrzaniCasovi();
      }
    } catch (e) {
      print("Failed to fetch Annual Plan Programs: $e");
    }
  }

  Future<void> _fetchSubjectsForAnnualPlans() async {
    try {
      for (var program in annualPlanPrograms) {
        if (program.predmetID != null) {
          var subjectResponse = await _subjectProvider.get(filter: {
            'PredmetID': program.predmetID,
          });

          if (subjectResponse.result != null) {
            setState(() {
              subjects.add(subjectResponse.result[0]);
            });
          }
        }
      }
    } catch (e) {
      print('Error fetching subjects: $e');
    }
  }

  Future<void> _fetchClassesForAnnualPlans() async {
    try {
      for (var program in annualPlanPrograms) {
        var classesResponse = await _classesProvider.get(filter: {
          'GodisnjiPlanProgramID': program.godisnjiPlanProgramID,
        });

        if (classesResponse.result != null) {
          for (var classItem in classesResponse.result) {
            if (classItem.isOdrzan == true) {
              setState(() {
                odrzaniCasovi.add(classItem);
              });
            }
          }
        }
      }
    } catch (e) {
      print('Error fetching classes: $e');
    }
  }

  Future<void> _fetchClassesStudentsForOdrzaniCasovi() async {
    try {
      Map<int, int> subjectTotalClasses = {};
      Map<int, int> subjectAttendedClasses = {};

      for (var casovi in odrzaniCasovi) {
        int? subjectID = annualPlanPrograms
            .firstWhere((program) =>
        program.godisnjiPlanProgramID == casovi.godisnjiPlanProgramID)
            .predmetID;

        if (subjectID != null) {
          subjectTotalClasses[subjectID] = (subjectTotalClasses[subjectID] ?? 0) + 1;

          var classesStudentsResponse = await _classesStudentsProvider.get(filter: {
            'CasoviID': casovi.casoviID,
            'UcenikID': loggedInUser?.korisnikId
          });

          var classesStudentList = classesStudentsResponse.result;

          for (var student in classesStudentList) {
            if (student.isPrisutan == true) {
              subjectAttendedClasses[subjectID] =
                  (subjectAttendedClasses[subjectID] ?? 0) + 1;
            }
          }
        }
      }

      subjectTotalClasses.forEach((subjectID, totalClasses) {
        int attendedClasses = subjectAttendedClasses[subjectID] ?? 0;
        double percentage = (attendedClasses / totalClasses) * 100;

        setState(() {
          attendancePercentage[subjectID] = percentage;
        });

        print("Subject ID: $subjectID, Percentage: $percentage%");
      });

      setState(() {
        isLoading = false;
      });
    } catch (e) {
      print('Error fetching ClassesStudents: $e');
    }
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
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
            child: isLoading
                ? Center(child: CircularProgressIndicator())
                : SingleChildScrollView(
              child: Column(
                children: [
                  _buildScreenName(),
                  SizedBox(height: 16.0),
                  _buildSubjectList(),
                  SizedBox(height: 16.0),
                ],
              ),
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
              "Prisustvo",
              style: TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          SizedBox(height: 32.0),
        ],
      ),
    );
  }

  Widget _buildSubjectList() {
    if (subjects.isEmpty) {
      return Center(
        child: Text('No subjects found.'),
      );
    }

    return ListView.builder(
      shrinkWrap: true,
      physics: NeverScrollableScrollPhysics(),
      itemCount: subjects.length,
      itemBuilder: (context, index) {
        var subject = subjects[index];
        int subjectID = subject.predmetID ?? 0;
        double percentage = attendancePercentage[subjectID] ?? 0.0;

        return ListTile(
          title: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Text(
                subject.naziv ?? "Unknown Subject",
                style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 8.0),
              CircularPercentIndicator(
                radius: 60.0,
                lineWidth: 5.0,
                percent: percentage / 100,
                center: Text("${percentage.toStringAsFixed(1)}%"),
                progressColor: Colors.green,
              ),
              SizedBox(height: 8.0),
              Text(
                "Prisustvo: ${percentage.toStringAsFixed(1)}%",
                style: TextStyle(fontSize: 14),
                textAlign: TextAlign.center,
              ),
            ],
          ),
          contentPadding: EdgeInsets.symmetric(vertical: 10.0),
        );
      },
    );
  }

}
