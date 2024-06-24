import 'package:ednevnik_admin/main.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class PredmetListScreen extends StatefulWidget {
  const PredmetListScreen({Key? key}) : super(key: key);

  @override
  State<PredmetListScreen> createState() => _PredmetListScreenState();
}

class _PredmetListScreenState extends State<PredmetListScreen> {
  @override
  Widget build(BuildContext context) {
  return Container(
    child: Column(children: [
      Text("Test"),
      SizedBox(height: 10,),
        ElevatedButton(onPressed: (){
          print("login proceed");
          Navigator.of(context).pop();
        }, child: Text("Back"))
    ]),
  );
}
}