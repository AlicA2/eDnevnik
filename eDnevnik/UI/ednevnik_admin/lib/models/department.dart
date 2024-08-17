import 'package:ednevnik_admin/models/user.dart';
import 'package:json_annotation/json_annotation.dart';
part "department.g.dart";


@JsonSerializable()
class Department{
  int? odjeljenjeID;
  String? nazivOdjeljenja;
  int? razrednikID;
  int? skolaID;
  List<User>? ucenici;

  Department(this.odjeljenjeID,this.nazivOdjeljenja,this.razrednikID,this.skolaID,[this.ucenici]);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Department.fromJson(Map<String, dynamic> json) => _$DepartmentFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$DepartmentToJson(this);

}