// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'classes_students.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClassesStudents _$ClassesStudentsFromJson(Map<String, dynamic> json) =>
    ClassesStudents(
      (json['casoviUceniciID'] as num?)?.toInt(),
      (json['casoviID'] as num?)?.toInt(),
      (json['ucenikID'] as num?)?.toInt(),
      json['isPrisutan'] as bool?,
      json['zakljucan'] as bool?,
    );

Map<String, dynamic> _$ClassesStudentsToJson(ClassesStudents instance) =>
    <String, dynamic>{
      'casoviUceniciID': instance.casoviUceniciID,
      'casoviID': instance.casoviID,
      'ucenikID': instance.ucenikID,
      'isPrisutan': instance.isPrisutan,
      'zakljucan': instance.zakljucan,
    };
