import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:ednevnik_admin/models/message.dart';
import 'package:ednevnik_admin/providers/message_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class ReceivedMessagesScreen extends StatefulWidget {
  const ReceivedMessagesScreen({Key? key}) : super(key: key);

  @override
  State<ReceivedMessagesScreen> createState() => _ReceivedMessagesScreenState();
}

class _ReceivedMessagesScreenState extends State<ReceivedMessagesScreen> {
  late MessageProvider _messageProvider;
  late UserProvider _userProvider;
  List<Message> receivedMessages = [];

  @override
  void initState() {
    super.initState();
    _messageProvider = context.read<MessageProvider>();
    _userProvider = context.read<UserProvider>();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _fetchReceivedMessages();
    });
  }

  Future<void> _fetchReceivedMessages() async {
    final loggedInUser = _userProvider.loggedInUser;
    if (loggedInUser != null) {
      var filters = {
        'UcenikID': loggedInUser.korisnikId,
        'OdgovorExists': true,
      };

      var data = await _messageProvider.get(filter: filters);
      setState(() {
        receivedMessages = data.result
            .where((message) => message.odgovor != null && message.odgovor!.isNotEmpty)
            .toList();
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
              Expanded(
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(20.0),
                  ),
                  child: SingleChildScrollView(
                    child: Column(
                      children: [
                        _buildScreenName(),
                        const SizedBox(height: 16.0),
                        receivedMessages.isEmpty
                            ? const Center(
                          child: Padding(
                            padding: EdgeInsets.all(16.0),
                            child: Text('Nema primljenih poruka s odgovorom.'),
                          ),
                        )
                            : _buildMessageList(),
                      ],
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
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
            "Odgovorene poruke",
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

  Widget _buildMessageList() {
    return ListView.builder(
      shrinkWrap: true,
      physics: const NeverScrollableScrollPhysics(),
      itemCount: receivedMessages.length,
      itemBuilder: (context, index) {
        final message = receivedMessages[index];
        return Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32.0, vertical: 8.0),
          child: Container(
            padding: const EdgeInsets.all(16.0),
            decoration: BoxDecoration(
              color: Color(0xFFF7F2FA),
              borderRadius: BorderRadius.circular(12),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                _buildBoldText('Poruka: ', message.sadrzajPoruke ?? 'N/A'),
                const SizedBox(height: 8),
                _buildBoldText('Odgovor: ', message.odgovor ?? 'Nema odgovora'),
                const SizedBox(height: 8),
                _buildBoldText(
                  'Datum: ',
                  DateFormat('dd/MM/yyyy').format(message.datumSlanja ?? DateTime.now()),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  Widget _buildBoldText(String label, String content) {
    return RichText(
      text: TextSpan(
        text: label,
        style: const TextStyle(
          fontWeight: FontWeight.bold,
          color: Colors.black,
        ),
        children: [
          TextSpan(
            text: content,
            style: const TextStyle(
              fontWeight: FontWeight.normal,
              color: Colors.black,
            ),
          ),
        ],
      ),
    );
  }
}
