import 'dart:convert';
import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class AnnualPlanProgramProvider extends BaseProvider<AnnualPlanProgram> {
  AnnualPlanProgramProvider(): super("GodisnjiPlanProgram");
  
  @override
  AnnualPlanProgram fromJson(data) {
    // TODO: implement fromJson
    return AnnualPlanProgram.fromJson(data);
  }
}
