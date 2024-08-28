import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';

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

  @override
  void initState() {
    super.initState();
    _events = {};
    _selectedEvents = [];
    _loadEvents();
  }

  Future<void> _loadEvents() async {
    var result = await _classesProvider.get();
    Map<DateTime, List<String>> events = {};

    DateTime currentDay = DateTime(_selectedDay.year, 2, 1);
    int classIndex = 0;

    for (var classes in result.result) {
      while (true) {
        // Skip weekends
        if (currentDay.weekday == DateTime.saturday || currentDay.weekday == DateTime.sunday) {
          currentDay = currentDay.add(const Duration(days: 1));
          continue;
        }

        // Schedule classes from 08:00 to 14:00
        DateTime startTime = DateTime(currentDay.year, currentDay.month, currentDay.day, 8);
        while (startTime.hour < 14) {
          if (classIndex >= result.result.length) break;
          String className = result.result[classIndex].nazivCasa ?? 'Class';
          events.putIfAbsent(currentDay, () => []).add(
              '${_formatTime(startTime)} $className');
          
          startTime = startTime.add(const Duration(minutes: 60)); // 45 mins class + 15 mins break
          classIndex++;
        }

        // Move to the next day
        currentDay = currentDay.add(const Duration(days: 1));
        break;
      }
    }

    setState(() {
      _events = events;
      _selectedEvents = _getEventsForDay(_selectedDay);
    });
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
      child: Container(
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
