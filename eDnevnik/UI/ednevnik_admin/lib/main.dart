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
import 'package:ednevnik_admin/screens/single_subject_screen.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
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

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // TRY THIS: Try running your application with "flutter run". You'll see
        // the application has a purple toolbar. Then, without quitting the app,
        // try changing the seedColor in the colorScheme below to Colors.green
        // and then invoke "hot reload" (save your changes or press the "hot
        // reload" button in a Flutter-supported IDE, or press "r" if you used
        // the command line to start the app).
        //
        // Notice that the counter didn't reset back to zero; the application
        // state is not lost during the reload. To reset the state, use hot
        // restart instead.
        //
        // This works for code too, not just values: Most code changes can be
        // tested with just a hot reload.
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
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
    return Text(title!);
  }
}

class Counter extends StatefulWidget {
  const Counter({Key? key}) : super(key: key);

  @override
  State<Counter> createState() => _CounterState();
}

class _CounterState extends State<Counter> {
  int _count = 0;

  void _incrementCounter() {
    setState(() {
      _count++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text('You have pushed button $_count times'),
        ElevatedButton(
          onPressed: _incrementCounter,
          child: Text("Pritisni"),
        )
      ],
    );
  }
}

class LayoutExamples extends StatelessWidget {
  const LayoutExamples({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          height: 150,
          color: Colors.red,
          child: Center(
            child: Container(
              height: 100,
              color: Colors.blue,
              child: Text("eDnevnik"),
              alignment: Alignment.center,
            ),
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [Text("Item 1"), Text("Item 2"), Text("Item 3")],
        )
      ],
    );
  }
}

class MyMaterialApp extends StatelessWidget {
  const MyMaterialApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Material app',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: LoginPage(),
    );
  }
}

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();

  @override
  Widget build(BuildContext context) {
    UserProvider _userProvider = context.read<UserProvider>();
    return Scaffold(
      appBar: AppBar(
        title: Text("Prijava"),
        backgroundColor: Colors.blue,
      ),
      body: Center(
        child: SingleChildScrollView(
          child: Container(
            constraints: BoxConstraints(maxWidth: 400, maxHeight: 500),
            child: Card(
              child: Padding(
                padding: const EdgeInsets.all(20.0),
                child: Column(
                  children: [
                    Image.asset(
                      "assets/images/eDnevnik.png",
                      height: 200,
                      width: 300,
                    ),
                    TextField(
                      decoration: InputDecoration(
                          labelText: "Korisničko ime",
                          prefixIcon: Icon(Icons.email)),
                      controller: _usernameController,
                    ),
                    SizedBox(height: 10),
                    TextField(
                      decoration: InputDecoration(
                          labelText: "Lozinka",
                          prefixIcon: Icon(Icons.password)),
                      controller: _passwordController,
                      obscureText: true,
                    ),
                    SizedBox(height: 10),
                    ElevatedButton(
                      onPressed: () async {
                        var username = _usernameController.text;
                        var password = _passwordController.text;

                        Authorization.username = username;
                        Authorization.password = password;
                        try {
                          var loginData = await _userProvider.getLogedWithRole(
                              username, password);

                          if (loginData != null &&
                              loginData['uloga'] == 'admin') {
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => SubjectDetailScreen(),
                              ),
                            );
                          } else {
                            showDialog(
                              context: context,
                              builder: (BuildContext context) => AlertDialog(
                                title: Text("Greška"),
                                content: Text("Nemate dozvolu za pristup."),
                                actions: [
                                  TextButton(
                                    onPressed: () => Navigator.pop(context),
                                    child: Text("OK"),
                                  ),
                                ],
                              ),
                            );
                          }
                        } on Exception catch (e) {
                          showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                              title: Text("Greška"),
                              content: Text(e.toString()),
                              actions: [
                                TextButton(
                                  onPressed: () => Navigator.pop(context),
                                  child: Text("OK"),
                                )
                              ],
                            ),
                          );
                        }
                      },
                      child: Text("Prijava"),
                    )
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
