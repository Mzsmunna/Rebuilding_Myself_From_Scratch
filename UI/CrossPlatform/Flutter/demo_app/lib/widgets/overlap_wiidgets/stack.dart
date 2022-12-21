//! Stack

import 'package:flutter/material.dart';

class StackWidget extends StatelessWidget {
  const StackWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Stack(
        children: [
          Center(
            child: Image.asset(
              'lib/assets/icons/wave.png',
            ),
          ),
          Center(
            child: Image.asset(
              'lib/assets/icons/ocean.png',
              width: 300,
            ),
          ),
        ],
      ),
    );
  }
}
