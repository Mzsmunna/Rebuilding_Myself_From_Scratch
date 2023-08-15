import 'package:demo_app/apps/issue_manager_app/application/configs/themes/issue_manager_themes.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FormDropdown extends StatefulWidget {
  final TextEditingController controller;
  final bool obscureText;
  final List<String> list;
  String dropdownValue = "";
  final Function(String?)? onChanged;
  FormDropdown(
      {super.key,
      required this.controller,
      required this.obscureText,
      required this.list,
      required this.onChanged}) {
    dropdownValue = list.first;
  }

  @override
  State<FormDropdown> createState() => _FormDropdownState();
}

class _FormDropdownState extends State<FormDropdown> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25.0),
      child: DropdownButtonFormField<String>(
        value: widget.dropdownValue,
        icon: const Icon(Icons.arrow_downward),
        elevation: 16,
        style: const TextStyle(color: Colors.grey),
        decoration:
            IssueManagerTheme.getFormInputDecoration(widget.dropdownValue),
        isExpanded: true,
        onChanged: (String? value) {
          // This is called when the user selects an item.
          setState(() {
            widget.dropdownValue = value!;
          });
          if (widget.onChanged != null) {
            widget.onChanged!(value);
          }
        },
        items: widget.list.map<DropdownMenuItem<String>>((String value) {
          return DropdownMenuItem<String>(
            value: value,
            child: Text(value),
          );
        }).toList(),
      ),
    );
  }
}
