import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/school.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class SchoolProvider extends BaseProvider<School> {
  SchoolProvider(): super("Skola");
  
  @override
  School fromJson(data) {
    // TODO: implement fromJson
    return School.fromJson(data);
  }
}
