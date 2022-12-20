//!FilterChip

import 'package:flutter/material.dart';

class FilterChipWidget extends StatefulWidget {
  const FilterChipWidget({Key? key}) : super(key: key);

  @override
  State createState() => FilterChipWidgetState();
}

class FilterChipWidgetState extends State<FilterChipWidget> {
  bool isSelected = false;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: FilterChip(
        label: const Text('FilterChip'),
        selected: isSelected,
        onSelected: (bool value) {
          setState(() {
            isSelected = !isSelected;
          });
        },
        avatar: const Text('F'),
      ),
    );
  }
}
