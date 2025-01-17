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
      defaultValue: "http://localhost:7260/");
  static const String _endpoint = "Odjeljenje";

  @override
  Department fromJson(data) {
    // TODO: implement fromJson
    return Department.fromJson(data);
  }

  Future<Department?> addStudentToDepartment(int odjeljenjeID, int korisnikID) async {
  var url = "$_baseUrl$_endpoint/AddStudentToDepartment?odjeljenjeID=$odjeljenjeID&korisnikID=$korisnikID";
  var uri = Uri.parse(url);
  var headers = createHeaders();

  print("POST Request to $url");

  var response = await http.post(uri, headers: headers);

  print("Response status: ${response.statusCode}");
  print("Response body: ${response.body}");

  if (response.statusCode == 200) {
    print("Student added successfully: ${response.body}");
    return null;
  } else {
    print("Failed response: ${response.body}");
    throw Exception("Failed to add student to department: ${response.body}");
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

  Future<void> removeStudentFromDepartment(
      int odjeljenjeID, int korisnikID) async {
    var url =
        "$_baseUrl$_endpoint/RemoveStudentFromDepartment?odjeljenjeID=$odjeljenjeID&korisnikID=$korisnikID";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.delete(uri, headers: headers);

    if (response.statusCode == 400) {
      var errorData = jsonDecode(response.body);
      throw Exception(errorData['message']);
    }

    if (!isValidResponse(response)) {
      throw Exception("Failed to remove student from department");
    }
  }

  Future<void> updateStudentDepartment(int currentOdjeljenjeID, int newOdjeljenjeID, int korisnikID) async {
    var url =
        "$_baseUrl$_endpoint/UpdateStudentDepartment?currentOdjeljenjeID=$currentOdjeljenjeID&newOdjeljenjeID=$newOdjeljenjeID&korisnikID=$korisnikID";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    print("Response status: ${response.statusCode}");
    print("Response body: ${response.body}");

    if (response.statusCode == 200) {
      print("Student successfully transferred to the new department.");
    } else {
      var errorMessage = jsonDecode(response.body)['message'] ?? "Unknown error";
      print("Failed response: ${response.body}");
      throw Exception("Failed to update student department: $errorMessage");
    }
  }
}
