// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User(
      (json['korisnikId'] as num?)?.toInt(),
      json['ime'] as String?,
      json['prezime'] as String?,
      json['email'] as String?,
      json['telefon'] as String?,
      json['stateMachine'] as String?,
      json['korisnickoIme'] as String?,
      json['lozinka'] as String?,
      (json['korisniciUloge'] as List<dynamic>?)
          ?.map((e) => UsersRoles.fromJson(e as Map<String, dynamic>))
          .toList(),
      (json['uloge'] as List<dynamic>?)
          ?.map((e) => Roles.fromJson(e as Map<String, dynamic>))
          .toList(),
      (json['odjeljenjeID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'korisnikId': instance.korisnikId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'telefon': instance.telefon,
      'stateMachine': instance.stateMachine,
      'korisnickoIme': instance.korisnickoIme,
      'lozinka': instance.lozinka,
      'odjeljenjeID': instance.odjeljenjeID,
      'korisniciUloge': instance.korisniciUloge,
      'uloge': instance.uloge,
    };
