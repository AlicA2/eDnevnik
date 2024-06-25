import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';

class OdjeljenjeListScreen extends StatefulWidget {
  const OdjeljenjeListScreen({Key? key}) : super(key:key);

  @override
  State<OdjeljenjeListScreen> createState() => _OdjeljenjeListScreenState();
}

class _OdjeljenjeListScreenState extends State<OdjeljenjeListScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Text("Details"),
      tittle: "Lista Predmeta",
    );
  }
}