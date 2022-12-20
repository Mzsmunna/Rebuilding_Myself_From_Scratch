//!ListWheelScrollView

import 'package:flutter/material.dart';

class ListWheelScrollViewWidget extends StatefulWidget {
  const ListWheelScrollViewWidget({Key? key}) : super(key: key);

  @override
  _ListWheelScrollViewWidgetState createState() =>
      _ListWheelScrollViewWidgetState();
}

class _ListWheelScrollViewWidgetState extends State<ListWheelScrollViewWidget> {
  @override
  Widget build(BuildContext context) {
    return ListWheelScrollView(
      itemExtent: 100,
      // diameterRatio: 2,
      // offAxisFraction: 2,
      // squeeze: 2,
      children: List.generate(
        20,
        (index) => ListTile(
          title: const Text('Flutter Mapp'),
          onTap: () {},
          leading: const Icon(Icons.person),
          trailing: const Icon(Icons.menu),
        ),
      ),
    );
  }
}
