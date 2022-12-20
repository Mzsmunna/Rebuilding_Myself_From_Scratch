//! PhysicalShape

import 'package:flutter/material.dart';

class PhysicalShapeWidget extends StatelessWidget {
  const PhysicalShapeWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: PhysicalShape(
        elevation: 5.0,
        clipper: ShapeBorderClipper(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(40.0),
          ),
        ),
        color: Colors.orangeAccent,
        child: const SizedBox(
          height: 250,
          width: 250,
          child: Center(
            child: Icon(
              Icons.flutter_dash,
              size: 100,
            ),
          ),
        ),
      ),
    );
  }
}
