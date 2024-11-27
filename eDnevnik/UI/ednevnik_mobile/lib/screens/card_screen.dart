import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/user.dart';
import '../models/user_events.dart';
import '../models/events.dart';
import '../providers/user_events_provider.dart';
import '../providers/user_provider.dart';
import '../providers/events_provider.dart';
import '../widgets/master_screen.dart';

class CardDetailScreen extends StatefulWidget {
  const CardDetailScreen({super.key});

  @override
  State<CardDetailScreen> createState() => _CardDetailScreenState();
}

class _CardDetailScreenState extends State<CardDetailScreen> {
  User? loggedInUser;
  List<Events> userEventsList = [];
  List<UserEvents> userEvents = [];
  bool isLoading = true;
  bool hasFetchedEvents = false;

  late UserEventsProvider _userEventsProvider;
  late EventsProvider _eventsProvider;

  @override
  void initState() {
    super.initState();
    _userEventsProvider = context.read<UserEventsProvider>();
    _eventsProvider = context.read<EventsProvider>();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

    final userProvider = context.watch<UserProvider>();
    if (userProvider.loggedInUser != loggedInUser) {
      loggedInUser = userProvider.loggedInUser;
      if (loggedInUser != null && !hasFetchedEvents) {
        _fetchUserEvents();
      }
    }
  }

  Future<void> _fetchUserEvents() async {
    if (loggedInUser != null) {
      try {
        var fetchedUserEvents = await _userEventsProvider.get(filter: {'KorisnikID': loggedInUser!.korisnikId});
        userEvents = fetchedUserEvents.result;

        List<int> eventIds = userEvents.map((event) => event.dogadjajId ?? 0).toList();
        List<Events> fetchedEvents = [];
        for (int eventId in eventIds) {
          var event = await _eventsProvider.get(filter: {'DogadjajID': eventId});
          if (event.result.isNotEmpty) {
            fetchedEvents.add(event.result.first);
          }
        }

        if (mounted) {
          setState(() {
            userEventsList = fetchedEvents;
            isLoading = false;
            hasFetchedEvents = true;
          });
        }
      } catch (e) {
        print('Error fetching user events: $e');
        setState(() {
          isLoading = false;
          hasFetchedEvents = true;
        });
      }
    } else {
      setState(() {
        isLoading = false;
        hasFetchedEvents = true;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              _buildScreenName(),
              SizedBox(height: 16.0),
              Expanded(
                child: isLoading
                    ? Center(child: CircularProgressIndicator())
                    : _buildUserEventCards(),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildUserEventCards() {
    if (userEventsList.isEmpty) {
      return Center(child: Text("Nemate trenutno aktivnih rezervacija."));
    }

    return ListView.builder(
      padding: const EdgeInsets.all(16.0),
      itemCount: userEventsList.length,
      itemBuilder: (context, index) {
        Events event = userEventsList[index];
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
            ElevatedButton(
              onPressed: () {
                _showCancelConfirmationDialog(event.dogadjajId!);
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.red,
                foregroundColor: Colors.white,
              ),
              child: Text("Otkazivanje rezervacije"),
            ),
          ],
        ),
      ),
    );
  }

  void _showCancelConfirmationDialog(int dogadjajId) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Potvrda otkazivanja"),
          content: Text("Da li ste sigurni da želite otkazati rezervaciju?"),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              style: ElevatedButton.styleFrom(foregroundColor: Colors.black,backgroundColor: Colors.white),
              child: Text("Ne"),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
                _cancelReservation(dogadjajId);
              },
              style: ElevatedButton.styleFrom(foregroundColor: Colors.white,backgroundColor: Colors.red),
              child: Text("Da"),
            ),
          ],
        );
      },
    );
  }

  Future<void> _cancelReservation(int dogadjajId) async {
    try {
      var response = await _userEventsProvider.get(
        filter: {'KorisnikID': loggedInUser!.korisnikId, 'DogadjajID': dogadjajId},
      );

      if (response.result.isNotEmpty) {
        UserEvents userEvent = response.result.first;

        var eventResponse = await _eventsProvider.get(filter: {'DogadjajID': dogadjajId});
        if (eventResponse.result.isNotEmpty) {
          Events event = eventResponse.result.first;

          DateTime? eventDateTime = event.datumDogadjaja;
          if (eventDateTime == null) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text("Podaci o vremenu događaja nisu dostupni."),
                backgroundColor: Colors.red,
              ),
            );
            return;
          }

          DateTime now = DateTime.now();
          if (eventDateTime.isBefore(now)) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text("Događaj je već završen. Otkazivanje nije moguće."),
                backgroundColor: Colors.red,
              ),
            );
            return;
          }

          if (eventDateTime.difference(now).inDays < 3) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(
                content: Text("Otkazivanje nije moguće manje od 3 dana prije događaja."),
                backgroundColor: Colors.red,
              ),
            );
            return;
          }

          await _userEventsProvider.delete(userEvent.korisnikDogadjajID!);

          setState(() {
            userEvents.removeWhere((event) => event.korisnikDogadjajID == userEvent.korisnikDogadjajID);
            userEventsList.removeWhere((event) => event.dogadjajId == dogadjajId);
          });

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text("Rezervacija je uspješno otkazana."),
              backgroundColor: Colors.green,
            ),
          );

          Future.delayed(Duration(seconds: 5), () {
            if (mounted) {
              showDialog(
                context: context,
                builder: (context) => AlertDialog(
                  title: Text("Obavještenje"),
                  content: Text(
                    "Vaš povrat sredstava biće izvršen u kratkom roku. Zahvaljujemo na strpljenju.",
                  ),
                  actions: [
                    TextButton(
                      onPressed: () => Navigator.of(context).pop(),
                      child: Text("U redu"),
                    ),
                  ],
                ),
              );
            }
          });
        }
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text("Rezervacija nije pronađena."),
            backgroundColor: Colors.red,
          ),
        );
      }
    } catch (e) {
      print("Error while trying to cancel reservation: $e");
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text("Greška prilikom otkazivanja rezervacije"),
          backgroundColor: Colors.red,
        ),
      );
    }
  }






  Widget _buildScreenName() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Container(
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: const BorderRadius.only(
              bottomLeft: Radius.circular(5),
              topLeft: Radius.circular(20),
              topRight: Radius.elliptical(5, 5),
              bottomRight: Radius.circular(30.0),
            ),
          ),
          padding: const EdgeInsets.all(16.0),
          child: const Text(
            "Pregled rezervacija",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ],
    );
  }
}
