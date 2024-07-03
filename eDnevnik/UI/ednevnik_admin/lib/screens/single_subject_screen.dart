import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class SingleSubjectListScreen extends StatefulWidget {
  Subject? subject;
  SingleSubjectListScreen({Key? key, this.subject}) : super(key: key);

  @override
  State<SingleSubjectListScreen> createState() =>
      _SingleSubjectListScreenState();
}

class _SingleSubjectListScreenState extends State<SingleSubjectListScreen> {

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String,dynamic> _initialValue = {};
  late DepartmentProvider _departmentProvider; // Deklaracija providera koji će nam vraćati s API-a
  late UserProvider _userProvider; // Deklaracija providera koji će nam vraćati s API-a
  late SubjectProvider _subjectProvider;


  SearchResult<User>? userResult; // Primjer korištenja 
  SearchResult<Department>? departmentResult; // Primjer korištenja 


  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _initialValue = {
      'naziv': widget.subject?.naziv,
      'opis': widget.subject?.opis,
      'stateMachine': widget.subject?.stateMachine
    };
    
    _departmentProvider = context.read<DepartmentProvider>(); // Za vraćanje podataka s API-a
    _userProvider = context.read<UserProvider>(); // Za vraćanje podataka s API-a
    _subjectProvider = context.read<SubjectProvider>(); // Za vraćanje podataka s API-a


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
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: ElevatedButton(onPressed: () async {
                  _formKey.currentState?.saveAndValidate();
                  print(_formKey.currentState?.value);

                  try{
                    if(widget.subject == null){
                      _subjectProvider.Insert(_formKey.currentState?.value);
                    }else{
                      await _subjectProvider.Update(widget.subject!.predmetID!,_formKey.currentState?.value);
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
      tittle: this.widget.subject?.naziv ?? "Lista Predmeta",
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
                        labelText: "Naziv ili šifra predmeta"),
              name: 'naziv',
            ),
            SizedBox(height: 20,),
            FormBuilderTextField(
              decoration: InputDecoration(
                        labelText: "Opis predmeta"),
              name: 'opis',
            ),
           
          ],
        ),
      ),
    );
  }
}
