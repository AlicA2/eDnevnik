import 'dart:convert';
import 'package:ednevnik_admin/models/final_grade.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class FinalGradeProvider extends BaseProvider<FinalGrade> {
  FinalGradeProvider(): super("ZakljucnaOcjena");
  
  @override
  FinalGrade fromJson(data) {
    // TODO: implement fromJson
    return FinalGrade.fromJson(data);
  }
}
