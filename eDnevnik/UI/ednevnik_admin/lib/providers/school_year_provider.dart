import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school_year.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class SchoolYearProvider extends BaseProvider<SchoolYear> {
  SchoolYearProvider(): super("SkolskaGodina");
  
  @override
  SchoolYear fromJson(data) {
    // TODO: implement fromJson
    return SchoolYear.fromJson(data);
  }
}
