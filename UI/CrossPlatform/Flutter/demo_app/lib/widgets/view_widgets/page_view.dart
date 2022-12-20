//!PageView

import 'package:flutter/material.dart';

class PageViewWidget extends StatefulWidget {
  const PageViewWidget({Key? key}) : super(key: key);

  @override
  State<PageViewWidget> createState() => _PageViewWidgetState();
}

class _PageViewWidgetState extends State<PageViewWidget> {
  @override
  Widget build(BuildContext context) {
    return PageView(
      children: [
        Container(
          color: Colors.orangeAccent,
          child: const Center(
            child: Text(
              "1",
              style: TextStyle(fontSize: 100),
            ),
          ),
        ),
        Container(
          color: Colors.redAccent,
          child: const Center(
            child: Text(
              "2",
              style: TextStyle(fontSize: 100),
            ),
          ),
        ),
        Container(
          color: Colors.blueGrey,
          child: const Center(
            child: Text(
              "3",
              style: TextStyle(fontSize: 100),
            ),
          ),
        ),
      ],
    );
  }
}
