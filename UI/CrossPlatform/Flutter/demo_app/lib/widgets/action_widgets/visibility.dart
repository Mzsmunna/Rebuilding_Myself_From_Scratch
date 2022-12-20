//! Visibility

import 'package:flutter/material.dart';

class VisibilityWidget extends StatefulWidget {
  const VisibilityWidget({Key? key}) : super(key: key);

  @override
  State<VisibilityWidget> createState() => _VisibilityWidgetState();
}

class _VisibilityWidgetState extends State<VisibilityWidget> {
  bool isVisible = true;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextButton(
            onPressed: () {
              setState(() {
                isVisible = !isVisible;
              });
            },
            child: const Text(
              'Show / Hide',
            ),
          ),
          Image.asset(
            'assets/icon/blue.jpg',
            width: 300,
          ),
          const SizedBox(height: 30),
          Visibility(
            visible: isVisible,
            child: Image.asset(
              'assets/icon/ocean.jpg',
              width: 300,
            ),
          ),
        ],
      ),
    );
  }
}
