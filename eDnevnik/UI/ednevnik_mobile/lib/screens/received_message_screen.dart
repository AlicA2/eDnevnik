import 'package:flutter/material.dart';

class ReceivedMessagesScreen extends StatelessWidget {
  const ReceivedMessagesScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Primljene poruke'),
      ),
      body: Center(
        child: Text('Ovdje će se prikazati primljene poruke.'),
      ),
    );
  }
}
