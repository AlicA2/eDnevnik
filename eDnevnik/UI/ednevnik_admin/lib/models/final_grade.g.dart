// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'final_grade.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FinalGrade _$FinalGradeFromJson(Map<String, dynamic> json) => FinalGrade(
      (json['zakljucnaOcjenaID'] as num?)?.toInt(),
      (json['korisnikID'] as num?)?.toInt(),
      (json['predmetID'] as num?)?.toInt(),
      (json['vrijednostZakljucneOcjene'] as num?)?.toDouble(),
    );

Map<String, dynamic> _$FinalGradeToJson(FinalGrade instance) =>
    <String, dynamic>{
      'zakljucnaOcjenaID': instance.zakljucnaOcjenaID,
      'korisnikID': instance.korisnikID,
      'predmetID': instance.predmetID,
      'vrijednostZakljucneOcjene': instance.vrijednostZakljucneOcjene,
    };
