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
  AnnualPlanProgramProvider() : super("GodisnjiPlanProgram");
  static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "http://10.0.2.2:7260/");
  static const String _endpoint = "GodisnjiPlanProgram";

  @override
  AnnualPlanProgram fromJson(data) {
    return AnnualPlanProgram.fromJson(data);
  }

  Future<bool> checkIfExists(int odjeljenjeID, int predmetID) async {
    var url = "$_baseUrl$_endpoint/CheckIfExists?odjeljenjeID=$odjeljenjeID&predmetID=$predmetID";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data['exists'] ?? false;
    } else {
      throw Exception("Unexpected error occurred while checking existence");
    }
  }
}
