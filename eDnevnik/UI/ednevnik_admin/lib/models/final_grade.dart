import 'package:json_annotation/json_annotation.dart';
part "final_grade.g.dart";


@JsonSerializable()
class FinalGrade{
  int? zakljucnaOcjenaID;
  int? korisnikID;
  int? predmetID;
  double? vrijednostZakljucneOcjene;

  FinalGrade(this.zakljucnaOcjenaID,this.korisnikID,this.predmetID,this.vrijednostZakljucneOcjene);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory FinalGrade.fromJson(Map<String, dynamic> json) => _$FinalGradeFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$FinalGradeToJson(this);

}