import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../screens/calendar_screen.dart';
import '../screens/help_support_screen.dart';
import '../screens/info_student_screen.dart';
import '../screens/messages_screen.dart';
import '../screens/report_screen.dart';
import '../screens/subject_screen.dart';
import '../screens/user_profile_screen.dart';

class MasterScreenWidget extends StatefulWidget {
  final Widget? child;
  final Widget? title_widget;

  MasterScreenWidget({
    this.child,
    this.title_widget,
    Key? key,
  }) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  void _showLogoffDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Odjava"),
          content: Text("Da li ste sigurni da želite se odjaviti?"),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("Odustani"),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
                Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) => LoginPage(),
                ));
              },
              child: Text("Odjava"),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    UserProvider userProvider = context.watch<UserProvider>();
    String imePrezime = userProvider.loggedInUser != null
        ? "${userProvider.loggedInUser!.ime} ${userProvider.loggedInUser!.prezime}"
        : "";

    return Scaffold(
      appBar: AppBar(
        leading: Builder(
          builder: (context) {
            return IconButton(
              icon: Icon(Icons.menu),
              onPressed: () {
                Scaffold.of(context).openDrawer();
              },
            );
          },
        ),
        automaticallyImplyLeading: false,
        title: Row(
          children: [
            RichText(
              text: TextSpan(
                children: [
                  TextSpan(
                    text: 'e',
                    style: TextStyle(
                        color: Colors.blue.withOpacity(0.8),
                        fontSize: 30,
                        fontWeight: FontWeight.bold),
                  ),
                  TextSpan(
                    text: 'Dnevnik',
                    style: TextStyle(
                        color: Colors.grey.withOpacity(0.8),
                        fontSize: 30,
                        fontWeight: FontWeight.bold),
                  ),
                ],
              ),
            ),
            SizedBox(width: 16),
            widget.title_widget ?? Container(),
          ],
        ),
        backgroundColor: Colors.white,
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            SizedBox(height:16),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "Općenito",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            ListTile(
              leading: Icon(Icons.library_books),
              title: Text("Početna"),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => const SubjectDetailScreen(),
                ));
              },
            ),
            ListTile(
              leading: Icon(Icons.message),
              title: Text("Poruke"),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => MessageDetailScreen(),
                ));
              },
            ),
            ListTile(
              leading: Icon(Icons.calendar_today),
              title: Text("Kalendar"),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => CalendarDetailScreen(),
                ));
              },
            ),
            //ListTile(
              //leading: Icon(Icons.insert_chart),
              //title: Text("Plan i program"),
              //onTap: () {
                //Navigator.of(context).push(MaterialPageRoute(
                  //builder: (context) => YearlyPlanAndProgramDetailScreen(),
                //));
              //},
            //),
            //ListTile(
              //leading: Icon(Icons.bar_chart),
              //title: Text("Izvještaj"),
              //onTap: () {
                //Navigator.of(context).push(MaterialPageRoute(
                 // builder: (context) => ReportDetailScreen(),
               // ));
             // },
            //),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "Nastava",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            ListTile(
              leading: Icon(Icons.person),
              title: Text("Ocjene"),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => InfoStudentDetailScreen(),
                ));
              },
            ),
            Divider(),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "Korisničke postavke",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            ListTile(
              leading: CircleAvatar(
                radius: 12,
                child: Icon(Icons.person, size: 16),
              ),
              title: Text(imePrezime),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => ProfilScreen(),
                ));
              },
            ),
            ListTile(
              leading: Icon(Icons.logout),
              title: Text("Odjavi se"),
              onTap: _showLogoffDialog,
            ),
          ],
        ),
      ),
      body: widget.child!,
    );
  }
}
