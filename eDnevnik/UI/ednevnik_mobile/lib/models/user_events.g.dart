// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_events.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserEvents _$UserEventsFromJson(Map<String, dynamic> json) => UserEvents(
      (json['dogadjajID'] as num?)?.toInt(),
      (json['korisnikID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$UserEventsToJson(UserEvents instance) =>
    <String, dynamic>{
      'dogadjajID': instance.dogadjajID,
      'korisnikID': instance.korisnikID,
    };