import 'package:json_annotation/json_annotation.dart';
part "department.g.dart";


@JsonSerializable()
class Department{
  int? odjeljenjeID;
  String? nazivOdjeljenja;
  int? razrednikID;
  int? skolaID;

  Department(this.odjeljenjeID,this.nazivOdjeljenja,this.razrednikID,this.skolaID);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Department.fromJson(Map<String, dynamic> json) => _$DepartmentFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$DepartmentToJson(this);

}

// {
//   "result": [
//     {
//       "odjeljenjeID": 0,
//       "nazivOdjeljenja": "string",
//       "razrednikID": 0,
//       "ucenici": [
//         {
//           "korisnikId": 0,
//           "ime": "string",
//           "prezime": "string",
//           "email": "string",
//           "telefon": "string",
//           "stateMachine": "string",
//           "korisnickoIme": "string",
//           "lozinkaHash": "string",
//           "lozinkaSalt": "string",
//           "korisniciUloge": [
//             {
//               "korisnikUlogaID": 0,
//               "korisnikID": 0,
//               "ulogaID": 0,
//               "datumIzmjene": "2024-07-02T11:49:04.047Z",
//               "uloga": {
//                 "ulogaID": 0,
//                 "naziv": "string",
//                 "opis": "string"
//               }
//             }
//           ]
//         }
//       ]
//     }
//   ],
//   "count": 0
// }