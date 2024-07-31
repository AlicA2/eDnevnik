import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/message.dart';
import 'package:ednevnik_admin/providers/message_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class MessageDetailScreen extends StatefulWidget {
  const MessageDetailScreen({Key? key}) : super(key: key);

  @override
  State<MessageDetailScreen> createState() => _MessageDetailScreenState();
}

class _MessageDetailScreenState extends State<MessageDetailScreen> {
  SearchResult<Message>? result;
  late MessageProvider _messageProvider;
  late UserProvider _userProvider;

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivSifraController = TextEditingController();
  TextEditingController _replyController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _messageProvider = context.read<MessageProvider>();
    _userProvider = context.read<UserProvider>();
    _fetchMessages();
  }

  Future<void> _fetchMessages() async {
    var data = await _messageProvider.get(filter: {
      'fts': _ftsController.text,
      'naziv': _nazivSifraController.text,
    });

    setState(() {
      result = data;
    });
  }

  Future<String> getUserName(int userId) async {
    try {
      var user = await _userProvider.getById(userId);
      return "${user.ime} ${user.prezime}";
    } catch (e) {
      return "Unknown";
    }
  }

  void _replyToMessage(Message message) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Odgovor na poruku'),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Text(message.sadrzajPoruke ?? 'N/A'),
              TextField(
                controller: _replyController,
                decoration: InputDecoration(labelText: 'Vaš odgovor'),
              ),
            ],
          ),
          actions: [
            TextButton(
              child: Text('Zatvori'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            ElevatedButton(
              child: Text('Pošalji poruku'),
              onPressed: () async {
                message.odgovor = _replyController.text;
                await _messageProvider.Update(message.porukaID!, message);
                Navigator.of(context).pop();
                setState(() {
                  _replyController.clear();
                });
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        child: Column(
          children: [
            _buildSearch(),
            _buildDataListView(),
          ],
        ),
      ),
      tittle: "Poruke",
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Naziv ili šifra"),
              controller: _ftsController,
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Šifra"),
              controller: _nazivSifraController,
            ),
          ),
          ElevatedButton(
            onPressed: _fetchMessages,
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return Expanded(
      child: SingleChildScrollView(
        child: DataTable(
          columns: const [
            DataColumn(
              label: Expanded(
                child: Text(
                  "Broj poruka",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Roditelj",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Učenik",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Sadrzaj Poruke",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Datum Slanja",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Odgovor",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
          ],
          rows: result?.result.map((Message e) {
            return DataRow(
              onSelectChanged: (selected) {
                if (selected == true) {
                  _replyToMessage(e);
                }
              },
              cells: [
                DataCell(Text(e.porukaID?.toString() ?? "")),
                DataCell(
                  FutureBuilder<String>(
                    future: getUserName(e.roditeljID ?? 0),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return Text("Loading...");
                      } else if (snapshot.hasError) {
                        return Text("Error");
                      } else {
                        return Text(snapshot.data ?? "Unknown");
                      }
                    },
                  ),
                ),
                DataCell(
                  FutureBuilder<String>(
                    future: getUserName(e.ucenikID ?? 0),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return Text("Loading...");
                      } else if (snapshot.hasError) {
                        return Text("Error");
                      } else {
                        return Text(snapshot.data ?? "Unknown");
                      }
                    },
                  ),
                ),
                DataCell(Text(e.sadrzajPoruke ?? "")),
                DataCell(Text(DateFormat('dd/MM/yyyy').format(e.datumSlanja ?? DateTime.now()))),
                DataCell(Text(e.odgovor ?? "")),
              ],
            );
          }).toList() ?? [],
        ),
      ),
    );
  }
}
