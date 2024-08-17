import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/utils/department_delete_custom_exception.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class SingleDepartmentListScreen extends StatefulWidget {
  Department? department;
  SingleDepartmentListScreen({Key? key, this.department}) : super(key: key);

  @override
  State<SingleDepartmentListScreen> createState() =>
      _SingleDepartmentListScreenState();
}

class _SingleDepartmentListScreenState
    extends State<SingleDepartmentListScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late DepartmentProvider _departmentProvider;
  late UserProvider _userProvider;
  late SchoolProvider _schoolProvider;

  List<School> _schools = [];
  School? _selectedSchool;

  SearchResult<User>? userResult;
  List<DropdownMenuItem<String>> _razrednikDropdownItems = [];
  String? _selectedRazrednikID;

  @override
  void initState() {
    super.initState();

    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();
    _schoolProvider = context.read<SchoolProvider>();

    _fetchSchools();
    _initForm();
  }

  Future<void> _fetchSchools() async {
    try {
      var schools = await _schoolProvider.get();
      if (mounted) {
        setState(() {
          _schools = schools.result;
          if (_schools.isNotEmpty) {
            _selectedSchool = widget.department != null
                ? _schools.firstWhere(
                    (school) => school.skolaID == widget.department?.skolaID,
                    orElse: () => _schools.first)
                : _schools.first;
          }
        });
      }
    } catch (e) {}
  }

  Future<void> _initForm() async {
    userResult = await _userProvider.get();
    if (mounted) {
      setState(() {
        _razrednikDropdownItems = _buildRazrednikDropdownItems();
      });
    }

    if (widget.department != null) {
      _formKey.currentState?.patchValue({
        'nazivOdjeljenja': widget.department?.nazivOdjeljenja ?? "",
        'razrednikID': widget.department?.razrednikID?.toString() ?? "",
        'skolaID': widget.department?.skolaID?.toString() ?? "",
      });
      _selectedRazrednikID = widget.department?.razrednikID?.toString();
    }
  }

  List<DropdownMenuItem<String>> _buildRazrednikDropdownItems() {
    if (userResult == null || userResult!.result == null) {
      return [];
    }

    var filteredUsers = userResult!.result!
        .where((user) => user.uloge!.any((role) => role.ulogaID == 1));

    return filteredUsers.map((user) {
      return DropdownMenuItem<String>(
        value: user.korisnikId.toString(),
        child: Text('${user.ime} ${user.prezime}'),
      );
    }).toList();
  }

  Future<bool> _isNazivOdjeljenjaExists(String nazivOdjeljenja, int skolaID,
      [int? currentId]) async {
    var departments = await _departmentProvider.get();
    return departments.result?.any((d) =>
            d.nazivOdjeljenja == nazivOdjeljenja &&
            d.skolaID == skolaID &&
            d.odjeljenjeID != currentId) ??
        false;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(20.0),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildScreenName(),
              SizedBox(height: 16.0),
              _buildForm(),
              SizedBox(height: 20),
              _buildActionButtons(),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildScreenName() {
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
            widget.department == null
                ? "Dodavanje odjeljenja"
                : "Uređivanje odjeljenja",
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

  Widget _buildSchoolDropdown() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          width: 300,
          child: DropdownButton<School>(
            value: _selectedSchool,
            items: _schools.map((school) {
              return DropdownMenuItem<School>(
                value: school,
                child: Text(school.naziv ?? "N/A"),
              );
            }).toList(),
            onChanged: widget.department == null
                ? (School? newValue) {
                    setState(() {
                      _selectedSchool = newValue;
                    });
                  }
                : null,
            disabledHint: Text(
              _selectedSchool?.naziv ?? "N/A",
              style: TextStyle(color: Colors.grey),
            ),
          ),
        ),
      ],
    );
  }

  Widget _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: {
        'nazivOdjeljenja': widget.department?.nazivOdjeljenja ?? "",
        'razrednikID': widget.department?.razrednikID?.toString() ?? "",
      },
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 8.0),
              child: FormBuilderTextField(
                name: 'nazivOdjeljenja',
                decoration: InputDecoration(
                  labelText: "Naziv ili šifra odjeljenja",
                ),
                validator: FormBuilderValidators.compose([
                  FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.'),
                  FormBuilderValidators.match(
                    RegExp(r'^[0-9][A-Z]$'),
                    errorText:
                        'Neispravan unos, Unesite jedan broj i jedno veliko slovo (npr. 1A, 2B)',
                  ),
                ]),
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 8.0),
              child: DropdownButtonFormField<String>(
                value: _selectedRazrednikID,
                items: _razrednikDropdownItems.isNotEmpty
                    ? _razrednikDropdownItems
                    : [],
                onChanged: (value) {
                  setState(() {
                    _selectedRazrednikID = value;
                    _formKey.currentState?.patchValue({'razrednikID': value});
                  });
                },
                decoration: InputDecoration(
                  labelText: 'Razrednik',
                ),
                isExpanded: true,
                validator: FormBuilderValidators.required(
                    errorText: 'Razrednik ne smije biti prazan'),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _confirmDelete() async {
  bool? confirmDelete = await showDialog<bool>(
    context: context,
    builder: (context) => AlertDialog(
      title: Text('Potvrda brisanja'),
      content: Text('Da li ste sigurni da želite da obrišete ovo odjeljenje?'),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context, false),
          child: Text('Odustani'),
        ),
        TextButton(
          onPressed: () => Navigator.pop(context, true),
          child: Text('Obriši'),
        ),
      ],
    ),
  );

  if (confirmDelete == true) {
    try {
      if (widget.department != null && widget.department!.odjeljenjeID != null) {
        await _departmentProvider.delete(widget.department!.odjeljenjeID!);
        Navigator.pop(context, true);
      }
    } on DepartmentDeleteException catch (e) {
      _showErrorDialog(e.message);
    } catch (e) {
      _showErrorDialog('Ne možete obrisati odjeljenje koje ima predmete!');
    }
  }
}

void _showErrorDialog(String message) {
  showDialog(
    context: context,
    builder: (BuildContext context) => AlertDialog(
      title: Text("Greška"),
      content: Text(message),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context),
          child: Text("OK"),
        ),
      ],
    ),
  );
}



  Widget _buildActionButtons() {
    return Row(
      children: [
        if (widget.department != null) ...[
          SizedBox(width: 16),
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.blue,
            ),
            onPressed: () async { await _confirmDelete();},
            child: Text("Izbriši Odjeljenje"),
          ),
          SizedBox(width: 16.0),
        ],
        Spacer(),
        ElevatedButton(
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.white,
            backgroundColor: Colors.blue,
          ),
          onPressed: () {
            Navigator.pop(context);
          },
          child: Text('Odustani'),
        ),
        SizedBox(width: 16.0),
        ElevatedButton(
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.white,
            backgroundColor: Colors.blue,
          ),
          onPressed: () async {
            if (_formKey.currentState?.saveAndValidate() ?? false) {
              var formValues = _formKey.currentState!.value;
              var nazivOdjeljenja = formValues['nazivOdjeljenja'] as String;
              var razrednikID = _selectedRazrednikID;

              print(nazivOdjeljenja);
              print(razrednikID);

              if (await _isNazivOdjeljenjaExists(
                  nazivOdjeljenja,
                  _selectedSchool?.skolaID ?? 0,
                  widget.department?.odjeljenjeID)) {
                showDialog(
                  context: context,
                  builder: (BuildContext context) => AlertDialog(
                    title: Text("Greška"),
                    content: Text(
                        "Odjeljenje sa nazivom '$nazivOdjeljenja' već postoji u odabranoj školi."),
                    actions: [
                      TextButton(
                        onPressed: () => Navigator.pop(context),
                        child: Text("OK"),
                      ),
                    ],
                  ),
                );
                return;
              }

              try {
                if (widget.department == null) {
                  await _departmentProvider.Insert({
                    "NazivOdjeljenja": nazivOdjeljenja,
                    "RazrednikID": int.parse(razrednikID!),
                    "SkolaID": _selectedSchool?.skolaID ?? 0,
                  });
                } else {
                  await _departmentProvider.Update(
                      widget.department!.odjeljenjeID!, {
                    "NazivOdjeljenja": nazivOdjeljenja,
                    "RazrednikID": int.parse(razrednikID!),
                    "SkolaID": _selectedSchool?.skolaID ?? 0,
                  });
                }

                Navigator.pop(context, true);
              } catch (e) {
                showDialog(
                  context: context,
                  builder: (BuildContext context) => AlertDialog(
                    title: Text("Greška"),
                    content: Text(e.toString()),
                    actions: [
                      TextButton(
                        onPressed: () => Navigator.pop(context),
                        child: Text("OK"),
                      ),
                    ],
                  ),
                );
              }
            }
          },
          child: Text('Sačuvaj'),
        ),
      ],
    );
  }
}
