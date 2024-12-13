import 'dart:convert';
import 'package:http/http.dart' as http;

import '../models/message.dart';
import 'base_provider.dart';

class MessageProvider extends BaseProvider<Message> {
  static const String _baseUrl =
  String.fromEnvironment("baseUrl", defaultValue: "http://10.0.2.2:7005/");

  static const String _endpoint = "Poruka";

  MessageProvider() : super("Poruka");

  @override
  Message fromJson(data) {
    return Message.fromJson(data);
  }

  @override
  Future<Message> insert(dynamic request) async {
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var jsonRequest = jsonEncode(request);
    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Nepoznato!");
    }
  }
}
