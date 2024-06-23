import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
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
      home: const LoginPage(),
    );
  }
}

class MyAppBar extends StatelessWidget {
  String? title;
  MyAppBar({Key? key, required this.title}) : super(key:key);

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

  void _incrementCounter(){
  setState(() {
    _count++;
  });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text('You have pushed button $_count times'),
        ElevatedButton(onPressed: _incrementCounter, child: Text("Pritisni"),)
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
              height:100,
              color: Colors.blue,
              child: Text("eDnevnik"),
              alignment: Alignment.center,
            ),),
        ),
      Row(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          Text("Item 1"),
          Text("Item 2"),
          Text("Item 3")
        ],
      )
    ],);
  }
}
class MyMaterialApp extends StatelessWidget {
    const MyMaterialApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return  MaterialApp(
      title: 'eDnevnik APP',
      theme: ThemeData(primarySwatch: Colors.blue,
      appBarTheme: AppBarTheme(
        backgroundColor: Colors.blue,
      )),
      home: Scaffold(
        appBar: AppBar(
          title: Text("eDnevnik Desktop App"),
        ),
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              TextField(
                decoration: InputDecoration(
                  labelText: "Enter your name"
                ),
              ),
            SizedBox(height:20,),
            ElevatedButton(onPressed: (){
              print("Button clicked");
            }, child: Text("Submit"))
            ],
          ),
        ),
        floatingActionButton: FloatingActionButton(onPressed: (){

        },
        child: Icon(Icons.add),),
        )
    );
  }
}

class LoginPage extends StatelessWidget {
  const LoginPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Login"),),
      body: Center(
        child: Container(
          width: 400,
          child: Card(
            child: Column(
              children: [
                Image.network("data:image/png;base64,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")
              ],
            ),
          ),
        )
      ),
    );
  }
}