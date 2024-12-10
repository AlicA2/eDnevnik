import 'dart:io';
import 'package:ednevnik_admin/providers/annual_plan_program_provider.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/providers/classes_students_provider.dart';
import 'package:ednevnik_admin/providers/department_provider.dart';
import 'package:ednevnik_admin/providers/department_subject_provider.dart';
import 'package:ednevnik_admin/providers/events_provider.dart';
import 'package:ednevnik_admin/providers/grade_provider.dart';
import 'package:ednevnik_admin/providers/message_provider.dart';
import 'package:ednevnik_admin/providers/school_provider.dart';
import 'package:ednevnik_admin/providers/school_year_provider.dart';
import 'package:ednevnik_admin/providers/subject_provider.dart';
import 'package:ednevnik_admin/providers/user_detail_provider.dart';
import 'package:ednevnik_admin/providers/user_events_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/screens/subject_screen.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/material.dart' as flutter;
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import '.env';

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
      ChangeNotifierProvider(create: (_) => UserDetailProvider()),
      ChangeNotifierProvider(create: (_) => SchoolYearProvider()),
    ],
    child: const MyMaterialApp(),
  ));
}

Future<void> _setup() async {
  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey=stripePublishableKey;
  //await Stripe.instance.applySettings();
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

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final GlobalKey<FormBuilderState> _formKey = GlobalKey<FormBuilderState>();

  bool _isPasswordObscured = true;

  @override
  Widget build(BuildContext context) {
    UserProvider _userProvider = context.read<UserProvider>();

    return Scaffold(
      appBar: AppBar(
        title: const Text("Prijava"),
        backgroundColor: Colors.blue,
      ),
      body: Center(
        child: SingleChildScrollView(
          child: Container(
            constraints: const BoxConstraints(maxWidth: 400, maxHeight: 500),
            child: flutter.Card(
              child: Padding(
                padding: const EdgeInsets.all(20.0),
                child: FormBuilder(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                    children: [
                      Image.asset(
                        "assets/images/eDnevnik.png",
                        height: 200,
                        width: 300,
                      ),
                      FormBuilderTextField(
                        name: 'username',
                        controller: _usernameController,
                        decoration: const InputDecoration(
                          labelText: "Korisničko ime",
                          prefixIcon: Icon(Icons.email),
                        ),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Ovo polje je obavezno"),
                        ]),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'password',
                        controller: _passwordController,
                        obscureText: _isPasswordObscured,
                        decoration: InputDecoration(
                          labelText: "Lozinka",
                          prefixIcon: const Icon(Icons.password),
                          suffixIcon: IconButton(
                            icon: Icon(
                              _isPasswordObscured
                                  ? Icons.visibility
                                  : Icons.visibility_off,
                            ),
                            onPressed: () {
                              setState(() {
                                _isPasswordObscured = !_isPasswordObscured;
                              });
                            },
                          ),
                        ),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Ovo polje je obavezno"),
                        ]),
                      ),
                      const SizedBox(height: 10),
                      Padding(
                        padding: const EdgeInsets.only(top:16.0),
                        child: ElevatedButton(
                          onPressed: () async {
                            if (_formKey.currentState?.saveAndValidate() ?? false) {
                              var username = _usernameController.text;
                              var password = _passwordController.text;

                              Authorization.username = username;
                              Authorization.password = password;

                              try {
                                var loginData = await _userProvider.getLogedWithRole(username, password);

                                if (loginData != null && loginData['uloga'] == 'učenik') {
                                  Navigator.of(context).push(
                                    MaterialPageRoute(
                                      builder: (context) => SubjectDetailScreen(),
                                    ),
                                  );
                                } else {
                                  showDialog(
                                    context: context,
                                    builder: (BuildContext context) => AlertDialog(
                                      title: const Text("Greška"),
                                      content: const Text("Nemate dozvolu za pristup."),
                                      actions: [
                                        TextButton(
                                          onPressed: () => Navigator.pop(context),
                                          child: const Text("OK"),
                                        ),
                                      ],
                                    ),
                                  );
                                }
                              } on Exception catch (e) {
                                showDialog(
                                  context: context,
                                  builder: (BuildContext context) => AlertDialog(
                                    title: const Text("Greška"),
                                    content: Text(e.toString()),
                                    actions: [
                                      TextButton(
                                        onPressed: () => Navigator.pop(context),
                                        child: const Text("OK"),
                                      ),
                                    ],
                                  ),
                                );
                              }
                            }
                          },
                          style: ElevatedButton.styleFrom(
                            foregroundColor: Colors.black,
                          ),
                          child: const Text("Prijava"),
                        ),
                      ),
                    ],
                  ),
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
