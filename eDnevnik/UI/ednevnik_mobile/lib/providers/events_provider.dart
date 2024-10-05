import 'dart:convert';
import 'package:ednevnik_admin/models/events.dart';
import 'package:ednevnik_admin/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class EventsProvider extends BaseProvider<Events> {
  EventsProvider(): super("Dogadjaji");

  static const String _baseUrl = String.fromEnvironment("baseUrl", defaultValue: "https://10.0.2.2:7260/");
  static const String _endpoint = "Dogadjaji";

  @override
  Events fromJson(data) {
    return Events.fromJson(data);
  }

  Future<List<Events>> recommend(int id) async {
    var url = "$_baseUrl$_endpoint/$id/recommend";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data as List).map((item) => Events.fromJson(item)).toList();
    } else {
      throw Exception("Failed to fetch recommended events");
    }
  }
}
