//! ChoiceChip
import 'package:flutter/material.dart';

class ChoiceChipWidget extends StatefulWidget {
  const ChoiceChipWidget({Key? key}) : super(key: key);

  @override
  State<ChoiceChipWidget> createState() => _ChoiceChipWidgetState();
}

class _ChoiceChipWidgetState extends State<ChoiceChipWidget> {
  bool isSelected = false;
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ChoiceChip(
        label: const Text("Choice Chip"),
        selected: isSelected,
        selectedColor: Colors.orangeAccent,
        onSelected: (newState) {
          setState(() {
            isSelected = newState;
          });
        },
      ),
    );
  }
}
