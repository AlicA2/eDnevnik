import 'package:ednevnik_admin/models/user.dart';
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

  final TextEditingController _ftsController = TextEditingController();
  final TextEditingController _nazivSifraController = TextEditingController();
  final TextEditingController _replyController = TextEditingController();

  User? loggedInUser;
  List<User>? students;
  int? selectedUcenikID;

  @override
  void initState() {
    super.initState();
    _messageProvider = context.read<MessageProvider>();
    _userProvider = context.read<UserProvider>();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _fetchMessages();
      _fetchStudents();
    });
    selectedUcenikID = null;
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
  }

  Future<void> _fetchMessages() async {
    var filters = {
      'Naziv': _nazivSifraController.text,
      'FTS': _ftsController.text,
      'ProfesorID': loggedInUser?.korisnikId,
    };

    if (selectedUcenikID != null) {
      filters['UcenikID'] = selectedUcenikID;
    }

    var data = await _messageProvider.get(filter: filters);

    setState(() {
      result = data;
    });
  }

  Future<void> _fetchStudents() async {
    var data = await _messageProvider.get();
    var distinctStudents = <int, User>{};

    for (var message in data.result) {
      if (message.ucenikID != null &&
          !distinctStudents.containsKey(message.ucenikID)) {
        var user = await _userProvider.getById(message.ucenikID!);
        distinctStudents[message.ucenikID!] = user;
      }
    }

    setState(() {
      students = distinctStudents.values.toList();
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
          title: const Text('Odgovor na poruku'),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Text(message.sadrzajPoruke ?? 'N/A'),
              Padding(
                padding: const EdgeInsets.only(top: 16.0),
                child: TextField(
                  controller: _replyController,
                  decoration: const InputDecoration(labelText: 'Vaš odgovor'),
                ),
              ),
            ],
          ),
          actions: [
            TextButton(
              child: const Text('Zatvori'),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.black, backgroundColor: Colors.white),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            ElevatedButton(
              child: const Text('Pošalji poruku'),
              style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white, backgroundColor: Colors.green),
              onPressed: () async {
                message.odgovor = _replyController.text;
                await _messageProvider.Update(message.porukaID!, message);
                Navigator.of(context).pop();
                setState(() {
                  _replyController.clear();
                });

                ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(
                  content: const Text("Odgovor uspješno poslan"),
                  backgroundColor: Colors.green,
                ),
              );


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
                SizedBox(height: 16.0),
                _buildSearch(),
                Expanded(child: _buildDataListView()),
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
          "Poruke",
          style: TextStyle(
            color: Colors.white,
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            children: [
              Expanded(
                child: _buildUcenikDropdown(),
              ),
              SizedBox(width: 20),
              ElevatedButton(
                style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white,
                  backgroundColor: Colors.blue,
                ),
                onPressed: () async {
                  await _fetchMessages();
                },
                child: Text("Pretraga"),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildUcenikDropdown() {
    return DropdownButtonFormField<User?>(
      decoration: const InputDecoration(
        labelText: "Filtriraj po učeniku",
      ),
      value: selectedUcenikID == null
          ? null
          : students?.firstWhere((user) => user.korisnikId == selectedUcenikID,
              orElse: () =>
                  User(0, "", "", "", "", "", "", "", null, null, null)),
      onChanged: (User? newValue) {
        setState(() {
          selectedUcenikID = newValue?.korisnikId;
        });
      },
      items: [
        DropdownMenuItem<User?>(
          value: null,
          child: Text("Svi učenici"),
        ),
        ...?students?.map((User user) {
          return DropdownMenuItem<User>(
            value: user,
            child: Text("${user.ime} ${user.prezime}"),
          );
        }).toList(),
      ],
      isExpanded: true,
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: DataTable(
        columns: const [
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
                "Sadržaj poruke",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Datum slanja",
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
          DataColumn(
            label: Expanded(
              child: Text(
                "",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
        ],
        rows: result?.result.asMap().entries.map((entry) {
              int index = entry.key;
              Message e = entry.value;

              return DataRow(
                cells: [
                  DataCell(
                    FutureBuilder<String>(
                      future: getUserName(e.ucenikID ?? 0),
                      builder: (context, snapshot) {
                        if (snapshot.connectionState ==
                            ConnectionState.waiting) {
                          return const Text("Loading...");
                        } else if (snapshot.hasError) {
                          return const Text("Error");
                        } else {
                          return Text(snapshot.data ?? "Unknown");
                        }
                      },
                    ),
                  ),
                  DataCell(Text(e.sadrzajPoruke ?? "")),
                  DataCell(Text(DateFormat('dd/MM/yyyy')
                      .format(e.datumSlanja ?? DateTime.now()))),
                  DataCell(Text(e.odgovor ?? "")),
                  DataCell(
                    Row(
                      children: [
                        Tooltip(
                          message: "Odgovorite na poruku",
                          child: IconButton(
                            icon: Icon(
                              Icons.reply,
                              color: e.odgovor != null && e.odgovor!.isNotEmpty
                                  ? Colors.grey
                                  : Colors.blue,
                            ),
                            onPressed: e.odgovor != null && e.odgovor!.isNotEmpty
                                ? null
                                : () async {
                                    _replyToMessage(e);
                                  },
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
                onSelectChanged: null,
              );
            }).toList() ??
            [],
      ),
    );
  }
}
