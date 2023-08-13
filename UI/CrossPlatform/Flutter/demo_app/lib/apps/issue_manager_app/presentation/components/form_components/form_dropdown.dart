import 'package:flutter/material.dart';

class FormDropdown extends StatefulWidget {
  final List<String> list;
  const FormDropdown({super.key, required this.list});

  @override
  State<FormDropdown> createState() => _FormDropdownState();
}

class _FormDropdownState extends State<FormDropdown> {
  String dropdownValue = "";

  @override
  Widget build(BuildContext context) {
    dropdownValue = widget.list.first;

    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25.0),
      child: DropdownButton<String>(
        value: dropdownValue,
        icon: const Icon(Icons.arrow_downward),
        elevation: 16,
        style: const TextStyle(color: Colors.grey),
        underline: Container(
          height: 2,
          color: Colors.grey,
        ),
        isExpanded: true,
        onChanged: (String? value) {
          // This is called when the user selects an item.
          setState(() {
            dropdownValue = value!;
          });
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
