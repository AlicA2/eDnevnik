// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_roles.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UsersRoles _$UsersRolesFromJson(Map<String, dynamic> json) => UsersRoles(
      (json['korisnikUlogaID'] as num?)?.toInt(),
      (json['korisnikID'] as num?)?.toInt(),
      (json['ulogaID'] as num?)?.toInt(),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['uloga'] == null
          ? null
          : Roles.fromJson(json['uloga'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$UsersRolesToJson(UsersRoles instance) =>
    <String, dynamic>{
      'korisnikUlogaID': instance.korisnikUlogaID,
      'korisnikID': instance.korisnikID,
      'ulogaID': instance.ulogaID,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'uloga': instance.uloga,
    };
