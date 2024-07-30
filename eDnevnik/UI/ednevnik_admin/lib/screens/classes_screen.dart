import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/screens/single_class_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ClassesDetailScreen extends StatefulWidget {
  final int? annualPlanProgramID;

  const ClassesDetailScreen({Key? key, this.annualPlanProgramID}) : super(key: key);

  @override
  State<ClassesDetailScreen> createState() => _ClassesDetailScreenState();
}


class _ClassesDetailScreenState extends State<ClassesDetailScreen> {
  SearchResult<Classes>? result;
  late ClassesProvider _classesProvider;

  TextEditingController _ftsController = new TextEditingController();
  TextEditingController _nazivController = new TextEditingController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _classesProvider = context.read<ClassesProvider>();
    _fetchClasses(); // Fetch classes based on the passed ID
  }

Future<void> _fetchClasses() async {
  var filter = {
    'godisnjiPlanProgramID': widget.annualPlanProgramID?.toString(),
    'fts': _ftsController.text,
    'nazivCasa': _nazivController.text,
  };

  print("Fetching classes with filter: $filter");
  var data = await _classesProvider.get(filter: filter);
  print("Fetched data: ${data.result}");

  setState(() {
    result = data;
  });
}


  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        child: Column(children: [
          _buildSearch(),
          _buildDataListView(),
        ]),
      ),
      tittle: "Časovi",
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
                labelText: "Naziv ili šifra"
              ), 
              controller: _ftsController,              
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: TextField(
              decoration: InputDecoration(
                labelText: "Naziv"
              ),  
              controller: _nazivController,             
            ),
          ),
          ElevatedButton(
            onPressed: _fetchClasses,
            child: Text("Pretraga")
          ),
          ElevatedButton(
            onPressed: () async {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => SingleClassListScreen(classes: null,),
                ),
              );
            },
            child: Text("Dodaj čas")
          )
        ]
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
          ],
          rows: result?.result
              .map((Classes e) => DataRow(
                onSelectChanged: (selected) {
                  if (selected == true) {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => SingleClassListScreen(classes: e,),
                      ),
                    );
                  }
                },
                cells: [
                  DataCell(Text(e.casoviID.toString())),
                  DataCell(Text(e.nazivCasa ?? "")),
                  DataCell(Text(e.opis ?? "")),
                ]
              ))
              .toList() ?? []
        ),
      )
    );
  }
}
