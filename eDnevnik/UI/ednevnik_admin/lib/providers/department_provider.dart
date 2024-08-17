import 'dart:convert';
import 'package:ednevnik_admin/models/department.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/department_delete_custom_exception.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class DepartmentProvider extends BaseProvider<Department> {
  DepartmentProvider() : super("Odjeljenje");
  static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "https://localhost:7260/");
  static const String _endpoint = "Odjeljenje";

  @override
  Department fromJson(data) {
    // TODO: implement fromJson
    return Department.fromJson(data);
  }

  Future<Department> addStudentToDepartment(
      int odjeljenjeID, int korisnikID) async {
    var url = "$_baseUrl$_endpoint/$odjeljenjeID/addStudent";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var body = jsonEncode({
      'korisnikID': korisnikID,
    });

    var response = await http.post(uri, headers: headers, body: body);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Failed to add student to department");
    }
  }

  Future<List<Department>> getDepartmentsWithStudents({int? schoolID}) async {
    var url = "$_baseUrl$_endpoint/WithStudents";
    var uri = Uri.parse(url);

    if (schoolID != null) {
      uri = uri.replace(queryParameters: {'SkolaID': schoolID.toString()});
    }

    var headers = createHeaders();
    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data['result'] as List)
          .map((item) => Department.fromJson(item))
          .toList();
    } else {
      throw Exception("Failed to fetch departments with students");
    }
  }
}
