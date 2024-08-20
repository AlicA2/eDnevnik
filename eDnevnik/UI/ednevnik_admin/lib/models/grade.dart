import 'package:json_annotation/json_annotation.dart';

part "grade.g.dart";

@JsonSerializable()
class Grade {
  int? ocjenaID;
  int? vrijednostOcjene;
  DateTime? datum;
  int? korisnikID;
  int? predmetID;

  Grade(this.ocjenaID, this.vrijednostOcjene, this.datum, this.korisnikID,
      this.predmetID);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Grade.fromJson(Map<String, dynamic> json) => _$GradeFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$GradeToJson(this);
}
