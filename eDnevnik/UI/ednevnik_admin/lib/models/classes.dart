import 'package:json_annotation/json_annotation.dart';
part "classes.g.dart";


@JsonSerializable()
class Classes{
  int? casoviID;
  String? nazivCasa;
  String? opis;
  int? godisnjiPlanProgramID;

  Classes(this.casoviID,this.nazivCasa,this.opis,this.godisnjiPlanProgramID);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Classes.fromJson(Map<String, dynamic> json) => _$ClassesFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ClassesToJson(this);

}