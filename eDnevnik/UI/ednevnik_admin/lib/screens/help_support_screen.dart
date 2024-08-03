import 'package:flutter/material.dart';

class HelpPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Pomoć i podrška'),
      ),
      body: Center(
        child: Text(
          'Pomoć i podrška',
          style: TextStyle(fontSize: 24),
        ),
      ),
    );
  }
}
