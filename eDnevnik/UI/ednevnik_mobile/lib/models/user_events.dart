import 'package:json_annotation/json_annotation.dart';
part "user_events.g.dart";


@JsonSerializable()
class UserEvents{
  int? KorisnikDogadjajID;
  int? dogadjajID;
  int? korisnikID;

  UserEvents(this.dogadjajID,this.korisnikID);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory UserEvents.fromJson(Map<String, dynamic> json) => _$UserEventsFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserEventsToJson(this);

}