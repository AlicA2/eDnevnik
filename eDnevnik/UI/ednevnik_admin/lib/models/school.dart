import 'package:json_annotation/json_annotation.dart';

part 'school.g.dart';

@JsonSerializable()
class School {
  int? skolaID;
  String? naziv;
  String? adresa;
  String? grad;
  String? drzava;

  School({this.skolaID, this.naziv, this.adresa, this.grad,this.drzava});
  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory School.fromJson(Map<String, dynamic> json) =>
      _$SchoolFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$SchoolToJson(this);
}