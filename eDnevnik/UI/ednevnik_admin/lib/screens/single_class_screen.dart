import 'package:ednevnik_admin/models/classes.dart';
import 'package:flutter/material.dart';

class SingleClassListScreen extends StatelessWidget {
  final Classes? classes;

  const SingleClassListScreen({Key? key, this.classes}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(classes == null ? "Dodaj čas" : "Detalji časa"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            TextFormField(
              initialValue: classes?.nazivCasa ?? '',
              decoration: InputDecoration(labelText: "Naziv časa"),
            ),
            TextFormField(
              initialValue: classes?.opis ?? '',
              decoration: InputDecoration(labelText: "Opis"),
            ),
            ElevatedButton(
              onPressed: () {
                // Implement save or update functionality
              },
              child: Text(classes == null ? "Dodaj" : "Ažuriraj"),
            ),
          ],
        ),
      ),
    );
  }
}
