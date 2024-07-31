import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class SingleDepartmentListScreen extends StatefulWidget {
  Department? department;
  SingleDepartmentListScreen({Key? key, this.department}) : super(key: key);

  @override
  State<SingleDepartmentListScreen> createState() => _SingleDepartmentListScreenState();
}

class _SingleDepartmentListScreenState extends State<SingleDepartmentListScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late DepartmentProvider _departmentProvider;
  late UserProvider _userProvider;

  SearchResult<User>? userResult;
  SearchResult<Department>? departmentResult;
  List<DropdownMenuItem<String>> _razrednikDropdownItems = [];
  String? _selectedRazrednikID;

  @override
  void initState() {
    super.initState();

    _initialValue = {
      'nazivOdjeljenja': widget.department?.nazivOdjeljenja ?? "",
      'razrednikID': widget.department?.razrednikID.toString() ?? "",
    };

    _departmentProvider = context.read<DepartmentProvider>();
    _userProvider = context.read<UserProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

    if (widget.department != null) {
      setState(() {
        _formKey.currentState?.patchValue({
          'nazivOdjeljenja': widget.department?.nazivOdjeljenja ?? "",
          'razrednikID': widget.department?.razrednikID.toString() ?? "",
        });
      });
    }
  }

  Future initForm() async {
    userResult = await _userProvider.get();
    departmentResult = await _departmentProvider.get();

    setState(() {
      _razrednikDropdownItems = _buildRazrednikDropdownItems();
      if (widget.department != null) {
        _selectedRazrednikID = widget.department?.razrednikID?.toString();
      }
    });
  }

  List<DropdownMenuItem<String>> _buildRazrednikDropdownItems() {
    if (userResult == null || userResult!.result == null) {
      return [];
    }

    var filteredUsers = userResult!.result!.where((user) =>
        user.uloge!.any((role) => role.ulogaID == 1));

    var dropdownItems = filteredUsers.map((user) {
      return DropdownMenuItem<String>(
        value: user.korisnikId.toString(),
        child: Text('${user.ime} ${user.prezime}'),
      );
    }).toList();

    return dropdownItems;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            _buildForm(),
            SizedBox(height: 20),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                ElevatedButton(
                    onPressed: () async {
                      if (widget.department != null &&
                          widget.department!.odjeljenjeID != null) {
                        try {
                          print(
                              'Deleting department with ID: ${widget.department!.odjeljenjeID}');
                          await _departmentProvider
                              .delete(widget.department!.odjeljenjeID!);
                          Navigator.pop(context);
                        } catch (e) {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) => AlertDialog(
                                    title: Text("Error"),
                                    content: Text(e.toString()),
                                    actions: [
                                      TextButton(
                                          onPressed: () =>
                                              Navigator.pop(context),
                                          child: Text("OK"))
                                    ],
                                  ));
                        }
                      }
                    },
                    child: Text("Izbriši Odjeljenje")),
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: ElevatedButton(
                      onPressed: () async {
                        _formKey.currentState?.saveAndValidate();
                        print(_formKey.currentState?.value);

                        var request =
                            new Map.from(_formKey.currentState!.value);

                        try {
                          if (widget.department == null) {
                            _departmentProvider.Insert(request);
                          } else {
                            await _departmentProvider.Update(
                                widget.department!.odjeljenjeID!,
                                _formKey.currentState?.value);
                          }
                        } on Exception catch (e) {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) => AlertDialog(
                                      title: Text("Error"),
                                      content: Text(e.toString()),
                                      actions: [
                                        TextButton(
                                          onPressed: () =>
                                              Navigator.pop(context),
                                          child: Text("OK"),
                                        )
                                      ]));
                        }
                      },
                      child: Text('Sačuvaj')),
                ),
              ],
            )
          ],
        ),
      ),
      tittle: this.widget.department?.nazivOdjeljenja ?? "Lista Odjeljenja",
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 8.0),
            child: FormBuilderTextField(
              decoration: InputDecoration(
                  labelText: "Naziv ili šifra odjeljenja"),
              name: 'nazivOdjeljenja',
              validator: (value) {
                final regex = RegExp(r'^\d[A-Za-z]$');
                if (value == null || !regex.hasMatch(value)) {
                  return 'Unesite jednu brojku i jedno slovo (npr. 1A, 2B)';
                }
                return null;
              },
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
              // Use isExpanded to make sure the dropdown takes full width
            ),
          ),
        ],
      ),
    );
  }

  // File? _image;
  // String? _base64Image;

  // Future getImage() async {
  //   var result = await FilePicker.platform.pickFiles(type: FileType.image);

  //   if (result != null && result.files.single.path != null) {
  //     _image = File(result.files.single.path!);
  //     _base64Image = base64Encode(_image!.readAsBytesSync());
  //   }
  // }
}
