// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'classes.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Classes _$ClassesFromJson(Map<String, dynamic> json) => Classes(
      (json['casoviID'] as num?)?.toInt(),
      json['nazivCasa'] as String?,
      json['opis'] as String?,
      (json['godisnjiPlanProgramID'] as num?)?.toInt(),
      json['datumOdrzavanjaCasa'] == null
          ? null
          : DateTime.parse(json['datumOdrzavanjaCasa'] as String),
    );

Map<String, dynamic> _$ClassesToJson(Classes instance) => <String, dynamic>{
      'casoviID': instance.casoviID,
      'nazivCasa': instance.nazivCasa,
      'opis': instance.opis,
      'godisnjiPlanProgramID': instance.godisnjiPlanProgramID,
      'datumOdrzavanjaCasa': instance.datumOdrzavanjaCasa?.toIso8601String(),
    };
