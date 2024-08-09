import 'package:flutter/material.dart';
import 'package:ednevnik_admin/models/school.dart';

class SelectedSchoolProvider with ChangeNotifier {
  School? _selectedSchool;

  School? get selectedSchool => _selectedSchool;

  void setSelectedSchool(School? school) {
    _selectedSchool = school;
    notifyListeners();
  }
}
