import 'dart:convert';
import 'package:ednevnik_admin/models/classes_students.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class ClassesStudentsProvider extends BaseProvider<ClassesStudents> {
  ClassesStudentsProvider(): super("CasoviUcenici");
  
  @override
  ClassesStudents fromJson(data) {
    // TODO: implement fromJson
    return ClassesStudents.fromJson(data);
  }
}
