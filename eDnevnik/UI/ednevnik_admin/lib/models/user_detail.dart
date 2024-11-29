import 'package:json_annotation/json_annotation.dart';

/// This allows the `User` class to access private members in
/// the generated file. The value for this is *.g.dart, where
/// the star denotes the source file name.
part 'user_detail.g.dart';

@JsonSerializable()
class UserDetail {
  int? korisnikDetaljiID;
  int? korisnikID;
  int? godinaStudija;
  bool? obnavljaGodinu;
  int? prosjecnaOcjena;
  int? godinaUpisaID;
  int? upisanaSkolskaGodinaID;
  

  UserDetail(this.korisnikDetaljiID,this.korisnikID,this.godinaStudija,this.obnavljaGodinu,this.prosjecnaOcjena,this.godinaUpisaID,this.upisanaSkolskaGodinaID);


 /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory UserDetail.fromJson(Map<String, dynamic> json) => _$UserDetailFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserDetailToJson(this);

}
