//! Opacity

import 'package:flutter/material.dart';

class OpacityWidget extends StatelessWidget {
  const OpacityWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Opacity(
          opacity: 1,
          child: Container(
            width: double.infinity,
            height: 100,
            color: Colors.orangeAccent,
            alignment: Alignment.center,
            child: const Text('Flutter Mapp'),
          ),
        ),
        Opacity(
          opacity: 0.5,
          child: Container(
            width: double.infinity,
            height: 100,
            color: Colors.orangeAccent,
            alignment: Alignment.center,
            child: const Text('Flutter Mapp'),
          ),
        ),
        Opacity(
          opacity: 0.1,
          child: Container(
            width: double.infinity,
            height: 100,
            color: Colors.orangeAccent,
            alignment: Alignment.center,
            child: const Text('Flutter Mapp'),
          ),
        ),
      ],
    );
  }
}
