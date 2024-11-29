// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_detail.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserDetail _$UserDetailFromJson(Map<String, dynamic> json) => UserDetail(
      (json['korisnikDetaljiID'] as num?)?.toInt(),
      (json['korisnikID'] as num?)?.toInt(),
      (json['godinaStudija'] as num?)?.toInt(),
      json['obnavljaGodinu'] as bool?,
      (json['prosjecnaOcjena'] as num?)?.toInt(),
      (json['godinaUpisaID'] as num?)?.toInt(),
      (json['upisanaSkolskaGodinaID'] as num?)?.toInt(),
    );

Map<String, dynamic> _$UserDetailToJson(UserDetail instance) =>
    <String, dynamic>{
      'korisnikDetaljiID': instance.korisnikDetaljiID,
      'korisnikID': instance.korisnikID,
      'godinaStudija': instance.godinaStudija,
      'obnavljaGodinu': instance.obnavljaGodinu,
      'prosjecnaOcjena': instance.prosjecnaOcjena,
      'godinaUpisaID': instance.godinaUpisaID,
      'upisanaSkolskaGodinaID': instance.upisanaSkolskaGodinaID,
    };
