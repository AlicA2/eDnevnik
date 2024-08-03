import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/subject.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class SubjectProvider extends BaseProvider<Subject> {
  SubjectProvider() : super("Predmet");
  static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "https://localhost:7260/");
  static const String _endpoint = "Predmet";
  @override
  Subject fromJson(data) {
    // TODO: implement fromJson
    return Subject.fromJson(data);
  }

  Future<Subject> getById(int id) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unexpected error occurred while fetching subject data");
    }
  }
}
