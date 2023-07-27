//! toggle buttons

import 'package:flutter/material.dart';

class ToggleButtonsWidget extends StatefulWidget {
  const ToggleButtonsWidget({Key? key}) : super(key: key);

  @override
  State<ToggleButtonsWidget> createState() => _ToggleButtonsWidgetState();
}

class _ToggleButtonsWidgetState extends State<ToggleButtonsWidget> {
  List<bool> isSelected = [
    false,
    false,
    false,
  ];
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ToggleButtons(
        onPressed: (int index) {
          setState(() {
            isSelected[index] = !isSelected[index];
          });
        },
        isSelected: isSelected,
        children: const [
          Icon(Icons.home),
          Icon(Icons.settings),
          Icon(Icons.person),
        ],
      ),
    );
  }
}
