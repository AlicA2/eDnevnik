import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';


class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? tittle;
  Widget? title_widget;
  MasterScreenWidget({this.child,this.tittle, this.title_widget, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetStateState();
}

class _MasterScreenWidgetStateState extends State<MasterScreenWidget> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
    appBar: AppBar(
      title: widget.title_widget ?? Text(widget.tittle ?? ""),
      backgroundColor: Colors.blue,
    ),
    drawer: Drawer(
      child: ListView(
        children: [
            ListTile(
            title: Text("Back"),
            onTap:(){
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            title: Text("Predmeti"),
            onTap:(){
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=>
                  const SubjectDetailScreen(),
                )
              );
            }
          ),
           ListTile(
            title: Text("Početna"),
            onTap:(){
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=>
                  SingleSubjectListScreen(),
                )
              );
            }
          ),
               ListTile(
            title: Text("Login"),
            onTap:(){
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=>
                  LoginPage(),
                )
              );
            }
          )
        ],
      ),
    ),
    body: widget.child!,
  );
  }
}