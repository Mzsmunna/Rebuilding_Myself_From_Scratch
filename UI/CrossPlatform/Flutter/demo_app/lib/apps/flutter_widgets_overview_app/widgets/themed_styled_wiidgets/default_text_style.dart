//!DefaultTextStyle

import 'package:flutter/material.dart';

class DefaultTextStyleWidget extends StatelessWidget {
  const DefaultTextStyleWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const Text(
          'Flutter Mapp',
        ),
        DefaultTextStyle(
          style: const TextStyle(
            fontSize: 36,
            color: Colors.blue,
          ),
          child: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: const [
                Text(
                  'Flutter Mapp',
                ),
                Text(
                  'Flutter Mapp',
                  style: TextStyle(fontSize: 24),
                ),
                Text(
                  'Flutter Mapp',
                  style: TextStyle(color: Colors.red),
                ),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
