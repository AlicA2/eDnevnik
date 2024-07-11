import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/message.dart';
import 'package:ednevnik_admin/models/user.dart';
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
  UserProvider? _userProvider;

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivSifraController = TextEditingController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _messageProvider = context.read<MessageProvider>();
    if (_userProvider == null) {
      _userProvider = context.read<UserProvider>();
    }
  }

  Future<String> getUserName(int userId) async {
    try {
      if (_userProvider != null) {
        var user = await _userProvider!.getById(userId);
        return "${user.ime} ${user.prezime}";
      } else {
        return "Unknown";
      }
    } catch (e) {
      print('Error fetching user name: $e');
      return "Unknown";
    }
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
      tittle: "Messages",
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
            onPressed: () async {
              var data = await _messageProvider.get(filter: {
                'fts': _ftsController.text,
                'naziv': _nazivSifraController.text,
              });

              setState(() {
                result = data;
              });
            },
            child: Text("Pretraga"),
          ),
          ElevatedButton(
            onPressed: () {
            },
            child: Text("Dodaj poruku"),
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
          ],
          rows: result?.result.map((Message e) {
            return DataRow(
              onSelectChanged: (selected) {
                if (selected == true) {
                }
              },
              cells: [
                DataCell(Text(e.porukaID?.toString() ?? "")),
                DataCell(
                  FutureBuilder(
                    future: getUserName(e.roditeljID ?? 0),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return Text("Loading...");
                      } else if (snapshot.hasError) {
                        return Text("Error");
                      } else {
                        return Text(snapshot.data?.toString() ?? "Unknown");
                      }
                    },
                  ),
                ),
                DataCell(
                  FutureBuilder(
                    future: getUserName(e.ucenikID ?? 0),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return Text("Loading...");
                      } else if (snapshot.hasError) {
                        return Text("Error");
                      } else {
                        return Text(snapshot.data?.toString() ?? "Unknown");
                      }
                    },
                  ),
                ),
                DataCell(Text(e.sadrzajPoruke ?? "")),
                DataCell(Text(DateFormat('dd/MM/yyyy').format(e.datumSlanja ?? DateTime.now()))),
              ],
            );
          }).toList() ?? [],
        ),
      ),
    );
  }
}
