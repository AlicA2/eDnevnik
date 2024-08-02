import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/screens/department_screen.dart';
import 'package:ednevnik_admin/screens/messages_screen.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:ednevnik_admin/screens/user_profile_screen.dart';
import 'package:ednevnik_admin/screens/yearly_plan_and_program_screen.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MasterScreenWidget extends StatefulWidget {
  final Widget? child;
  final Widget? title_widget;
  MasterScreenWidget({this.child, this.title_widget, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  bool _isHoveringLogoff = false;
  bool _isDrawerOpen = true;

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

  void _toggleDrawer() {
    setState(() {
      _isDrawerOpen = !_isDrawerOpen;
    });
  }

  @override
  Widget build(BuildContext context) {
    UserProvider userProvider = context.watch<UserProvider>();
    String imePrezime = userProvider.loggedInUser != null 
      ? "${userProvider.loggedInUser!.ime} ${userProvider.loggedInUser!.prezime}"
      : "";

    return Scaffold(
      appBar: AppBar(
        leading: null,
        automaticallyImplyLeading: false,
        title: Row(
          children: [
            IconButton(
              icon: Icon(_isDrawerOpen ? Icons.close : Icons.menu),
              onPressed: _toggleDrawer,
            ),
            SizedBox(width: 16),
            RichText(
              text: TextSpan(
                children: [
                  TextSpan(
                    text: 'e',
                    style: TextStyle(color: Colors.blue.withOpacity(0.8), fontSize: 30, fontWeight: FontWeight.bold),
                  ),
                  TextSpan(
                    text: 'Dnevnik',
                    style: TextStyle(color: Colors.grey.withOpacity(0.8), fontSize: 30, fontWeight: FontWeight.bold),
                  ),
                ],
              ),
            ),
            SizedBox(width: 16),
            widget.title_widget ?? Container(),
          ],
        ),
        actions: [
          PopupMenuButton(
            offset: Offset(0, 40),
            itemBuilder: (context) => [
              PopupMenuItem(
                value: 'profile',
                child: Text('Prikaži profil'),
              ),
            ],
            onSelected: (value) {
              if (value == 'profile') {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => ProfilScreen(),
                ));
              }
            },
            child: Row(
              children: [
                Text(
                  imePrezime,
                  style: TextStyle(
                    fontSize: 14,
                    color: Colors.black.withOpacity(0.7),
                  ),
                ),
                SizedBox(width: 8),
                CircleAvatar(
                  radius: 12,
                  child: Icon(
                    Icons.person,
                    size: 16,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(width: 30),
          MouseRegion(
            onEnter: (_) => setState(() => _isHoveringLogoff = true),
            onExit: (_) => setState(() => _isHoveringLogoff = false),
            child: GestureDetector(
              onTap: _showLogoffDialog,
              child: Row(
                children: [
                  Icon(
                    Icons.logout,
                    color: _isHoveringLogoff ? Colors.black.withOpacity(0.6) : Colors.black,
                    size: 16,
                  ),
                  SizedBox(width: 8),
                  Text(
                    "Odjavi se",
                    style: TextStyle(
                      color: _isHoveringLogoff ? Colors.black.withOpacity(0.6) : Colors.black,
                      fontSize: 14,
                    ),
                  ),
                ],
              ),
            ),
          ),
          SizedBox(width: 40),
        ],
        backgroundColor: Colors.white,
      ),
      body: Row(
        children: [
          if (_isDrawerOpen)
            Container(
              width: 250,
              child: Drawer(
                child: ListView(
                  children: [
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
                      leading: Icon(Icons.library_books), // Subject icon
                      title: Text("Predmeti"),
                      onTap: () {
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const SubjectDetailScreen(),
                        ));
                      },
                    ),
                    ListTile(
                      leading: Icon(Icons.message), // Message icon
                      title: Text("Poruke"),
                      onTap: () {
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => MessageDetailScreen(),
                        ));
                      },
                    ),
                    ListTile(
                      leading: Icon(Icons.insert_chart), // Dataset icon
                      title: Text("Plan i program"),
                      onTap: () {
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => YearlyPlanAndProgramDetailScreen(),
                        ));
                      },
                    ),
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
                      leading: Icon(Icons.group), // Department icon
                      title: Text("Odjeljenja"),
                      onTap: () {
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => DepartmentDetailScreen(),
                        ));
                      },
                    ),
                  ],
                ),
              ),
            ),
          Expanded(
            flex: 5,
            child: widget.child!,
          ),
        ],
      ),
    );
  }
}
