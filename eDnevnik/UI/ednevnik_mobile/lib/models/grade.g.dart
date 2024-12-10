// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'grade.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Grade _$GradeFromJson(Map<String, dynamic> json) => Grade(
      (json['ocjenaID'] as num?)?.toInt(),
      (json['vrijednostOcjene'] as num?)?.toInt(),
      json['datum'] == null ? null : DateTime.parse(json['datum'] as String),
      json['komentar'] as String?,
      (json['korisnikID'] as num?)?.toInt(),
      (json['predmetID'] as num?)?.toInt(),
      json['isExpanded'] as bool?,
    );

Map<String, dynamic> _$GradeToJson(Grade instance) => <String, dynamic>{
      'ocjenaID': instance.ocjenaID,
      'vrijednostOcjene': instance.vrijednostOcjene,
      'datum': instance.datum?.toIso8601String(),
      'korisnikID': instance.korisnikID,
      'predmetID': instance.predmetID,
      'komentar': instance.komentar,
      'isExpanded': instance.isExpanded,
    };
