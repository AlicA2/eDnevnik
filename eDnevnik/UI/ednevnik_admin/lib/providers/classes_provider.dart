import 'dart:convert';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class ClassesProvider extends BaseProvider<Classes> {
  ClassesProvider(): super("Casovi");
  
  @override
  Classes fromJson(data) {
    // TODO: implement fromJson
    return Classes.fromJson(data);
  }
}