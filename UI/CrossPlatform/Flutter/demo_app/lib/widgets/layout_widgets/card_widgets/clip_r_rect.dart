//! ClipRRect
import 'package:flutter/material.dart';

class ClipRRectWidget extends StatefulWidget {
  const ClipRRectWidget({Key? key}) : super(key: key);

  @override
  State<ClipRRectWidget> createState() => _ClipRRectWidgetState();
}

class _ClipRRectWidgetState extends State<ClipRRectWidget> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ClipRRect(
        borderRadius: BorderRadius.circular(30),
        child: Image.asset(
          'lib/assets/icons/wave.png',
          width: 350,
        ),
      ),
    );
  }
}
