import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';

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

  @override
  void initState() {
    super.initState();
    _events = {
      _normalizeDate(DateTime(2024, 4, 1)): ['10:30 Math Class', '12:00 Biology Class', '14:00 Physics Class'],
      _normalizeDate(DateTime(2024, 4, 2)): ['10:30 History Class', '12:00 Math Class'],
      _normalizeDate(DateTime(2024, 4, 3)): ['10:30 Math Class', '14:00 Physics Class'],
      _normalizeDate(DateTime(2024, 4, 4)): ['12:00 Biology Class', '14:00 Physics Class'],
      _normalizeDate(DateTime(2024, 4, 5)): ['07:30 Gym Class', '10:30 Math Class'],
      _normalizeDate(DateTime(2024, 4, 10)): ['Day Off'],
    };
    _selectedEvents = _getEventsForDay(_selectedDay);
  }

  DateTime _normalizeDate(DateTime date) {
    return DateTime(date.year, date.month, date.day);
  }

  List<String> _getEventsForDay(DateTime day) {
    return _events[_normalizeDate(day)] ?? [];
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Kalendar'),
        actions: [
          IconButton(
            icon: const Icon(Icons.filter_list),
            onPressed: () {
            },
          ),
        ],
      ),
      body: Column(
        children: [
          TableCalendar(
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
          ),
          const SizedBox(height: 8.0),
          Expanded(
            child: ListView.builder(
              itemCount: _selectedEvents.length,
              itemBuilder: (context, index) {
                return Card(
                  child: ListTile(
                    title: Text(_selectedEvents[index]),
                  ),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}