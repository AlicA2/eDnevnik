import 'dart:convert';
import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/custom_exception_util.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class ClassesProvider extends BaseProvider<Classes> {
  ClassesProvider(): super("Casovi");
    static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "http://10.0.2.2:7260/");
  static const String _endPoint = "Casovi";

  @override
  Classes fromJson(data) {
    // TODO: implement fromJson
    return Classes.fromJson(data);
  }

   @override
  Future<Classes> Insert(dynamic request) async {
    var url = "$_baseUrl$_endPoint";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var jsonRequest = jsonEncode(request);

    var response = await http.post(uri, headers: headers, body: jsonRequest);

if (response.statusCode == 400) {
      var errorData = jsonDecode(response.body);
      if (errorData.containsKey('errors') && errorData['errors'].containsKey('message')) {
        var errorMessage = errorData['errors']['message'];
        throw MaxItemsExceededException(errorMessage);
      }
    }

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<bool> hasClasses(int annualPlanProgramID) async {
    var url = "$_baseUrl$_endPoint/check?godisnjiPlanProgramID=$annualPlanProgramID";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data['hasClasses'] as bool;
    } else {
      throw Exception("Failed to check classes");
    }
  }
}
