import 'package:json_annotation/json_annotation.dart';

part 'school_year.g.dart';

@JsonSerializable()
class SchoolYear {
  int? skolskaGodinaID;
  String? naziv;

  SchoolYear({this.skolskaGodinaID, this.naziv});
  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory SchoolYear.fromJson(Map<String, dynamic> json) =>
      _$SchoolYearFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$SchoolYearToJson(this);
}