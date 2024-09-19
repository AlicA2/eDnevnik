// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'classes_students.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClassesStudents _$ClassesStudentsFromJson(Map<String, dynamic> json) =>
    ClassesStudents(
      (json['casoviStudentiID'] as num?)?.toInt(),
      (json['casoviID'] as num?)?.toInt(),
      (json['ucenikID'] as num?)?.toInt(),
      json['isPrisutan'] as bool?,
    );

Map<String, dynamic> _$ClassesStudentsToJson(ClassesStudents instance) =>
    <String, dynamic>{
      'casoviStudentiID': instance.casoviStudentiID,
      'casoviID': instance.casoviID,
      'ucenikID': instance.ucenikID,
      'isPrisutan': instance.isPrisutan,
    };
