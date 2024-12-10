import 'package:ednevnik_admin/models/classes.dart';
import 'package:json_annotation/json_annotation.dart';
part "classes_students.g.dart";


@JsonSerializable()
class ClassesStudents{
  int? casoviUceniciID;
  int? casoviID;
  int? ucenikID;
  String? ime;
  String? prezime;
  bool? isPrisutan;
  bool? zakljucan;
  ClassesStudents(this.casoviUceniciID,this.casoviID,this.ucenikID,this.isPrisutan,this.zakljucan,this.ime,this.prezime);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory ClassesStudents.fromJson(Map<String, dynamic> json) => _$ClassesStudentsFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ClassesStudentsToJson(this);

}