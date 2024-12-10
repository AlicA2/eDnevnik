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
      json['ime'] as String?,
      json['prezime'] as String?,
    );

Map<String, dynamic> _$ClassesStudentsToJson(ClassesStudents instance) =>
    <String, dynamic>{
      'casoviUceniciID': instance.casoviUceniciID,
      'casoviID': instance.casoviID,
      'ucenikID': instance.ucenikID,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'isPrisutan': instance.isPrisutan,
      'zakljucan': instance.zakljucan,
    };
