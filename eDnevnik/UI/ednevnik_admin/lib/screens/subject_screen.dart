import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class SubjectDetailScreen extends StatefulWidget {
  const SubjectDetailScreen({Key? key}) : super(key: key);

  @override
  State<SubjectDetailScreen> createState() => _SubjectDetailScreenState();
}

class _SubjectDetailScreenState extends State<SubjectDetailScreen> {
  SearchResult<Subject>? result;
  late SubjectProvider _predmetProvider;

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivSifraController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _predmetProvider = context.read<SubjectProvider>();
    _fetchSubjects();
  }

  Future<void> _fetchSubjects() async {
    var data = await _predmetProvider.get(filter: {
      'fts': _ftsController.text,
      'sifra': _nazivSifraController.text
    });

    setState(() {
      result = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: Color(0xFFF7F2FA),
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
                _buildAddButton(),
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
          "Predmeti",
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
                child: TextField(
                  decoration: InputDecoration(
                    labelText: "Naziv ili šifra",
                    prefixIcon: Icon(Icons.search),
                  ),
                  controller: _ftsController,
                ),
              ),
              SizedBox(width: 20),
              Expanded(
                child: TextField(
                  decoration: InputDecoration(
                    labelText: "Šifra",
                    prefixIcon: Icon(Icons.search),
                  ),
                  controller: _nazivSifraController,
                ),
              ),
              SizedBox(width: 20),
              ElevatedButton(
                onPressed: _fetchSubjects,
                child: Text("Pretraga"),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: DataTable(
        columns: const [
          DataColumn(
            label: Expanded(
              child: Text(
                "Redni broj",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Naziv",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Opis",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "State Machine",
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
        rows: result?.result
                .asMap()
                .entries
                .map((entry) {
                  int index = entry.key + 1;
                  Subject e = entry.value;
                  return DataRow(
                    cells: [
                      DataCell(Text(index.toString())),
                      DataCell(Text(e.naziv ?? "")),
                      DataCell(Text(e.opis ?? "")),
                      DataCell(Text(e.stateMachine ?? "")),
                      DataCell(IconButton(
                        icon: Icon(Icons.edit),
                        onPressed: () async {
                          final result = await Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => SingleSubjectListScreen(subject: e),
                            ),
                          );
                          if (result == 'updated' || result == 'deleted') {
                            _fetchSubjects();
                          }
                        },
                      )),
                    ],
                  );
                })
                .toList() ??
            [],
      ),
    );
  }

  Widget _buildAddButton() {
    return Padding(
      padding: const EdgeInsets.only(right: 20.0, bottom: 20.0),
      child: Align(
        alignment: Alignment.centerRight,
        child: ElevatedButton(
          onPressed: () async {
            final result = await Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => SingleSubjectListScreen(subject: null),
              ),
            );
            if (result == 'added' || result == 'updated' || result == 'deleted') {
              _fetchSubjects();
            }
          },
          child: Text("Dodaj predmet"),
        ),
      ),
    );
  }
}
