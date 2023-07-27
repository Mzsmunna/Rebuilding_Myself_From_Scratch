//!ElevatedButton

import 'package:flutter/material.dart';

class ElevatedButtonWidget extends StatefulWidget {
  const ElevatedButtonWidget({Key? key}) : super(key: key);

  @override
  State<ElevatedButtonWidget> createState() => _ElevatedButtonWidgetState();
}

class _ElevatedButtonWidgetState extends State<ElevatedButtonWidget> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          const ElevatedButton(
            onPressed: null,
            child: Text('Disabled'),
          ),
          const SizedBox(height: 30),
          ElevatedButton(
            onPressed: () {},
            child: const Text('Enabled'),
          ),
          const SizedBox(height: 30),
          ElevatedButton.icon(
            onPressed: () {},
            label: const Text('Enabled'),
            icon: const Icon(Icons.message),
          ),
        ],
      ),
    );
  }
}
