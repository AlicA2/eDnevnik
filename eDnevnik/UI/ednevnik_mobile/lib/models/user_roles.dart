import 'package:ednevnik_admin/models/roles.dart';
import 'package:json_annotation/json_annotation.dart';

/// This allows the `User` class to access private members in
/// the generated file. The value for this is *.g.dart, where
/// the star denotes the source file name.
part 'user_roles.g.dart';

@JsonSerializable()
class UsersRoles {
  int? korisnikUlogaID;
  int? korisnikID;
  int? ulogaID;
  DateTime? datumIzmjene;
  Roles? uloga;

  UsersRoles(this.korisnikUlogaID,this.korisnikID,this.ulogaID,this.datumIzmjene,this.uloga);


 /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory UsersRoles.fromJson(Map<String, dynamic> json) => _$UsersRolesFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UsersRolesToJson(this);

}
