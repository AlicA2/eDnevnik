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

    final List<String> godisnjiPlanProgramHelpItems = [
      "Na ovom ekranu moći će se dodavati godišnji planovi i program",
      "Bitno je napomenuti da ovi planovi i programi će biti vezani striktno za odjeljenje i predmeta za to odjeljenje",
      "Broj časova je stavljen da može biti od 5 do 10 jer kada bi stavili veći broj trebalo bi sve te časove popuniti, kasnije ukoliko bude trebalo dodavati više časova možemo promjenuti u backendu i time demonstrirati Dependency Injection",
      "Broj časova se automatski popunjava u kalendaru",
      "Bitno je navesti da se mogu editovati godišnji planovi i programi, sva polja imaju svoju zasebnu validaciju",
      "Ne mogu se dodavati godišnji planovi i programi koji su već u tabeli",
      "Iz ovog ekrana možemo se prebaciti na Časovi ekran pomoću strelice prema desno"
    ];

    final List<String> casoviHelpItems = [
      "Na ovom ekranu mi dodajemo časove za taj godišnji plan i program",
      "Mora se unjeti tačan broj časova koji smo definirali u godišnjem planu i programu",
      "U dodaj časovima svako polje ima svoju validaciju",
      "Pretraga se vrši pomoću naziva časa"
    ];

    final List<String> izvjestajHelpItems = [
      "Na ovome ekranu vrši se automatsko filtriranje na osnovu vrijednosti unutar comboboxova",
      "Dugme printaj izvještaj daje pdf koji će se sačuvati na našem računaru lokalno",
    ];

    final List<String> odjeljenjaHelpItems = [
      "Na ovome ekranu prikazana su odjeljenja za određenu školu",
      "Dodavaju se predmeti i prikazivaju se učenici za određeno odjeljenje",
      "U dodavanju odjeljenja sva polja imaju svoju validaciju",
      "Moguće uređivanje odjeljenja"
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
            child: SingleChildScrollView(
              child: Column(
                children: [
                  _buildScreenHeader(),
                  Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      children: [
                        SizedBox(height: 16.0),
                        _buildMainHeader(),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Predmeti"),
                        _buildHelpItemsList(predmetiHelpItems),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Poruke"),
                        _buildHelpItemsList(porukeHelpItems),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Godišnji plan program"),
                        _buildHelpItemsList(godisnjiPlanProgramHelpItems),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Časovi"),
                        _buildHelpItemsList(casoviHelpItems),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Izvještaj"),
                        _buildHelpItemsList(izvjestajHelpItems),
                        SizedBox(height: 16.0),
                        _buildSectionHeader("Odjeljenja"),
                        _buildHelpItemsList(odjeljenjaHelpItems),
                      ],
                    ),
                  ),
                ],
              ),
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
      physics: NeverScrollableScrollPhysics(),
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
