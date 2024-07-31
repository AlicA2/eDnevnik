import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/single_department_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class DepartmentDetailScreen extends StatefulWidget {
  const DepartmentDetailScreen({Key? key}) : super(key: key);

  @override
  State<DepartmentDetailScreen> createState() => _DepartmentDetailScreenState();
}

class _DepartmentDetailScreenState extends State<DepartmentDetailScreen> {
  SearchResult<Department>? result;
  late DepartmentProvider _departmentProvider;
  late UserProvider _userProvider;

  TextEditingController _ftsController = TextEditingController();
  TextEditingController _nazivSifraController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _fetchDepartments();
  }

  Future<void> _fetchDepartments() async {
    var data = await _departmentProvider.get(filter: {
      'fts': _ftsController.text,
      'NazivOdjeljenja': _nazivSifraController.text
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
      tittle: "Odjeljenja",
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
              controller: _nazivSifraController,
            ),
          ),
          SizedBox(width: 10),
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Šifra"),
              controller: _ftsController,
            ),
          ),
          ElevatedButton(
            onPressed: _fetchDepartments,
            child: Text("Pretraga"),
          ),
          ElevatedButton(
            onPressed: () async {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => SingleDepartmentListScreen(
                    department: null,
                  ),
                ),
              );
            },
            child: Text("Dodaj odjeljenje"),
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
                  "Naziv odjeljenja",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: Expanded(
                child: Text(
                  "Razrednik",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
          ],
          rows: result?.result
                  .map((Department e) => DataRow(
                        onSelectChanged: (selected) {
                          if (selected == true) {
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => SingleDepartmentListScreen(
                                  department: e,
                                ),
                              ),
                            );
                          }
                        },
                        cells: [
                          DataCell(Text(e.odjeljenjeID.toString() ?? "")),
                          DataCell(Text(e.nazivOdjeljenja ?? "N/A")),
                          DataCell(FutureBuilder<User>(
                            future: _userProvider.getById(e.razrednikID!),
                            builder: (context, snapshot) {
                              if (snapshot.connectionState == ConnectionState.waiting) {
                                return CircularProgressIndicator();
                              } else if (snapshot.hasError) {
                                return Text("Error");
                              } else {
                                var user = snapshot.data;
                                var ime = user?.ime ?? '';
                                var prezime = user?.prezime ?? '';
                                return Text('$ime $prezime');
                              }
                            },
                          )),
                        ],
                      ))
                  .toList() ??
              [],
        ),
      ),
    );
  }
}
