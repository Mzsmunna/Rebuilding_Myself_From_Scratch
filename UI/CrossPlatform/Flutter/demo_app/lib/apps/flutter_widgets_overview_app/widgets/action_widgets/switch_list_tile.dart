//! SwitchListTile

import 'package:flutter/material.dart';

class SwitchListTileWidget extends StatefulWidget {
  const SwitchListTileWidget({Key? key}) : super(key: key);

  @override
  State<SwitchListTileWidget> createState() => _SwitchListTileWidgetState();
}

class _SwitchListTileWidgetState extends State<SwitchListTileWidget> {
  bool lights = false;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SwitchListTile(
        title: const Text('Lights'),
        value: lights,
        onChanged: (bool value) {
          setState(() {
            lights = value;
          });
        },
        secondary: const Icon(Icons.lightbulb_outline),
      ),
    );
  }
}
