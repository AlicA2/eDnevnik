import 'dart:convert';
import 'dart:collection';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:provider/provider.dart';
import 'package:shared_preferences/shared_preferences.dart';

int _getWeekOfYear(DateTime date) {
  final firstDayOfYear = DateTime(date.year, 1, 1);
  final firstThursday = firstDayOfYear
      .add(Duration(days: (DateTime.thursday - firstDayOfYear.weekday) % 7));
  final thisThursday =
      date.add(Duration(days: (DateTime.thursday - date.weekday) % 7));

  return ((thisThursday.difference(firstThursday).inDays) / 7).ceil() + 1;
}

class CalendarDetailScreen extends StatefulWidget {
  const CalendarDetailScreen({super.key});

  @override
  State<CalendarDetailScreen> createState() => _CalendarDetailScreenState();
}

class _CalendarDetailScreenState extends State<CalendarDetailScreen> {
  late Map<DateTime, List<String>> _events;
  late List<String> _selectedEvents;
  DateTime _selectedDay = DateTime.now();
  DateTime _focusedDay = DateTime.now();
  final ClassesProvider _classesProvider = ClassesProvider();
  late SchoolProvider _schoolProvider;
  School? _selectedSchool;
  List<School> _schools = [];
  User? loggedInUser;

  @override
  void initState() {
    super.initState();
    _schoolProvider = context.read<SchoolProvider>();
    _events = {};
    _selectedEvents = [];
    _loadSavedEvents();
    _fetchSchools();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
    print("Logged-in user: ${loggedInUser?.ime}");
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _loadEvents();
          }
        });
      }
    } catch (e) {}
  }

  Future<void> _saveEvents() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    Map<String, List<String>> stringEvents = _events.map((key, value) =>
        MapEntry(key.toIso8601String(), value));

    await prefs.setString('events', jsonEncode(stringEvents));
  }

  Future<void> _loadSavedEvents() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String? savedEvents = prefs.getString('events');

    if (savedEvents != null) {
      Map<String, dynamic> decodedEvents = jsonDecode(savedEvents);
      setState(() {
        _events = decodedEvents.map((key, value) => MapEntry(
            DateTime.parse(key), List<String>.from(value)));
      });
    }
  }

  Future<void> _loadEvents() async {
    if (_selectedSchool == null) return;

    var result = await _classesProvider
        .get(filter: {'SkolaID': _selectedSchool!.skolaID});

    Map<DateTime, List<String>> events = {};

    DateTime currentDay = DateTime(_selectedDay.year, 2, 1);
    while (currentDay.weekday != DateTime.monday) {
      currentDay = currentDay.add(const Duration(days: 1));
    }

    Map<int, Queue<Classes>> groupedClasses = {};
    for (var cas in result.result) {
      if (!groupedClasses.containsKey(cas.godisnjiPlanProgramID)) {
        groupedClasses[cas.godisnjiPlanProgramID!] = Queue<Classes>();
      }
      groupedClasses[cas.godisnjiPlanProgramID!]!.add(cas);
    }

    Set<int> usedProgramsInWeek = {};

    while (groupedClasses.values.any((queue) => queue.isNotEmpty)) {
      if (currentDay.weekday >= DateTime.monday &&
          currentDay.weekday <= DateTime.friday) {
        DateTime classTime =
            DateTime(currentDay.year, currentDay.month, currentDay.day, 8);

        while (classTime.hour < 13 &&
            groupedClasses.values.any((queue) => queue.isNotEmpty)) {
          bool classScheduled = false;

          for (var entry in groupedClasses.entries.toList()) {
            int programID = entry.key;

            if (usedProgramsInWeek.contains(programID)) continue;

            if (entry.value.isNotEmpty) {
              var classItem = entry.value.removeFirst();
              String className = classItem.nazivCasa ?? 'Class';
              events
                  .putIfAbsent(currentDay, () => [])
                  .add('${_formatTime(classTime)} $className');

              usedProgramsInWeek.add(programID);

              classTime = classTime.add(const Duration(minutes: 60));

              classScheduled = true;
              break;
            }
          }

          if (!classScheduled) break;
        }

        currentDay = currentDay.add(const Duration(days: 1));

        if (currentDay.weekday == DateTime.monday) {
          usedProgramsInWeek.clear();
        }

        while (currentDay.weekday == DateTime.saturday ||
            currentDay.weekday == DateTime.sunday) {
          currentDay = currentDay.add(const Duration(days: 1));
          usedProgramsInWeek.clear();
        }
      } else {
        currentDay = currentDay.add(const Duration(days: 1));
        while (currentDay.weekday == DateTime.saturday ||
            currentDay.weekday == DateTime.sunday) {
          currentDay = currentDay.add(const Duration(days: 1));
          usedProgramsInWeek.clear();
        }
      }
    }

    setState(() {
      _events = events;
      _selectedEvents = _getEventsForDay(_selectedDay);
    });
    _saveEvents();
  }

  String _formatTime(DateTime time) {
    return '${time.hour.toString().padLeft(2, '0')}:${time.minute.toString().padLeft(2, '0')}';
  }

  List<String> _getEventsForDay(DateTime day) {
    return _events[_normalizeDate(day)] ?? [];
  }

  DateTime _normalizeDate(DateTime date) {
    return DateTime(date.year, date.month, date.day);
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
                _buildCalendar(),
                const SizedBox(height: 8.0),
                Expanded(child: _buildEventList()),
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
            child: const Text(
              "Kalendar",
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
    );
  }

  Widget _buildSchoolDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 300,
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
              });
              _loadEvents();
            },
          ),
        ),
      ],
    );
  }

  Widget _buildCalendar() {
    return TableCalendar(
      firstDay: DateTime(2020),
      lastDay: DateTime(2030),
      focusedDay: _focusedDay,
      selectedDayPredicate: (day) => isSameDay(_selectedDay, day),
      eventLoader: _getEventsForDay,
      onDaySelected: (selectedDay, focusedDay) {
        setState(() {
          _selectedDay = selectedDay;
          _focusedDay = focusedDay;
          _selectedEvents = _getEventsForDay(selectedDay);
        });
      },
      calendarStyle: const CalendarStyle(
        todayDecoration: BoxDecoration(
          color: Colors.blueAccent,
          shape: BoxShape.circle,
        ),
        selectedDecoration: BoxDecoration(
          color: Colors.lightBlue,
          shape: BoxShape.circle,
        ),
        markerDecoration: BoxDecoration(
          color: Colors.blue,
          shape: BoxShape.circle,
        ),
      ),
      headerStyle: const HeaderStyle(
        formatButtonVisible: false,
        titleCentered: true,
      ),
    );
  }

  Widget _buildEventList() {
    return ListView.builder(
      itemCount: _selectedEvents.length,
      itemBuilder: (context, index) {
        return Card(
          child: ListTile(
            title: Text(_selectedEvents[index]),
          ),
        );
      },
    );
  }
}
