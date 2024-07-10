import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/single_department_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
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

  TextEditingController _ftsController = new TextEditingController();
  TextEditingController _nazivSifraController = new TextEditingController();

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
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
      child: Row(children: [
        Expanded(
          child: TextField(
            decoration: InputDecoration(labelText: "Naziv ili šifra"),
            controller: _ftsController,
          ),
        ),
        SizedBox(
          width: 10,
        ),
        Expanded(
          child: TextField(
            decoration: InputDecoration(labelText: "Šifra"),
            controller: _nazivSifraController,
          ),
        ),
        ElevatedButton(
            onPressed: () async {
              // print("login proceed");
              //Navigator.of(context).pop();

              // Navigator.of(context).push(
              //   MaterialPageRoute(builder: (context)=>
              //   const PredmetDetailScreen(),),

              var data = await _departmentProvider.get(filter: {
                'fts': _ftsController.text,
                'sifra': _nazivSifraController.text
              });

              setState(() {
                result = data;
              });

              // print("data: ${data.result[0].opis}");
            },
            child: Text("Pretraga")),
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
            child: Text("Dodaj odjeljenje"))
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
                  "Naziv odjeljenja",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            DataColumn(
              label: const Expanded(
                child: Text(
                  "Razrednik",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
          ],
          rows: result?.result
                  .map((Department e) => DataRow(
                          onSelectChanged: (selected) => {
                                if (selected == true)
                                  {
                                    Navigator.of(context).push(
                                      MaterialPageRoute(
                                        builder: (context) =>
                                            SingleDepartmentListScreen(
                                          department: e,
                                        ),
                                      ),
                                    )
                                  }
                              },
                          cells: [
                            DataCell(Text(e.odjeljenjeID.toString() ?? "")),
                            DataCell(Text(e.nazivOdjeljenja ?? "")),
                            DataCell(FutureBuilder<User>(
                                future: _userProvider.getById(e.razrednikID!),
                                builder: (context, snapshot) {
                                  if (snapshot.connectionState ==
                                      ConnectionState.waiting) {
                                    return CircularProgressIndicator();
                                  } else if (snapshot.hasError) {
                                    return Text("Error");
                                  } else {
                                    var user = snapshot.data;
                                    var ime = user?.ime ?? '';
                                    var prezime = user?.prezime ?? '';
                                    return Text('$ime $prezime');
                                  }
                                })),
                          ]))
                  .toList() ??
              []),
    ));
  }
}
