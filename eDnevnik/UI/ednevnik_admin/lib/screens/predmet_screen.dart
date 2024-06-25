import 'package:ednevnik_admin/main.dart';
import 'package:ednevnik_admin/providers/predmet_provider.dart';
import 'package:ednevnik_admin/screens/odjeljenje_screen.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class PredmetDetailScreen extends StatefulWidget {
  const PredmetDetailScreen({Key? key}) : super(key: key);

  @override
  State<PredmetDetailScreen> createState() => _PredmetDetailScreenState();
}

class _PredmetDetailScreenState extends State<PredmetDetailScreen> {

  late PredmetProvider _predmetProvider;

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _predmetProvider = context.read<PredmetProvider>();
  }

  @override
  Widget build(BuildContext context) {
  return MasterScreenWidget(
    child: Container(
    child: Column(children: [
      Text("Test"),
      SizedBox(height: 10,),
        ElevatedButton(onPressed: () async {
          print("login proceed");
          //Navigator.of(context).pop();

          // Navigator.of(context).push(
          //   MaterialPageRoute(builder: (context)=>
          //   const PredmetDetailScreen(),),

            var data = await _predmetProvider.get();
            print("data: ${data['result'][0]['naziv']}");

        }, child: Text("Predmeti"))
    ]),
  )
  );
}
}