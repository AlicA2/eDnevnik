import 'package:ednevnik_admin/models/user_events.dart';
import 'package:json_annotation/json_annotation.dart';
part "events.g.dart";


@JsonSerializable()
class Events{
  int? dogadjajID;
  String? nazivDogadjaja;
  String? opisDogadjaja;
  String? slika;
  DateTime? datumDogadjaja;
  bool? jeAktivan;
  int? skolaID;
  List<UserEvents>? korisniciDogadjaji;

  Events(this.dogadjajID,this.nazivDogadjaja,this.opisDogadjaja,this.slika,this.datumDogadjaja,this.jeAktivan,this.skolaID,[this.korisniciDogadjaji]);

    /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Events.fromJson(Map<String, dynamic> json) => _$EventsFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$EventsToJson(this);

}