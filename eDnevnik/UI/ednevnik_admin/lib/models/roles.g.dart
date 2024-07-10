// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'roles.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Roles _$RolesFromJson(Map<String, dynamic> json) => Roles(
      ulogaID: (json['ulogaID'] as num?)?.toInt(),
      naziv: json['naziv'] as String?,
      opis: json['opis'] as String?,
    );

Map<String, dynamic> _$RolesToJson(Roles instance) => <String, dynamic>{
      'ulogaID': instance.ulogaID,
      'naziv': instance.naziv,
      'opis': instance.opis,
    };
