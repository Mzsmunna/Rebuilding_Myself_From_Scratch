//! Offstage

import 'package:flutter/material.dart';

class OffstageWidget extends StatefulWidget {
  const OffstageWidget({Key? key}) : super(key: key);

  @override
  State<OffstageWidget> createState() => _OffstageWidgetState();
}

class _OffstageWidgetState extends State<OffstageWidget> {
  bool isHided = true;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Offstage(
            offstage: isHided,
            child: const Icon(
              Icons.flutter_dash,
              size: 100,
            ),
          ),
          ElevatedButton(
            child: Text('isHided = $isHided'),
            onPressed: () {
              setState(() {
                isHided = !isHided;
              });
            },
          ),
        ],
      ),
    );
  }
}
