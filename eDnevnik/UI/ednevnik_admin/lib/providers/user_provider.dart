import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/roles.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:http/http.dart';

class UserProvider extends BaseProvider<User> {
  static const String _baseUrl = String.fromEnvironment("baseUrl",
      defaultValue: "https://localhost:7260/");
  static const String _endpoint = "Korisnik";

  UserProvider() : super("Korisnik");


 @override
  User fromJson(data) {
    var korisnik = User.fromJson(data);
    if (data['korisniciUloge'] != null) {
      korisnik.uloge = List<Roles>.from(
          data['korisniciUloge'].map((x) => Roles.fromJson(x['uloga'])));
    }
    return korisnik;
  }

  Future<User> getById(int id) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unexpected error occurred while fetching user data");
    }
  }

  Future<List<User>> getUsersByRole() async {
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (response.statusCode == 200) {
      var jsonData = jsonDecode(response.body);
      List<User> users = [];

      for (var item in jsonData['result']) {
        var user = User.fromJson(item);
        if (user.korisniciUloge != null &&
            user.korisniciUloge!.any((role) => role.ulogaID == 1)) {
          users.add(user);
        }
      }

      return users;
    } else {
      throw Exception('Failed to load users');
    }
  }
}
