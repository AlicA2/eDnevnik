// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'annual_plan_program.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AnnualPlanProgram _$AnnualPlanProgramFromJson(Map<String, dynamic> json) =>
    AnnualPlanProgram(
      (json['godisnjiPlanProgramID'] as num?)?.toInt(),
      (json['brojCasova'] as num?)?.toInt(),
      json['naziv'] as String?,
      (json['predmetID'] as num?)?.toInt(),
      (json['odjeljenjeID'] as num?)?.toInt(),
      (json['casovi'] as List<dynamic>)
          .map((e) => Classes.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$AnnualPlanProgramToJson(AnnualPlanProgram instance) =>
    <String, dynamic>{
      'godisnjiPlanProgramID': instance.godisnjiPlanProgramID,
      'brojCasova': instance.brojCasova,
      'naziv': instance.naziv,
      'predmetID': instance.predmetID,
      'odjeljenjeID': instance.odjeljenjeID,
      'casovi': instance.casovi,
    };
