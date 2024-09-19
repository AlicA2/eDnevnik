import 'package:ednevnik_admin/models/classes.dart';
import 'package:ednevnik_admin/providers/classes_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ClassesHeldDetailScreen extends StatefulWidget {
  final int? casoviID;
  const ClassesHeldDetailScreen({super.key, required this.casoviID});

  @override
  State<ClassesHeldDetailScreen> createState() =>
      _ClassesHeldDetailScreenState();
}

class _ClassesHeldDetailScreenState extends State<ClassesHeldDetailScreen> {
  late ClassesProvider _classesProvider;
  Classes? _fetchedClass;
  bool _isLoading = true;
  bool? _isOdrzan;

  @override
  void initState() {
    super.initState();
    _classesProvider = context.read<ClassesProvider>();
    _fetchClasses();
  }

  Future<void> _fetchClasses() async {
    try {
      var classesResponse = await _classesProvider.get(filter: {
        'CasoviID': widget.casoviID,
      });

      if (classesResponse != null && classesResponse.result.isNotEmpty) {
        setState(() {
          _fetchedClass = classesResponse.result.first;
          _isOdrzan = _fetchedClass?.isOdrzan;
          _isLoading = false;
        });
      }
    } catch (e) {
      print("Failed to fetch classes: $e");
      setState(() {
        _isLoading = false;
      });
    }
  }

  Future<void> _updateClassOdrzan(bool value) async {
    setState(() {
      _isOdrzan = value;
    });

    if (_fetchedClass != null && widget.casoviID != null) {
      final updateRequest = {
        'NazivCasa': _fetchedClass?.nazivCasa,
        'Opis': _fetchedClass?.opis,
        'GodisnjiPlanProgramID': _fetchedClass?.godisnjiPlanProgramID,
        'DatumOdrzavanjaCasa':
            _fetchedClass?.datumOdrzavanjaCasa?.toIso8601String(),
        'isOdrzan': value,
      };

      try {
        await _classesProvider.Update(widget.casoviID!, updateRequest);
        print("Class updated successfully!");
      } catch (e) {
        print("Failed to update class: $e");
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Align(
        alignment: Alignment.topLeft,
        child: Container(
          width: double.infinity,
          height: double.infinity,
          color: Color(0xFFF7F2FA),
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: _isLoading
                ? Center(child: CircularProgressIndicator())
                : Container(
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    child: SingleChildScrollView(
                      child: Column(
                        children: [
                          _buildScreenName(),
                          SizedBox(height: 16.0),
                        ],
                      ),
                    ),
                  ),
          ),
        ),
      ),
    );
  }

  Widget _buildScreenName() {
    return Align(
      alignment: Alignment.centerLeft,
      child: Row(
        children: [
          Container(
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.only(
                bottomLeft: Radius.circular(5),
                topLeft: Radius.circular(20),
                topRight: Radius.elliptical(5, 5),
                bottomRight: Radius.circular(30.0),
              ),
            ),
            padding: const EdgeInsets.all(16.0),
            child: Text(
              "Održani časovi",
              style: TextStyle(
                color: Colors.white,
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Spacer(),
          _buildConfirmationRow(),
        ],
      ),
    );
  }

  Widget _buildConfirmationRow() {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Row(
        children: [
          Text(
            "Da li je čas održan: ",
            style: TextStyle(
              fontSize: 16,
              fontWeight: FontWeight.bold,
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                ElevatedButton(
                  onPressed: () => _updateClassOdrzan(true),
                  style: ElevatedButton.styleFrom(
                    backgroundColor:
                        _isOdrzan == true ? Colors.green : Colors.grey,
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                  ),
                  child: Text('Da'),
                ),
                SizedBox(width: 10),
                ElevatedButton(
                  onPressed: () => _updateClassOdrzan(false),
                  style: ElevatedButton.styleFrom(
                    backgroundColor:
                        _isOdrzan == false ? Colors.red : Colors.grey,
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10),
                    ),
                  ),
                  child: Text('Ne'),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
