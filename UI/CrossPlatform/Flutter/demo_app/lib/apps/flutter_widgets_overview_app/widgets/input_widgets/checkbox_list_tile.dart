//!CheckboxListTile

import 'package:flutter/material.dart';

class CheckBoxListTileWidget extends StatefulWidget {
  const CheckBoxListTileWidget({Key? key}) : super(key: key);

  @override
  State<CheckBoxListTileWidget> createState() => _CheckBoxListTileWidgetState();
}

class _CheckBoxListTileWidgetState extends State<CheckBoxListTileWidget> {
  bool? _isChecked = false;
  @override
  Widget build(BuildContext context) {
    return Center(
      child: CheckboxListTile(
        title: const Text('Checkbox List Tile'),
        value: _isChecked,
        onChanged: (bool? newValue) {
          setState(() {
            _isChecked = newValue;
          });
        },
        activeColor: Colors.orangeAccent,
        checkColor: Colors.white,
        tileColor: Colors.black12,
        subtitle: const Text('This is a subtitle'),
        controlAffinity: ListTileControlAffinity.leading,
        tristate: true,
      ),
    );
  }
}
