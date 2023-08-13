import 'package:flutter/material.dart';
import 'package:numberpicker/numberpicker.dart';

// ignore: must_be_immutable
class FormNumberPicker extends StatefulWidget {
  //final TextEditingController controller;
  final String hintText;
  final Axis axis;
  int currentValue;
  final int minValue;
  final int maxValue;

  FormNumberPicker({
    super.key,
    required this.hintText,
    required this.axis,
    required this.currentValue,
    required this.minValue,
    required this.maxValue,
  });

  @override
  State<FormNumberPicker> createState() => _FormNumberPickerState();
}

class _FormNumberPickerState extends State<FormNumberPicker> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        const SizedBox(height: 10),
        Text(
          widget.hintText,
          style: const TextStyle(
            fontSize: 20,
            color: Colors.grey,
          ),
        ),
        NumberPicker(
          axis: widget.axis,
          value: widget.currentValue,
          minValue: widget.minValue,
          maxValue: widget.maxValue,
          onChanged: (value) => setState(() => widget.currentValue = value),
        ),
        //Text('Current value: $_currentValue'),
      ],
    );
  }
}
