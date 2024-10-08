import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import '../models/user.dart';
import '../providers/events_provider.dart';
import '../providers/user_events_provider.dart';
import '../providers/user_provider.dart';
import '../services/stripe_service.dart';
import '../widgets/master_screen.dart';

class EventDetailsScreen extends StatefulWidget {
  final int? dogadjajID;

  const EventDetailsScreen({Key? key, required this.dogadjajID}) : super(key: key);

  @override
  _EventDetailsScreenState createState() => _EventDetailsScreenState();
}

class _EventDetailsScreenState extends State<EventDetailsScreen> {
  late EventsProvider _eventsProvider;
  late UserEventsProvider _userEventsProvider;

  String? _nazivDogadjaja;
  String? _slika;
  DateTime? _datumDogadjaja;
  String? _opisDogadjaja;
  List<dynamic> _recommendedEvents = [];
  User? loggedInUser;
  bool _hasTicket = false;
  bool _isProcessingPayment = false;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
    _eventsProvider = context.read<EventsProvider>();
    _userEventsProvider = context.read<UserEventsProvider>();

    _checkUserTicket();
    _fetchEvents();
    _fetchRecommendedEvents();
  }

  Future<void> _checkUserTicket() async {
    if (loggedInUser != null && widget.dogadjajID != null) {
      try {
        var userEvent = await _userEventsProvider.get(filter: {
          'DogadjajId': widget.dogadjajID,
          'KorisnikID': loggedInUser!.korisnikId,
        });

        if (userEvent.result.isNotEmpty) {
          setState(() {
            _hasTicket = true;
          });
        }
      } catch (e) {
        print("Failed to check for existing user event: $e");
      }
    }
  }

  Future<void> _fetchEvents() async {
    try {
      var events = await _eventsProvider.get(filter: {'DogadjajId': widget.dogadjajID});
      if (events.result.isNotEmpty && mounted) {
        setState(() {
          var event = events.result.first;
          _nazivDogadjaja = event.nazivDogadjaja;
          _slika = event.slika;
          _datumDogadjaja = event.datumDogadjaja;
          _opisDogadjaja = event.opisDogadjaja;
        });
      }
    } catch (e) {
      print(e);
    }
  }

  Future<void> _fetchRecommendedEvents() async {
    try {
      if (widget.dogadjajID != null) {
        var recommended = await _eventsProvider.recommend(widget.dogadjajID!);
        setState(() {
          _recommendedEvents = recommended;
        });
      }
    } catch (e) {
      print("Failed to fetch recommended events: $e");
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
            child: SingleChildScrollView(
              child: Column(
                children: [
                  _buildScreenHeader(),
                  const SizedBox(height: 16.0),
                  _buildEventDetails(),
                  const SizedBox(height: 16.0),
                  _buildActionButtons(),
                  const SizedBox(height: 16.0),
                  const Text(
                    "Ovo su preporučeni događaji za tebe:",
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(height: 8.0),
                  _buildRecommendedEvents(),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenHeader() {
    return Align(
      alignment: Alignment.topLeft,
      child: Container(
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
        child: Text(
          _nazivDogadjaja ?? "Događaji",
          style: const TextStyle(
            color: Colors.white,
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }

  Widget _buildEventDetails() {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildEventImage(_slika),
          const SizedBox(height: 16.0),
          if (_datumDogadjaja != null)
            Text(
              "Datum Događaja: ${_datumDogadjaja!.toLocal()}",
              style: const TextStyle(fontSize: 16, fontWeight: FontWeight.w500),
            ),
          const SizedBox(height: 16.0),
          if (_opisDogadjaja != null)
            Text(
              _opisDogadjaja!,
              style: const TextStyle(fontSize: 16),
            ),
        ],
      ),
    );
  }

  Widget _buildActionButtons() {
    return _hasTicket
        ? Stack(
      children: [
        ElevatedButton(
          onPressed: null,
          style: ElevatedButton.styleFrom(
            backgroundColor: Colors.grey,
            foregroundColor: Colors.white,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(8),
            ),
          ),
          child: const Text("Karta kupljena"),
        ),
        Positioned.fill(
          child: Opacity(
            opacity: 0.3,
            child: Container(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(8),
              ),
              child: const Center(
                child: Icon(
                  Icons.check_circle,
                  size: 80,
                  color: Colors.white,
                ),
              ),
            ),
          ),
        ),
      ],
    )
        : ElevatedButton(
      onPressed: _isProcessingPayment
          ? null
          : () async {
        setState(() {
          _isProcessingPayment = true;
        });

        try {
          var paymentSuccess = await StripeService.instance.makePayment();

          if (paymentSuccess) {
            var userEventRequest = {
              'DogadjajID': widget.dogadjajID,
              'KorisnikID': loggedInUser?.korisnikId,
            };

            var userEvent = await _userEventsProvider.Insert(userEventRequest);

            if (userEvent != null) {
              print("User Event inserted successfully with ID: ${userEvent.KorisnikDogadjajID}");
              setState(() {
                _hasTicket = true;
              });
            } else {
              print("Failed to insert User Event.");
            }
          } else {
            print("Payment failed.");
          }
        } catch (e) {
          print("An error occurred while processing payment: $e");
        } finally {
          setState(() {
            _isProcessingPayment = false;
          });
        }
      },
      style: ElevatedButton.styleFrom(
        backgroundColor: Colors.green,
        foregroundColor: Colors.white,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(8),
        ),
      ),
      child: const Text("Kupi kartu"),
    );
  }

  Widget _buildEventImage(String? slika) {
    if (slika != null && slika.isNotEmpty) {
      try {
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
      } catch (e) {
        return _buildPlaceholderImage();
      }
    } else {
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
      child: const Icon(Icons.image, size: 50, color: Colors.grey),
    );
  }

  Widget _buildRecommendedEvents() {
    return Container(
      height: 300,
      child: _recommendedEvents.isNotEmpty
          ? ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: _recommendedEvents.length,
        itemBuilder: (context, index) {
          var event = _recommendedEvents[index];
          return _buildEventCard(event);
        },
      )
          : const Center(
        child: Text("No recommended events available."),
      ),
    );
  }

  Widget _buildEventCard(dynamic event) {
    return Padding(
      padding: const EdgeInsets.only(right: 16.0),
      child: Card(
        elevation: 4,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(15),
        ),
        child: SizedBox(
          width: 200,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Text(
                  event.nazivDogadjaja ?? "No Name",
                  style: const TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
                  textAlign: TextAlign.center,
                  maxLines: 2,
                  overflow: TextOverflow.ellipsis,
                ),
              ),
              const SizedBox(height: 8),
              Flexible(
                flex: 2,
                child: _buildEventImage(event.slika),
              ),
              const SizedBox(height: 8),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 8.0),
                height: 30,
                alignment: Alignment.center,
                child: Text(
                  event.datumDogadjaja != null
                      ? DateFormat('yyyy-MM-dd').format(event.datumDogadjaja!)
                      : "No Date",
                  style: const TextStyle(color: Colors.grey, fontSize: 14),
                  textAlign: TextAlign.center,
                ),
              ),
              const SizedBox(height: 8),
              ElevatedButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => EventDetailsScreen(dogadjajID: event.dogadjajId),
                    ),
                  );
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue,
                  foregroundColor: Colors.white,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8),
                  ),
                ),
                child: const Text("Prikaži detalje"),
              ),
              const SizedBox(height: 8),
            ],
          ),
        ),
      ),
    );
  }
}
