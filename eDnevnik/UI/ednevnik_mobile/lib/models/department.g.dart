// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Department _$DepartmentFromJson(Map<String, dynamic> json) => Department(
      (json['odjeljenjeID'] as num?)?.toInt(),
      json['nazivOdjeljenja'] as String?,
      (json['razrednikID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$DepartmentToJson(Department instance) =>
    <String, dynamic>{
      'odjeljenjeID': instance.odjeljenjeID,
      'nazivOdjeljenja': instance.nazivOdjeljenja,
      'razrednikID': instance.razrednikID,
    };
