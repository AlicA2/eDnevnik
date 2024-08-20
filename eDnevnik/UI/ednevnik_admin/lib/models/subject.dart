import 'package:ednevnik_admin/models/grade.dart';
import 'package:json_annotation/json_annotation.dart';

/// This allows the `User` class to access private members in
/// the generated file. The value for this is *.g.dart, where
/// the star denotes the source file name.
part 'subject.g.dart';

 @JsonSerializable()
class Subject{
  int? predmetID;
  int? skolaID;
  String? naziv;
  String? opis;
  String? stateMachine;
  double? zakljucnaOcjena;
  List<Grade>? ocjene;

  Subject(this.predmetID,this.naziv,this.opis,this.stateMachine,this.skolaID,this.zakljucnaOcjena,[this.ocjene]);

 /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Subject.fromJson(Map<String, dynamic> json) => _$SubjectFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$SubjectToJson(this);

}


    // {
    //   "predmetID": 0,
    //   "naziv": "string",
    //   "opis": "string",
    //   "stateMachine": "string"
    // }