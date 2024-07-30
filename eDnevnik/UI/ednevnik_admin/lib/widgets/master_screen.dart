import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/screens/department_screen.dart';
import 'package:ednevnik_admin/screens/messages_screen.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:ednevnik_admin/screens/user_profile_screen.dart';
import 'package:ednevnik_admin/screens/yearly_plan_and_program_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? tittle;
  Widget? title_widget;
  MasterScreenWidget({this.child, this.tittle, this.title_widget, Key? key})
      : super(key: key);

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
                title: Text("Predmeti"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => const SubjectDetailScreen(),
                  ));
                }),
            ListTile(
                title: Text("Odjeljenja"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => DepartmentDetailScreen(),
                  ));
                }),
            ListTile(
                title: Text("Poruke"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => MessageDetailScreen(),
                  ));
                }),
            ListTile(
                title: Text("Godišnji plan i program"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => YearlyPlanAndProgramDetailScreen(),
                  ));
                }),
            ListTile(
                title: Text("Login"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => LoginPage(),
                  ));
                }),
                ListTile(
                title: Text("Profil"),
                onTap: () {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => ProfilScreen(),
                  ));
                })
          ],
        ),
      ),
      body: widget.child!,
    );
  }
}
