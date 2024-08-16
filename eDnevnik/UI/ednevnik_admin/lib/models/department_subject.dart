import 'package:json_annotation/json_annotation.dart';
part "department_subject.g.dart";


@JsonSerializable()
class DepartmentSubject{
  int? odjeljenjePredmetID;
  int? predmetID;
  int? odjeljenjeID;

  DepartmentSubject(this.odjeljenjePredmetID,this.predmetID,this.odjeljenjeID);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory DepartmentSubject.fromJson(Map<String, dynamic> json) => _$DepartmentSubjectFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$DepartmentSubjectToJson(this);

}
