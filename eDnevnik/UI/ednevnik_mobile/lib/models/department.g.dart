// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Department _$DepartmentFromJson(Map<String, dynamic> json) => Department(
      (json['odjeljenjeID'] as num?)?.toInt(),
      json['nazivOdjeljenja'] as String?,
      (json['razrednikID'] as num?)?.toInt(),
      (json['skolaID'] as num?)?.toInt(),
      (json['ucenici'] as List<dynamic>?)
          ?.map((e) => User.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$DepartmentToJson(Department instance) =>
    <String, dynamic>{
      'odjeljenjeID': instance.odjeljenjeID,
      'nazivOdjeljenja': instance.nazivOdjeljenja,
      'razrednikID': instance.razrednikID,
      'skolaID': instance.skolaID,
      'ucenici': instance.ucenici,
    };
