import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/screens/department_subject_screen.dart';
import 'package:ednevnik_admin/screens/student_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/screens/single_department_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class DepartmentDetailScreen extends StatefulWidget {
  const DepartmentDetailScreen({Key? key}) : super(key: key);

  @override
  State<DepartmentDetailScreen> createState() => _DepartmentDetailScreenState();
}

class _DepartmentDetailScreenState extends State<DepartmentDetailScreen> {
  SearchResult<Department>? result;
  List<School> _schools = [];
  School? _selectedSchool;

  late DepartmentProvider _departmentProvider;
  late UserProvider _userProvider;
  late SchoolProvider _schoolProvider;

  final TextEditingController _ftsController = TextEditingController();
  final TextEditingController _nazivSifraController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _schoolProvider = context.read<SchoolProvider>();
    _fetchSchools();
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = _schools.first;
            _fetchDepartments();
          }
        });
      }
    } catch (e) {
    }
  }

  Future<void> _fetchDepartments() async {
    var data = await _departmentProvider.get(filter: {
      'fts': _ftsController.text,
      'NazivOdjeljenja': _nazivSifraController.text,
      'SkolaID': _selectedSchool?.skolaID,
    });
    if (mounted) {
      setState(() {
        result = data;
      });
    }
  }

  Future<void> _navigateToAddEditDepartment([Department? department]) async {
    final shouldRefresh = await Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) =>
            SingleDepartmentListScreen(department: department),
      ),
    );

    if (shouldRefresh == true) {
      await _fetchDepartments();
    }
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
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                _buildSearch(),
                SizedBox(height: 16.0),
                Expanded(child: _buildDataListView()),
                SizedBox(height: 16.0),
                Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: ElevatedButton(
                    onPressed: () => _navigateToAddEditDepartment(),
                    style: ElevatedButton.styleFrom(
                      foregroundColor: Colors.white,
                      backgroundColor: Colors.blue,
                    ),
                    child: Text("Dodaj odjeljenje"),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenHeader() {
    return Row(
      children: [
        Container(
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
            "Odjeljenja",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        SizedBox(width: 16.0),
        Expanded(
          child: _buildSchoolDropdown(),
        ),
      ],
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
                prefixIcon: Icon(Icons.search),
              ),
              controller: _nazivSifraController,
            ),
          ),
          SizedBox(width: 20),
          ElevatedButton(
            onPressed: () async { await _fetchDepartments();},
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            child: Text("Pretraga"),
          ),
        ],
      ),
    );
  }

  Widget _buildSchoolDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 210,
          child: DropdownButton<School>(
            value: _selectedSchool,
            items: _schools.map((school) {
              return DropdownMenuItem<School>(
                value: school,
                child: Text(school.naziv ?? "N/A"),
              );
            }).toList(),
            onChanged: (School? newValue) {
              setState(() {
                _selectedSchool = newValue;
              });
              _fetchDepartments();
            },
          ),
        ),
      ],
    );
  }

  Widget _buildDataListView() {
    final rows = result?.result.asMap().entries.map((entry) {
      int index = entry.key;
      Department e = entry.value;
      return DataRow(
        cells: [
          DataCell(Text(e.nazivOdjeljenja ?? "N/A")),
          DataCell(
            e.razrednikID != null
                ? FutureBuilder<User>(
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
                  )
                : Text("N/A"),
          ),
          DataCell(
            ElevatedButton(
              onPressed: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => DepartmentSubjectDetailScreen(
                      departmentID: e.odjeljenjeID,
                    ),
                  ),
                );
              },
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.blue,
              ),
              child: Text("Prikaz predmeta"),
            ),
          ),
          DataCell(
          ElevatedButton(
            onPressed: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => StudentDetailScreen(
                    departmentID: e.odjeljenjeID,
                  ),
                ),
              );
            },
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
              child: Text("Prikaz učenika"),
            ),
          ),
          DataCell(
            IconButton(
              icon: Icon(Icons.edit),
              onPressed: () => _navigateToAddEditDepartment(e),
            ),
          ),
        ],
      );
    }).toList() ??
    [];

    return SingleChildScrollView(
      child: DataTable(
        columns: const [
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
          DataColumn(
            label: Expanded(
              child: Text(
                "Predmeti",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          ),
          DataColumn(
            label: Expanded(
              child: Text(
                "Učenici",
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
        rows: rows,
      ),
    );
  }
}
