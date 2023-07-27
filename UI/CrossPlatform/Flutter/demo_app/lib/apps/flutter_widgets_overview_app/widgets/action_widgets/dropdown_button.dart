//!DropdownButton

import 'package:flutter/material.dart';

class DropdownButtonWidget extends StatefulWidget {
  const DropdownButtonWidget({Key? key}) : super(key: key);

  @override
  State<DropdownButtonWidget> createState() => _DropdownButtonWidgetState();
}

class _DropdownButtonWidgetState extends State<DropdownButtonWidget> {
  String dropdownValue = 'One';

  @override
  Widget build(BuildContext context) {
    return Center(
      child: DropdownButton<String>(
        value: dropdownValue,
        icon: const Icon(Icons.menu),
        style: const TextStyle(color: Colors.black87),
        underline: Container(
          height: 2,
          color: Colors.black54,
        ),
        onChanged: (String? newValue) {
          setState(() {
            dropdownValue = newValue!;
          });
        },
        items: const [
          DropdownMenuItem<String>(
            value: 'One',
            child: Text('One'),
          ),
          DropdownMenuItem<String>(
            value: 'Two',
            child: Text('Two'),
          ),
          DropdownMenuItem<String>(
            value: 'Three',
            child: Text('Three'),
          ),
        ],
      ),
    );
  }
}
