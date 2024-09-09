// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'school.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

School _$SchoolFromJson(Map<String, dynamic> json) => School(
      skolaID: (json['skolaID'] as num?)?.toInt(),
      naziv: json['naziv'] as String?,
      adresa: json['adresa'] as String?,
      grad: json['grad'] as String?,
      drzava: json['drzava'] as String?,
    );

Map<String, dynamic> _$SchoolToJson(School instance) => <String, dynamic>{
      'skolaID': instance.skolaID,
      'naziv': instance.naziv,
      'adresa': instance.adresa,
      'grad': instance.grad,
      'drzava': instance.drzava,
    };
