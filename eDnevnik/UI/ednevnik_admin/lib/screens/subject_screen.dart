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

  TextEditingController _ftsController = new TextEditingController();
  TextEditingController _nazivSifraController = new TextEditingController();

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
        child: Column(
          children: [
            _buildSearch(),
            _buildDataListView(),
          ],
        ),
      ),
      tittle: "Predmeti",
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                labelText: "Naziv ili šifra",
              ),
              controller: _ftsController,
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                labelText: "Šifra",
              ),
              controller: _nazivSifraController,
            ),
          ),
          ElevatedButton(
            onPressed: _fetchSubjects,
            child: Text("Pretraga"),
          ),
          ElevatedButton(
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
                  "ID",
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
          ],
          rows: result?.result
                  .map((Subject e) => DataRow(
                        onSelectChanged: (selected) async {
                          if (selected == true) {
                            final result = await Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => SingleSubjectListScreen(subject: e),
                              ),
                            );
                            if (result == 'updated' || result == 'deleted') {
                              _fetchSubjects();
                            }
                          }
                        },
                        cells: [
                          DataCell(Text(e.predmetID.toString() ?? "")),
                          DataCell(Text(e.naziv ?? "")),
                          DataCell(Text(e.opis ?? "")),
                          DataCell(Text(e.stateMachine ?? "")),
                        ],
                      ))
                  .toList() ??
              [],
        ),
      ),
    );
  }
}
