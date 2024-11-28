import 'package:ednevnik_admin/models/roles.dart';
import 'package:ednevnik_admin/models/user_roles.dart';
import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()

class User{
 int? korisnikId;
 String? ime;
 String? prezime;
 String? email;
 String? telefon;
 String? korisnickoIme;
 String? password;
 String? passwordPotvrda;
 int? odjeljenjeID;
List<UsersRoles>? korisniciUloge;
List<Roles>? uloge;

User(this.korisnikId,this.ime,this.prezime,this.email,this.telefon,this.korisnickoIme,this.password,this.passwordPotvrda, this.korisniciUloge, this.uloge,this.odjeljenjeID);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserToJson(this);
}