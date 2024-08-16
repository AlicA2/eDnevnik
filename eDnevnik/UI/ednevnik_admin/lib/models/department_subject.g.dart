// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department_subject.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DepartmentSubject _$DepartmentSubjectFromJson(Map<String, dynamic> json) =>
    DepartmentSubject(
      (json['odjeljenjePredmetID'] as num?)?.toInt(),
      (json['predmetID'] as num?)?.toInt(),
      (json['odjeljenjeID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$DepartmentSubjectToJson(DepartmentSubject instance) =>
    <String, dynamic>{
      'odjeljenjePredmetID': instance.odjeljenjePredmetID,
      'predmetID': instance.predmetID,
      'odjeljenjeID': instance.odjeljenjeID,
    };
