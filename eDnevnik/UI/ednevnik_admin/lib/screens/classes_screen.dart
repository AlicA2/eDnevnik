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

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivController = TextEditingController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _classesProvider = context.read<ClassesProvider>();
    _fetchClasses();
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
          "Časovi",
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
                labelText: "Naziv",
              ),
              controller: _nazivController,
            ),
          ),
          ElevatedButton(
            onPressed: _fetchClasses,
            child: Text("Pretraga"),
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
                "",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
        ],
        rows: result?.result.asMap().entries.map((entry) {
          int index = entry.key + 1;
          Classes e = entry.value;
          return DataRow(
            cells: [
              DataCell(Text(index.toString())),
              DataCell(Text(e.nazivCasa ?? "")),
              DataCell(Text(e.opis ?? "")),
              DataCell(
                IconButton(
                  icon: Icon(Icons.edit),
                  onPressed: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => SingleClassListScreen(classes: e),
                      ),
                    );
                  },
                ),
              ),
            ],
          );
        }).toList() ?? [],
      ),
    );
  }

  Widget _buildAddButton() {
    return Padding(
      padding: const EdgeInsets.only(right: 20.0, bottom: 20.0),
      child: Align(
        alignment: Alignment.centerRight,
        child: ElevatedButton(
          onPressed: () {
            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => SingleClassListScreen(classes: null),
              ),
            );
          },
          child: Text("Dodaj čas"),
        ),
      ),
    );
  }
}
