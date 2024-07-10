import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/roles.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class RolesProvider extends BaseProvider<Roles> {
  RolesProvider(): super("Uloge");
  
  @override
  Roles fromJson(data) {
    // TODO: implement fromJson
    return Roles.fromJson(data);
  }
}
