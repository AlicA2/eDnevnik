import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'dart:collection';

class CalendarDetailScreen extends StatefulWidget {
  const CalendarDetailScreen({super.key});

  @override
  State<CalendarDetailScreen> createState() => _CalendarDetailScreenState();
}

class _CalendarDetailScreenState extends State<CalendarDetailScreen> {
  School? _selectedSchool;
  List<School> _schools = [];
  List<Classes> _classes = [];
  DateTime _focusedDay = DateTime.now();
  DateTime? _selectedDay;
  User? loggedInUser;

  late ClassesProvider _classesProvider;
  late SchoolProvider _schoolProvider;

  Map<DateTime, List<Classes>> _groupedClasses = {};

  @override
  void initState() {
    super.initState();
    _schoolProvider = context.read<SchoolProvider>();
    _classesProvider = context.read<ClassesProvider>();
    _fetchSchools();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchClasses();
          }
        });
      }
    } catch (e) {
      print("Failed to fetch schools: $e");
    }
  }

  Future<void> _fetchClasses() async {
  if (_selectedSchool == null) return;

  try {
    var classesResponse = await _classesProvider.get(filter: {
      'SkolaID': _selectedSchool?.skolaID,
      'ProfesorID': loggedInUser?.korisnikId,
    });

    if (mounted) {
      setState(() {
        _classes = classesResponse.result
            .where((classItem) => classItem.datumOdrzavanjaCasa != null)
            .toList();

        _groupClassesByDate();
      });
    }
  } catch (e) {
    print("Failed to fetch classes: $e");
  }
}

  void _groupClassesByDate() {
  _groupedClasses.clear();
  for (var classItem in _classes) {
    if (classItem.datumOdrzavanjaCasa != null) {
      DateTime eventDate = DateTime(
        classItem.datumOdrzavanjaCasa!.year,
        classItem.datumOdrzavanjaCasa!.month,
        classItem.datumOdrzavanjaCasa!.day,
      );

      if (_groupedClasses[eventDate] == null) {
        _groupedClasses[eventDate] = [];
      }
      _groupedClasses[eventDate]?.add(classItem);
    }
  }
}

List<Classes> _getClassesForDay(DateTime day) {
  DateTime normalizedDay = DateTime(day.year, day.month, day.day);

  return _groupedClasses[normalizedDay] ?? [];
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
                _buildCalendar(),
                SizedBox(height: 20),
                if (_selectedDay != null) _buildSelectedClasses(),
                SizedBox(height: 20),
                _buildAddClassesButton(),
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
              "Kalendar",
              style: TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(child: _buildSchoolDropdown()),
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
            onChanged: (School? newValue) {
              setState(() {
                _selectedSchool = newValue;
                _fetchClasses();
              });
            },
          ),
        ),
      ],
    );
  }

 Widget _buildCalendar() {
  return TableCalendar(
    firstDay: DateTime.utc(2020, 1, 1),
    lastDay: DateTime.utc(2030, 12, 31),
    focusedDay: _focusedDay,
    selectedDayPredicate: (day) {
      return isSameDay(_selectedDay, day);
    },
    onDaySelected: (selectedDay, focusedDay) {
      setState(() {
        _selectedDay = selectedDay;
        _focusedDay = focusedDay;
      });
    },
    calendarFormat: CalendarFormat.month,
    availableCalendarFormats: const {
      CalendarFormat.month: 'Month',
    },
    eventLoader: _getClassesForDay,
  );
}

  Widget _buildSelectedClasses() {
  List<Classes> selectedDayClasses = _getClassesForDay(_selectedDay!);

  if (selectedDayClasses.isEmpty) {
    return Text("Nema časova za selektirani dan.");
  }

  return Column(
    children: selectedDayClasses.map((classItem) {
      String time = classItem.datumOdrzavanjaCasa != null
          ? "${classItem.datumOdrzavanjaCasa!.hour.toString().padLeft(2, '0')}:${classItem.datumOdrzavanjaCasa!.minute.toString().padLeft(2, '0')}"
          : "N/A";
      
      return ListTile(
        title: Text("$time ${classItem.nazivCasa ?? "N/A"}"),
      );
    }).toList(),
  );
}


  Widget _buildAddClassesButton() {
    return Align(
      alignment: Alignment.centerRight,
      child: ElevatedButton(
        onPressed: () {
          print('Dodaj časove za kalendar pressed');
        },
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.blue,
        ),
        child: Text("Dodaj časove za kalendar"),
      ),
    );
  }
}
