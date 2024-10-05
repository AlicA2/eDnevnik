import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import 'package:ednevnik_admin/models/events.dart';
import 'package:ednevnik_admin/providers/events_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

import '../models/user.dart';
import '../providers/department_provider.dart';
import '../providers/user_provider.dart';
import 'event_detail_screen.dart';

class EventsDetailScreen extends StatefulWidget {
  const EventsDetailScreen({super.key});

  @override
  State<EventsDetailScreen> createState() => _EventsDetailScreenState();
}

class _EventsDetailScreenState extends State<EventsDetailScreen> {
  List<Events> _eventsList = [];
  User? loggedInUser;
  late int? userSchool;

  late EventsProvider _eventsProvider;
  late DepartmentProvider _departmentProvider;

  @override
  void initState() {
    super.initState();
    _eventsProvider = context.read<EventsProvider>();
    _departmentProvider = context.read<DepartmentProvider>();

    _fetchDepartments();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    final userProvider = context.watch<UserProvider>();
    if (userProvider.loggedInUser != loggedInUser) {
      loggedInUser = userProvider.loggedInUser;
    }
  }

  Future<void> _fetchDepartments() async {
    try {
      var departments = await _departmentProvider.get(filter: {'isUceniciIncluded': true});
      if (departments != null) {
        for (var department in departments.result) {
          if (department.ucenici != null &&
              department.ucenici!.any((user) => user.korisnikId == loggedInUser?.korisnikId)) {
            userSchool = department.skolaID;

            _fetchEvents();
            break;
          }
        }
      }
    } catch (e) {
      print('Error fetching departments: $e');
    }
  }

  Future<void> _fetchEvents() async {
    if (userSchool != null) {
      try {
        var events = await _eventsProvider.get(filter: {'SkolaID': userSchool});
        if (mounted) {
          setState(() {
            _eventsList = events.result;
          });
        }
      } catch (e) {
        setState(() {
          _eventsList = [];
        });
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
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                Expanded(child: _buildEventCards()),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildEventCards() {
    if (_eventsList.isEmpty) {
      return Center(
        child: Text("Trenutno nema događaja."),
      );
    }

    return ListView.builder(
      padding: const EdgeInsets.all(16.0),
      itemCount: _eventsList.length,
      itemBuilder: (context, index) {
        Events event = _eventsList[index];
        return Padding(
          padding: const EdgeInsets.only(bottom: 16.0),
          child: _buildEventCard(event),
        );
      },
    );
  }

  Widget _buildEventCard(Events event) {
    return Card(
      elevation: 4,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
      ),
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Text(
              event.nazivDogadjaja ?? "No Name",
              style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold),
              textAlign: TextAlign.center,
            ),
            SizedBox(height: 12),
            _buildEventImage(event.slika),
            SizedBox(height: 12),
            Text(
              event.datumDogadjaja != null
                  ? DateFormat('yyyy-MM-dd').format(event.datumDogadjaja!)
                  : "No Date",
              style: TextStyle(color: Colors.grey, fontSize: 18),
              textAlign: TextAlign.center,
            ),
            SizedBox(height: 12),
            ElevatedButton(
              onPressed: () {
                if (event.dogadjajId != null) {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => EventDetailsScreen(dogadjajID: event.dogadjajId!),
                    ),
                  );
                } else {
                  print("Error: dogadjajID is null, cannot navigate.");
                }
              },
              style: ElevatedButton.styleFrom(backgroundColor: Colors.blue, foregroundColor: Colors.white),
              child: Text("Prikaži detalje"),
            ),
            SizedBox(height: 12),
          ],
        ),
      ),
    );
  }


  Widget _buildEventImage(String? slika) {
    try {
      if (slika != null && slika.isNotEmpty) {
        return Container(
          height: 200,
          width: double.infinity,
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10),
            image: DecorationImage(
              image: MemoryImage(base64Decode(slika)),
              fit: BoxFit.cover,
            ),
          ),
        );
      } else {
        return _buildPlaceholderImage();
      }
    } catch (e) {
      return _buildPlaceholderImage();
    }
  }

  Widget _buildPlaceholderImage() {
    return Container(
      height: 200,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.grey[200],
        borderRadius: BorderRadius.circular(10),
      ),
      child: Icon(Icons.image, size: 50, color: Colors.grey),
    );
  }

  Widget _buildScreenHeader() {
    return Align(
      alignment: Alignment.topLeft,
      child: Container(
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
          "Događaji",
          style: TextStyle(
            color: Colors.white,
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }
}
