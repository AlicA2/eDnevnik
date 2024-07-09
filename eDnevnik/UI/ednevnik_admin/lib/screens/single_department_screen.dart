import 'dart:convert';
import 'dart:io';

import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class SingleDepartmentListScreen extends StatefulWidget {
  Department? department;
  SingleDepartmentListScreen({Key? key, this.department}) : super(key: key);

  @override
  State<SingleDepartmentListScreen> createState() =>
      _SingleDepartmentListScreenState();
}

class _SingleDepartmentListScreenState extends State<SingleDepartmentListScreen> {

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String,dynamic> _initialValue = {};
  late DepartmentProvider _departmentProvider; // Deklaracija providera koji će nam vraćati s API-a
  late UserProvider _userProvider; // Deklaracija providera koji će nam vraćati s API-a


  SearchResult<User>? userResult; // Primjer korištenja 
  SearchResult<Department>? departmentResult; // Primjer korištenja 


  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _initialValue = {
      'Naziv Odjeljenja': widget.department?.nazivOdjeljenja,
      'Razrednik': widget.department?.razrednikID,
      //'stateMachine': widget.subject?.stateMachine
    };
    
    _departmentProvider = context.read<DepartmentProvider>(); // Za vraćanje podataka s API-a
    _userProvider = context.read<UserProvider>(); // Za vraćanje podataka s API-a
    // _subjectProvider = context.read<SubjectProvider>(); // Za vraćanje podataka s API-a


    initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

    //     if(widget.subject!=null){
    //   setState(() {
    //   _formKey.currentState?.patchValue({
    //     'naziv': widget.subject?.naziv,
    //   });
    //   });
    // }
  }

  Future initForm() async{ // za dobavljanje podataka s API-a
    userResult = await _userProvider.get();
    departmentResult = await _departmentProvider.get();

    
    print(userResult);
    print(departmentResult);
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(

      // child: _buildForm(),
      child: Column(
        children: [
          _buildForm(),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
               ElevatedButton(
              onPressed: () async {
               if(widget.department!=null && widget.department!.odjeljenjeID!=null){
                try{
                  print('Deleting subject with ID: ${widget.department!.odjeljenjeID}');
                  await _departmentProvider.delete(widget.department!.odjeljenjeID!);
                  Navigator.pop(context);
                }catch(e){
                  showDialog(context: context, builder: (BuildContext context)=>
                  AlertDialog(
                    title: Text("Error"),
                    content: Text(e.toString()),
                    actions: [
                      TextButton(onPressed: ()=>
                      Navigator.pop(context), child: Text("OK"))
                    ],
                  ));
                }
               }
              },
              child: Text("Izbriši Odjeljenje")),

              Padding(
                padding: const EdgeInsets.all(20.0),
                child: ElevatedButton(onPressed: () async {
                  _formKey.currentState?.saveAndValidate();
                  print(_formKey.currentState?.value);

                  var request = new Map.from(_formKey.currentState!.value);

                  // request['Slika'] = _base64Image; // Za sliku

                  print(request['Slika']);

                  try{
                    if(widget.department == null){
                      _departmentProvider.Insert(request);
                    }else{
                      await _departmentProvider.Update(widget.department!.odjeljenjeID!,_formKey.currentState?.value);
                    }
                  }on Exception catch (e) {
                      // TODO
                      showDialog(context: context, builder: (BuildContext context)=>AlertDialog(
                        title:Text("Error"),
                        content: Text(e.toString()),
                        actions: [
                          TextButton(onPressed: ()=>Navigator.pop(context), child: Text("OK"),)
                        ]
                      ));
                  }

                }, child: Text('Sačuvaj')),
              ),
             
            ],
          )
        ],
      ),
      tittle: this.widget.department?.nazivOdjeljenja ?? "Lista Odjeljenja",
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            FormBuilderTextField(
              decoration: InputDecoration(
                        labelText: "Naziv ili šifra Odjeljenja"),
              name: 'naziv',
            ),
            SizedBox(height: 20,),
            FormBuilderTextField(
              decoration: InputDecoration(
                        labelText: "Opis predmeta"),
              name: 'opis',
            ),
            // SizedBox(height: 20,),
            // FormBuilderField(
            //   builder: (field) {
            //     return InputDecorator(
            //       decoration: InputDecoration(
            //         label: Text('Odaberite sliku'),
            //         errorText: field.errorText,
            //       ),
            //       child: ListTile(
            //         leading: Icon(Icons.photo),
            //         title: Text('Select image'),
            //         trailing: Icon(Icons.file_upload),
            //         onTap: getImage,
            //       ),
            //     );
            //   },
            //   name: 'imageID',
            // ),
          ],
        ),
      ),
    );
  }
  
File? _image;
String? _base64Image;

  Future getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if(result!=null && result.files.single.path !=null){
      _image = File(result.files.single.path!);
      _base64Image=base64Encode(_image!.readAsBytesSync());
    }
  }
}