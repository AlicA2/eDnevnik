import 'dart:io';

import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/classes_students_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/events_provider.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/message_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_events_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/utils/consts.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart' as flutter; // Use alias for Flutter
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';

void main() async {
  await _setup();
  HttpOverrides.global = MyHttpOverrides();

  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => SubjectProvider()),
      ChangeNotifierProvider(create: (_) => DepartmentProvider()),
      ChangeNotifierProvider(create: (_) => MessageProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
      ChangeNotifierProvider(create: (_) => AnnualPlanProgramProvider()),
      ChangeNotifierProvider(create: (_) => ClassesProvider()),
      ChangeNotifierProvider(create: (_) => SchoolProvider()),
      ChangeNotifierProvider(create: (_) => DepartmentSubjectProvider()),
      ChangeNotifierProvider(create: (_) => GradeProvider()),
      ChangeNotifierProvider(create: (_) => ClassesStudentsProvider()),
      ChangeNotifierProvider(create: (_) => EventsProvider()),
      ChangeNotifierProvider(create: (_) => UserEventsProvider()),
    ],
    child: const MyMaterialApp(),
  ));
}

Future<void> _setup() async {
  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey = stripePublishableKey;
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return flutter.MaterialApp(
      title: 'Flutter Demo',
      theme: flutter.ThemeData(
        colorScheme: flutter.ColorScheme.fromSeed(seedColor: flutter.Colors.deepPurple),
        useMaterial3: true,
      ),
      home: LoginPage(),
    );
  }
}

class MyAppBar extends StatelessWidget {
  String? title;
  MyAppBar({Key? key, required this.title}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return flutter.Text(title!);
  }
}

class Counter extends flutter.StatefulWidget {
  const Counter({Key? key}) : super(key: key);

  @override
  _CounterState createState() => _CounterState();
}

class _CounterState extends flutter.State<Counter> {
  int _count = 0;

  void _incrementCounter() {
    setState(() {
      _count++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return flutter.Column(
      children: [
        flutter.Text('You have pushed button $_count times'),
        flutter.ElevatedButton(
          onPressed: _incrementCounter,
          child: flutter.Text("Pritisni"),
        ),
      ],
    );
  }
}

class LayoutExamples extends StatelessWidget {
  const LayoutExamples({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return flutter.Column(
      children: [
        flutter.Container(
          height: 150,
          color: flutter.Colors.red,
          child: flutter.Center(
            child: flutter.Container(
              height: 100,
              color: flutter.Colors.blue,
              child: flutter.Text("eDnevnik"),
              alignment: flutter.Alignment.center,
            ),
          ),
        ),
        flutter.Row(
          mainAxisAlignment: flutter.MainAxisAlignment.spaceAround,
          children: [flutter.Text("Item 1"), flutter.Text("Item 2"), flutter.Text("Item 3")],
        ),
      ],
    );
  }
}

class MyMaterialApp extends StatelessWidget {
  const MyMaterialApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return flutter.MaterialApp(
      title: 'Material app',
      theme: flutter.ThemeData(primarySwatch: flutter.Colors.blue),
      home: LoginPage(),
    );
  }
}

class LoginPage extends flutter.StatelessWidget {
  LoginPage({super.key});

  flutter.TextEditingController _usernameController = flutter.TextEditingController();
  flutter.TextEditingController _passwordController = flutter.TextEditingController();

  @override
  Widget build(BuildContext context) {
    UserProvider _userProvider = context.read<UserProvider>();
    return flutter.Scaffold(
      appBar: flutter.AppBar(
        title: flutter.Text("Prijava"),
        backgroundColor: flutter.Colors.blue,
      ),
      body: flutter.Center(
        child: flutter.SingleChildScrollView(
          child: flutter.Container(
            constraints: flutter.BoxConstraints(maxWidth: 400, maxHeight: 500),
            child: flutter.Card( // Resolve conflict by using flutter.Card
              child: flutter.Padding(
                padding: const flutter.EdgeInsets.all(20.0),
                child: flutter.Column(
                  children: [
                    flutter.Image.asset(
                      "assets/images/eDnevnik.png",
                      height: 200,
                      width: 300,
                    ),
                    flutter.TextField(
                      decoration: flutter.InputDecoration(
                          labelText: "Korisničko ime",
                          prefixIcon: flutter.Icon(flutter.Icons.email)),
                      controller: _usernameController,
                    ),
                    flutter.SizedBox(height: 10),
                    flutter.TextField(
                      decoration: flutter.InputDecoration(
                          labelText: "Lozinka",
                          prefixIcon: flutter.Icon(flutter.Icons.password)),
                      controller: _passwordController,
                      obscureText: true,
                    ),
                    flutter.SizedBox(height: 10),
                    flutter.ElevatedButton(
                      onPressed: () async {
                        var username = _usernameController.text;
                        var password = _passwordController.text;

                        Authorization.username = username;
                        Authorization.password = password;
                        try {
                          var loginData = await _userProvider.getLogedWithRole(username, password);
                          if (loginData != null && loginData['uloga'] == 'učenik') {
                            Navigator.of(context).push(
                              flutter.MaterialPageRoute(
                                builder: (context) => SubjectDetailScreen(),
                              ),
                            );
                          } else {
                            showDialog(
                              context: context,
                              builder: (BuildContext context) => flutter.AlertDialog(
                                title: flutter.Text("Greška"),
                                content: flutter.Text("Nemate dozvolu za pristup."),
                                actions: [
                                  flutter.TextButton(
                                    onPressed: () => Navigator.pop(context),
                                    child: flutter.Text("OK"),
                                  ),
                                ],
                              ),
                            );
                          }
                        } on Exception catch (e) {
                          showDialog(
                            context: context,
                            builder: (BuildContext context) => flutter.AlertDialog(
                              title: flutter.Text("Greška"),
                              content: flutter.Text(e.toString()),
                              actions: [
                                flutter.TextButton(
                                  onPressed: () => Navigator.pop(context),
                                  child: flutter.Text("OK"),
                                ),
                              ],
                            ),
                          );
                        }
                      },
                      child: flutter.Text("Prijava"),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback = (X509Certificate cert, String host, int port) {
        return true;
      };
  }
}
