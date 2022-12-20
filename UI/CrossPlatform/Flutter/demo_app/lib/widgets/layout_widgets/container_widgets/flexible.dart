//!Flexible

import 'package:flutter/material.dart';

class FlexibleWidget extends StatefulWidget {
  const FlexibleWidget({Key? key}) : super(key: key);

  @override
  State<FlexibleWidget> createState() => _FlexibleWidgetState();
}

class _FlexibleWidgetState extends State<FlexibleWidget> {
  TextStyle textStyle = const TextStyle(
    color: Colors.white,
    fontSize: 20,
    fontWeight: FontWeight.bold,
  );
  Widget buildExpanded() => Expanded(
        child: Container(
          decoration: BoxDecoration(
            border: Border.all(color: Colors.white, width: 2),
            color: Colors.orangeAccent[700],
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(
              'Expanded',
              style: textStyle,
            ),
          ),
        ),
      );

  Widget buildFlexible() => Flexible(
        child: Container(
          decoration: BoxDecoration(
            border: Border.all(color: Colors.white, width: 2),
            color: Colors.blue,
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(
              'Flexible',
              style: textStyle,
            ),
          ),
        ),
      );

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Row(
            children: <Widget>[
              buildExpanded(),
              buildFlexible(),
            ],
          ),
          Row(
            children: <Widget>[
              buildExpanded(),
              buildExpanded(),
            ],
          ),
          Row(
            children: <Widget>[
              buildFlexible(),
              buildFlexible(),
            ],
          ),
        ],
      ),
    );
  }
}
