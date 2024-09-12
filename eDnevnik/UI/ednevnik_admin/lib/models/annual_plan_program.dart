import 'package:ednevnik_admin/models/classes.dart';
import 'package:json_annotation/json_annotation.dart';
part "annual_plan_program.g.dart";


@JsonSerializable()
class AnnualPlanProgram{
  int? godisnjiPlanProgramID;
  int? brojCasova;
  String? naziv;
  int? predmetID;
  int? odjeljenjeID;
  int? skolaID;
  int? profesorID;
  // List<Classes> casovi = [];

  AnnualPlanProgram(this.godisnjiPlanProgramID,this.brojCasova,this.naziv,this.predmetID, this.odjeljenjeID,this.skolaID,this.profesorID);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory AnnualPlanProgram.fromJson(Map<String, dynamic> json) => _$AnnualPlanProgramFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$AnnualPlanProgramToJson(this);

}