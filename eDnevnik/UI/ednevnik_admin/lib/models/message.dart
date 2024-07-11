import 'package:json_annotation/json_annotation.dart';

part 'message.g.dart';

@JsonSerializable()
class Message {
  int? porukaID;
  int? roditeljID;
  int? ucenikID;
  String? sadrzajPoruke;
  DateTime? datumSlanja;

  Message({this.porukaID, this.roditeljID, this.ucenikID, this.sadrzajPoruke, this.datumSlanja});
  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Message.fromJson(Map<String, dynamic> json) =>
      _$MessageFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$MessageToJson(this);
}


//  "porukaID": 0,
//       "profesorID": 0,
//       "roditeljID": 0,
//       "ucenikID": 0,
//       "sadrzajPoruke": "string",
//       "datumSlanja": "2024-07-10T18:06:49.610Z"