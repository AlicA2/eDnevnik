import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:ednevnik_admin/models/message.dart';
import 'package:ednevnik_admin/providers/message_provider.dart';
import 'package:ednevnik_admin/providers/user_provider.dart';
import 'package:ednevnik_admin/widgets/master_screen.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

import '../models/result.dart';
import '../models/user.dart';

class MessageDetailScreen extends StatefulWidget {
  const MessageDetailScreen({Key? key}) : super(key: key);

  @override
  State<MessageDetailScreen> createState() => _MessageDetailScreenState();
}

class _MessageDetailScreenState extends State<MessageDetailScreen> {
  late MessageProvider _messageProvider;
  late UserProvider _userProvider;

  final _formKey = GlobalKey<FormBuilderState>();
  SearchResult<User>? userResult;
  String? _selectedRecipientID;
  User? loggedInUser;

  @override
  void initState() {
    super.initState();
    _messageProvider = context.read<MessageProvider>();
    _userProvider = context.read<UserProvider>();
    _loadUsers();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    loggedInUser = context.watch<UserProvider>().loggedInUser;
  }

  Future<void> _loadUsers() async {
    userResult = await _userProvider.get();
    setState(() {});
  }

  Future<void> _saveMessage() async {
    if (_formKey.currentState?.saveAndValidate() ?? false) {
      final formValues = _formKey.currentState?.value;
      final selectedProfessorID = _selectedRecipientID;
      final message = Message(
        ucenikID: loggedInUser?.korisnikId,
        profesorID: selectedProfessorID != null ? int.parse(selectedProfessorID) : null,
        sadrzajPoruke: formValues?['poruka'],
        datumSlanja: DateTime.now(),
      );

      await _messageProvider.Insert(message);

      setState(() {
        _selectedRecipientID = null;
        _formKey.currentState?.reset();
      });

      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Poruka poslana uspješno!')),
      );
    }
  }

  List<DropdownMenuItem<String>> _buildProfessorDropdownItems() {
    if (userResult == null || userResult!.result == null) {
      return [];
    }

    var filteredUsers = userResult!.result!
        .where((user) => user.uloge!.any((role) => role.ulogaID == 1));

    return filteredUsers.map((user) {
      return DropdownMenuItem<String>(
        value: user.korisnikId.toString(),
        child: Text('${user.ime} ${user.prezime}'),
      );
    }).toList();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        color: const Color(0xFFF7F2FA),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20.0),
            ),
            child: SingleChildScrollView(
              child: Column(
                children: [
                  _buildScreenName(),
                  SizedBox(height: 16.0),
                  _buildFormFields(loggedInUser),
                  _buildSaveButton(),
                ],
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
      child: Container(
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
          "Slanje poruke",
          style: TextStyle(
            color: Colors.white,
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }

  Widget _buildFormFields(User? loggedInUser) {
    return FormBuilder(
      key: _formKey,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            FormBuilderTextField(
              name: 'ucenik',
              initialValue: loggedInUser != null
                  ? "${loggedInUser.ime} ${loggedInUser.prezime}"
                  : "Unknown",
              decoration: InputDecoration(labelText: "Učenik:"),
              enabled: false,
            ),
            SizedBox(height: 20),
            FormBuilderDropdown<String>(
              name: 'profesor',
              decoration: InputDecoration(labelText: "Profesor:"),
              items: _buildProfessorDropdownItems(),
              initialValue: _selectedRecipientID,
              onChanged: (value) {
                setState(() {
                  _selectedRecipientID = value;
                });
              },
              validator: FormBuilderValidators.required(
                errorText: 'Profesor ne može biti prazan!',
              ),
            ),
            SizedBox(height: 20),
            FormBuilderTextField(
              name: 'poruka',
              maxLines: 4,
              decoration: InputDecoration(
                labelText: "Poruka",
                alignLabelWithHint: true,
              ),
              validator: FormBuilderValidators.required(
                errorText: 'Poruka ne može biti prazna!',
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildSaveButton() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20.0),
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          backgroundColor: Colors.blue,
          foregroundColor: Colors.white,
        ),
        onPressed: _saveMessage,
        child: const Text("Pošalji poruku"),
      ),
    );
  }
}
