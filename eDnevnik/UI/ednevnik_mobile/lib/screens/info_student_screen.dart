import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/grade.dart';
import '../models/user.dart';
import '../models/subject.dart';
import '../providers/grade_provider.dart';
import '../providers/subject_provider.dart';
import '../providers/user_provider.dart';
import '../widgets/master_screen.dart';

class InfoStudentDetailScreen extends StatefulWidget {
  const InfoStudentDetailScreen({super.key});

  @override
  State<InfoStudentDetailScreen> createState() => _InfoStudentDetailScreenState();
}

class _InfoStudentDetailScreenState extends State<InfoStudentDetailScreen> {
  User? loggedInUser;
  late GradeProvider _gradeProvider;
  late SubjectProvider _subjectProvider;
  Map<int, List<Grade>>? _groupedGrades;
  Map<int, String> _subjectNames = {};
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _gradeProvider = context.read<GradeProvider>();
    _subjectProvider = context.read<SubjectProvider>();
  }

  Future<void> _fetchGrades() async {
    try {
      var grades = await _gradeProvider.get(filter: {'KorisnikID': loggedInUser?.korisnikId});
      if (mounted) {
        setState(() {
          _groupedGrades = {};
          for (var grade in grades.result!) {
            grade.isExpanded ??= false;

            if (_groupedGrades!.containsKey(grade.predmetID)) {
              _groupedGrades![grade.predmetID]!.add(grade);
            } else {
              _groupedGrades![grade.predmetID ?? 0] = [grade];
              _fetchSubjectName(grade.predmetID ?? 0);
            }
          }
          isLoading = false;
        });
      }
    } catch (e) {
      print("Failed to fetch grades: $e");
    }
  }

  Future<void> _fetchSubjectName(int predmetID) async {
    if (_subjectNames.containsKey(predmetID)) return;
    try {
      var subject = await _subjectProvider.getById(predmetID);
      setState(() {
        _subjectNames[predmetID] = subject.naziv ?? 'Unknown Subject';
      });
    } catch (e) {
      print("Failed to fetch subject name: $e");
    }
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    final userProvider = context.watch<UserProvider>();
    if (userProvider.loggedInUser != loggedInUser) {
      loggedInUser = userProvider.loggedInUser;
      if (loggedInUser != null) {
        _fetchGrades();
      }
    }
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
                isLoading
                    ? const CircularProgressIndicator()
                    : _groupedGrades != null && _groupedGrades!.isNotEmpty
                    ? Expanded(child: _buildExpansionPanelList())
                    : const Text('No grades available'),
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
                  "Ocjene",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
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
                  text: 'Ovdje možete vidjeti vaše ocjene.',
                  style: TextStyle(
                    fontSize: 24.0,
                    color: Colors.black87,
                  ),
                ),
              ),
            ),
          ),
          SizedBox(height: 16,)
        ],
      ),
    );
  }


  Widget _buildExpansionPanelList() {
    return SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16.0),
        child: ExpansionPanelList(
          elevation: 1,
          expandedHeaderPadding: const EdgeInsets.symmetric(vertical: 5),
          expansionCallback: (int index, bool isExpanded) {
            setState(() {
              int subjectID = _groupedGrades!.keys.elementAt(index);

              _groupedGrades![subjectID]!.first.isExpanded =
              !(_groupedGrades![subjectID]!.first.isExpanded ?? false);
            });
          },
          children: _groupedGrades!.entries.map<ExpansionPanel>((entry) {
            int subjectID = entry.key;
            List<Grade> grades = entry.value;

            return ExpansionPanel(
              headerBuilder: (BuildContext context, bool isExpanded) {
                return ListTile(
                  title: Text(_subjectNames[subjectID] ?? 'Loading...'),
                );
              },
              body: Column(
                children: grades.map((grade) {
                  return ListTile(
                    title: Text(
                      "Datum: ${grade.datum?.toLocal().toString().split(' ')[0] ?? 'N/A'}",
                    ),
                    subtitle: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text("Ocjena: ${grade.vrijednostOcjene ?? 'N/A'}"),
                        Text("Komentar: ${grade.komentar ?? 'Nema komentara'}"),
                      ],
                    ),
                  );
                }).toList(),
              ),
              isExpanded: grades.first.isExpanded ?? false,
            );
          }).toList(),
        ),
      ),
    );
  }

}
