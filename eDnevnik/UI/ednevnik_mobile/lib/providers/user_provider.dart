import 'dart:convert';
import 'package:ednevnik_admin/models/result.dart';
import 'package:ednevnik_admin/models/roles.dart';
import 'package:ednevnik_admin/models/user.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:ednevnik_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class UserProvider extends BaseProvider<User> {
  static const String _baseUrl =
      String.fromEnvironment("baseUrl", defaultValue: "http://10.0.2.2:7260/");
  static const String _endpoint = "Korisnik";

  UserProvider() : super("Korisnik");

  User? _loggedInUser;

  User? get loggedInUser => _loggedInUser;

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

  Future<int> getLoged(String username, String password) async {
    var url =
        "$_baseUrl$_endpoint/GetLoged?username=$username&password=$password";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Unexpected error occurred while logging in");
    }
  }

  Future<void> login(String username, String password) async {
    Authorization.username = username;
    Authorization.password = password;

    int userId = await getLoged(username, password);
    _loggedInUser = await getById(userId);
    notifyListeners();
  }

  Future<void> updatePasswordAndUsername(int id, String oldPassword,
      String korisnickoIme, String password, String passwordPotvrda) async {
    var url =
        "$_baseUrl$_endpoint/UpdatePasswordAndUsername?id=$id&oldPassword=$oldPassword";
    var uri = Uri.parse(url);
    var headers = createHeaders();
    var requestBody = jsonEncode({
      'korisnickoIme': korisnickoIme,
      'password': password,
      'passwordPotvrda': passwordPotvrda
    });

    var response = await http.put(uri, headers: headers, body: requestBody);

    if (!isValidResponse(response)) {
      throw Exception(
          "Unexpected error occurred while updating password and username");
    }
  }

  Future<Map<String, dynamic>> getLogedWithRole(
      String username, String password) async {
    var url =
        "$_baseUrl$_endpoint/GetLogedWithRole?username=$username&password=$password";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      int korisnikId = data['korisnikId'];

      _loggedInUser = await getById(korisnikId);
      return data;
    } else {
      throw Exception("Unexpected error occurred while logging in");
    }
  }
}
