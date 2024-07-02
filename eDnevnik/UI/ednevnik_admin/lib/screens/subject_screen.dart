import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/screens/department_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
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
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _predmetProvider = context.read<SubjectProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        child: Column(children: [
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
                        labelText: "Naziv ili šifra"), 
                        controller: _ftsController,              
                  ),
          ),
          SizedBox(
            width: 10,
          ),
          Expanded(
            child: TextField(
                    decoration: InputDecoration(
                        labelText: "Šifra"),  
                        controller: _nazivSifraController,             
                  ),
          ),
          ElevatedButton(
              onPressed: () async {
                print("login proceed");
                //Navigator.of(context).pop();
      
                // Navigator.of(context).push(
                //   MaterialPageRoute(builder: (context)=>
                //   const PredmetDetailScreen(),),
      
                var data = await _predmetProvider.get(filter:{
                  'fts': _ftsController.text,
                  'sifra': _nazivSifraController.text
                });
      
                setState(() {
                  result = data;
                });
      
                // print("data: ${data.result[0].opis}");
              },
              child: Text("Pretraga")),
              // _buildDataListView()
        ]),
    );
  }

  Widget _buildDataListView() {
    return Expanded(
          child: SingleChildScrollView(
            child: DataTable(
                columns: const [
                  DataColumn(
                    label: const Expanded(
                      child: Text(
                        "ID",
                        style: const TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: const Expanded(
                      child: Text(
                        "Naziv",
                        style: const TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: const Expanded(
                      child: Text(
                        "Opis",
                        style: const TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: const Expanded(
                      child: Text(
                        "State Machine",
                        style: const TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ),
                ],
                rows: result?.result
                        .map((Subject e) => DataRow(cells: [
                              DataCell(Text(e.predmetID.toString() ?? "")),
                              DataCell(Text(e.naziv ?? "")),
                              DataCell(Text(e.opis ?? "")),
                              DataCell(Text(e.stateMachine ?? "")),
                            ]))
                        .toList() ??
                    []),
          )
        );
  }
}
