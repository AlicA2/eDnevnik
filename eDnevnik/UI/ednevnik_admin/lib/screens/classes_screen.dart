import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/screens/single_class_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ClassesDetailScreen extends StatefulWidget {
  final int? annualPlanProgramID;
  final int? predmetID;
  const ClassesDetailScreen({Key? key, this.annualPlanProgramID, this.predmetID}) : super(key: key);

  @override
  State<ClassesDetailScreen> createState() => _ClassesDetailScreenState();
}

class _ClassesDetailScreenState extends State<ClassesDetailScreen> {
  SearchResult<Classes>? result;
  late ClassesProvider _classesProvider;
  late SubjectProvider _subjectProvider;
  Subject? _selectedSubject;

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivController = TextEditingController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _classesProvider = context.read<ClassesProvider>();
    _subjectProvider = context.read<SubjectProvider>();
    _fetchSubject();
    _fetchClasses();
  }

  Future<void> _fetchSubject() async {
    if (widget.predmetID != null) {
      try {
        var subject = await _subjectProvider.getById(widget.predmetID!);
        setState(() {
          _selectedSubject = subject;
        });
      } catch (e) {
        print("Error fetching subject: $e");
        setState(() {
          _selectedSubject = null;
        });
      }
    }
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
                _buildActionButtons(),
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
        "Časovi za predmet \"${_selectedSubject?.naziv ?? 'Nepoznati predmet'}\"",
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
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white, backgroundColor: Colors.blue,
            ),
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
                        builder: (context) => SingleClassListScreen(classes: e, annualPlanProgramID: widget.annualPlanProgramID,),
                      ),
                    ).then((result){
                      if(result ==true){
                        _fetchClasses();
                      };
                    });
                  },
                ),
              ),
            ],
          );
        }).toList() ?? [],
      ),
    );
  }

Widget _buildActionButtons() {
  return Padding(
    padding: const EdgeInsets.only(right: 20.0, bottom: 20.0),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            SizedBox(width: 16.0),
            ElevatedButton(
              onPressed: () {
                Navigator.pop(context);
              },
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white, backgroundColor: Colors.blue,
                padding: EdgeInsets.symmetric(horizontal: 16.0, vertical: 12.0),
              ),
              child: Row(
                children: [
                  Icon(Icons.arrow_back, color: Colors.white),
                  SizedBox(width: 8.0),
                  Text("Nazad"),
                ],
              ),
            ),
          ],
        ),
        ElevatedButton(
          onPressed: () {
            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => SingleClassListScreen(classes: null, annualPlanProgramID: widget.annualPlanProgramID,),
              ),
            ).then((result){
                      if(result ==true){
                        _fetchClasses();
                      };
                    });
          },
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.white, backgroundColor: Colors.blue,
            padding: EdgeInsets.symmetric(horizontal: 16.0, vertical: 12.0),
          ),
          child: Text("Dodaj čas"),
        ),
      ],
    ),
  );
}

}
