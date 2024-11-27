import 'dart:convert';
import 'package:ednevnik_admin/models/events.dart';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class EventsProvider extends BaseProvider<Events> {
  EventsProvider(): super("Dogadjaji");
   static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "https://localhost:7260/");
  static const String _endpoint = "Dogadjaji";
  @override
  Events fromJson(data) {
    // TODO: implement fromJson
    return Events.fromJson(data);
  }


  Future<Events> activate(int id) async {
    var url = "$_baseUrl$_endpoint/$id/activate";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Error while activating event: ${response.body}");
    }
  }

  Future<Events> hide(int id) async {
    var url = "$_baseUrl$_endpoint/$id/hide";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Error while hiding event: ${response.body}");
    }
  }

  Future<List<String>> allowedActions(int id) async {
    var url = "$_baseUrl$_endpoint/$id/allowedActions";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return List<String>.from(data);
    } else {
      throw Exception("Error while fetching allowed actions: ${response.body}");
    }
  }

}
