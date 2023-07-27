//! RotatedBox

import 'package:flutter/material.dart';

class RotatedBoxWidget extends StatelessWidget {
  const RotatedBoxWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: RotatedBox(
        quarterTurns: 1,
        child: FlutterLogo(
          size: 200,
        ),
      ),
    );
  }
}
