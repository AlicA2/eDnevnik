// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'subject.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Subject _$SubjectFromJson(Map<String, dynamic> json) => Subject(
      (json['predmetID'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['opis'] as String?,
      json['stateMachine'] as String?,
      (json['skolaID'] as num?)?.toInt(),
      json['isExpanded'] as bool?,
      (json['zakljucnaOcjena'] as num?)?.toDouble(),
      (json['ocjene'] as List<dynamic>?)
          ?.map((e) => Grade.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$SubjectToJson(Subject instance) => <String, dynamic>{
      'predmetID': instance.predmetID,
      'skolaID': instance.skolaID,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'stateMachine': instance.stateMachine,
      'zakljucnaOcjena': instance.zakljucnaOcjena,
      'isExpanded': instance.isExpanded,
      'ocjene': instance.ocjene,
    };
