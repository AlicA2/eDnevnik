import 'package:flutter/material.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';

class HelpPage extends StatelessWidget {
  const HelpPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final List<String> predmetiHelpItems = [
      "Na ovom ekranu biti će prikazani predmeti koje škola može imati i koje možete dodavati",
      "Bitna napomena je da predmeti imaju StateMachine i tako da bi obrisali neki predmet morate StateMachine postaviti u 'draft' stanje",
      "Filtracije se rade na osnovu škole automatski",
      "Svako polje ima validaciju kod dodavanja i editovanja predmeta"
    ];

    final List<String> porukeHelpItems = [
      "Na ovome ekranu će dolaziti poruke od učenika i razrednik će moći odgovarati na njih pomoću ikone koja se nalazi zadnja u tabeli",
      "Također ovdje će se moći pravdati časovi ukoliko to bude trebalo",
    ];

    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20.0),
            ),
            child: Column(
              children: [
                _buildScreenHeader(),
                SizedBox(height: 16.0),
                _buildMainHeader(),
                SizedBox(height: 16.0),
                _buildSectionHeader("Predmeti ekran"),
                _buildHelpItemsList(predmetiHelpItems),
                SizedBox(height: 16.0),
                _buildSectionHeader("Druga sekcija"),
                _buildHelpItemsList(porukeHelpItems),
                SizedBox(height: 16.0),
                _buildSectionHeader("Treća sekcija"),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenHeader() {
    return Row(
      children: [
        Container(
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(5),
              topLeft: Radius.circular(20),
              topRight: Radius.elliptical(5, 5),
              bottomRight: Radius.circular(30.0),
            ),
          ),
          padding: const EdgeInsets.all(16.0),
          child: Text(
            "Pomoć i podrška",
            style: TextStyle(
              color: Colors.white,
              fontSize: 18,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ],
    );
  }

  Widget _buildMainHeader() {
    return Center(
      child: Text(
        "Objašnjenje funkcionalnosti aplikacije",
        textAlign: TextAlign.center,
        style: TextStyle(
          fontSize: 24,
          fontWeight: FontWeight.bold,
        ),
      ),
    );
  }

  Widget _buildSectionHeader(String title) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8.0),
      child: Text(
        title,
        style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
        ),
      ),
    );
  }

  Widget _buildHelpItemsList(List<String> items) {
    return ListView.builder(
      shrinkWrap: true,
      padding: const EdgeInsets.all(16.0),
      itemCount: items.length,
      itemBuilder: (context, index) {
        return Padding(
          padding: const EdgeInsets.symmetric(vertical: 8.0),
          child: Text(
            '${index + 1}. ${items[index]}',
            style: TextStyle(fontSize: 18),
          ),
        );
      },
    );
  }
}
