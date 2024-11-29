// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'school_year.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SchoolYear _$SchoolYearFromJson(Map<String, dynamic> json) => SchoolYear(
      skolskaGodinaID: (json['skolskaGodinaID'] as num?)?.toInt(),
      naziv: json['naziv'] as String?,
    );

Map<String, dynamic> _$SchoolYearToJson(SchoolYear instance) =>
    <String, dynamic>{
      'skolskaGodinaID': instance.skolskaGodinaID,
      'naziv': instance.naziv,
    };
