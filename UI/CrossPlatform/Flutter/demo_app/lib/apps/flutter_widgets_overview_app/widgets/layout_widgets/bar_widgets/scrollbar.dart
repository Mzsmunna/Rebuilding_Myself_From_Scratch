//! Scrollbar

import 'package:flutter/material.dart';

class ScrollBarWidget extends StatefulWidget {
  const ScrollBarWidget({Key? key}) : super(key: key);

  @override
  State<ScrollBarWidget> createState() => _ScrollBarWidgetState();
}

class _ScrollBarWidgetState extends State<ScrollBarWidget> {
  final ScrollController controller = ScrollController();

  @override
  Widget build(BuildContext context) {
    return Scrollbar(
      controller: controller,
      child: ListView.builder(
        controller: controller,
        itemCount: 40,
        itemBuilder: (BuildContext context, int index) {
          return ListTile(
            title: Text('Item ${index + 1}'),
          );
        },
      ),
    );
  }
}
