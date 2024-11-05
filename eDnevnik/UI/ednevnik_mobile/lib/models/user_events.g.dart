// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_events.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserEvents _$UserEventsFromJson(Map<String, dynamic> json) => UserEvents(
      (json['korisnikDogadjajID'] as num?)?.toInt(),
      (json['dogadjajId'] as num?)?.toInt(),
      (json['korisnikID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$UserEventsToJson(UserEvents instance) =>
    <String, dynamic>{
      'korisnikDogadjajID': instance.korisnikDogadjajID,
      'dogadjajId': instance.dogadjajId,
      'korisnikID': instance.korisnikID,
    };
