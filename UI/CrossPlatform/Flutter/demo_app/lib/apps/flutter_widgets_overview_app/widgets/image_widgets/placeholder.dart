//! Placeholder

import 'package:flutter/material.dart';

class PlaceholderWidget extends StatelessWidget {
  const PlaceholderWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: const <Widget>[
        Placeholder(
          fallbackHeight: 300,
          fallbackWidth: 50,
          color: Colors.orangeAccent,
        ),
      ],
    );
  }
}
