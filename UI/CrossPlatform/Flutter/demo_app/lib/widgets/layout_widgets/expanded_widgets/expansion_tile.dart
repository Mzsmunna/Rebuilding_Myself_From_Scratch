//!ExpansionTile

import 'package:flutter/material.dart';

class ExpansionTileWidget extends StatefulWidget {
  const ExpansionTileWidget({Key? key}) : super(key: key);

  @override
  State<ExpansionTileWidget> createState() => _ExpansionTileWidgetState();
}

class _ExpansionTileWidgetState extends State<ExpansionTileWidget> {
  //final bool _customIcon = false;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        ExpansionTile(
          title: const Text('Expansion Tile'),
          onExpansionChanged: (bool expanded) {},
          controlAffinity: ListTileControlAffinity.leading,
          children: const <Widget>[
            ListTile(
              title: Text('This is tile number'),
            ),
          ],
        ),
      ],
    );
  }
}
