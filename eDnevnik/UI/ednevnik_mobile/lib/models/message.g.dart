// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'message.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Message _$MessageFromJson(Map<String, dynamic> json) => Message(
      porukaID: (json['porukaID'] as num?)?.toInt(),
      profesorID: (json['profesorID'] as num?)?.toInt(),
      ucenikID: (json['ucenikID'] as num?)?.toInt(),
      sadrzajPoruke: json['sadrzajPoruke'] as String?,
      datumSlanja: json['datumSlanja'] == null
          ? null
          : DateTime.parse(json['datumSlanja'] as String),
      odgovor: json['odgovor'] as String?,
    );

Map<String, dynamic> _$MessageToJson(Message instance) => <String, dynamic>{
      'porukaID': instance.porukaID,
      'profesorID': instance.profesorID,
      'ucenikID': instance.ucenikID,
      'sadrzajPoruke': instance.sadrzajPoruke,
      'odgovor': instance.odgovor,
      'datumSlanja': instance.datumSlanja?.toIso8601String(),
    };
