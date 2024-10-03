// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'events.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Events _$EventsFromJson(Map<String, dynamic> json) => Events(
      (json['dogadjajID'] as num?)?.toInt(),
      json['nazivDogadjaja'] as String?,
      json['opisDogadjaja'] as String?,
      json['slika'] as String?,
      json['datumDogadjaja'] == null
          ? null
          : DateTime.parse(json['datumDogadjaja'] as String),
      json['stateMachine'] as String?,
      (json['skolaID'] as num?)?.toInt(),
      (json['korisniciDogadjaji'] as List<dynamic>?)
          ?.map((e) => UserEvents.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$EventsToJson(Events instance) => <String, dynamic>{
      'dogadjajID': instance.dogadjajID,
      'nazivDogadjaja': instance.nazivDogadjaja,
      'opisDogadjaja': instance.opisDogadjaja,
      'slika': instance.slika,
      'datumDogadjaja': instance.datumDogadjaja?.toIso8601String(),
      'stateMachine': instance.stateMachine,
      'skolaID': instance.skolaID,
      'korisniciDogadjaji': instance.korisniciDogadjaji,
    };
