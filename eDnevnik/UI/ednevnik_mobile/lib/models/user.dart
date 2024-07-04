import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()

class User{
 int? korisnikId;
 String? ime;
 String? prezime;
 String? email;
 String? telefon;
 String? stateMachine;
 String? korisnickoIme;
 String? lozinka;

User(this.korisnikId,this.ime,this.prezime,this.email,this.telefon,this.stateMachine,this.korisnickoIme,this.lozinka);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserToJson(this);
}


// {
//   "result": [
//     {
//       "korisnikId": 0,
//       "ime": "string",
//       "prezime": "string",
//       "email": "string",
//       "telefon": "string",
//       "stateMachine": "string",
//       "korisnickoIme": "string",
//       "lozinkaHash": "string",
//       "lozinkaSalt": "string",
//       "korisniciUloge": [
//         {
//           "korisnikUlogaID": 0,
//           "korisnikID": 0,
//           "ulogaID": 0,
//           "datumIzmjene": "2024-07-02T11:26:25.619Z",
//           "uloga": {
//             "ulogaID": 0,
//             "naziv": "string",
//             "opis": "string"
//           }
//         }
//       ]
//     }
//   ],
//   "count": 0
// }