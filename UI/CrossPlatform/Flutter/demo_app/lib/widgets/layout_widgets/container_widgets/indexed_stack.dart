//!IndexedStack

import 'package:flutter/material.dart';

class IndexedStackWidget extends StatefulWidget {
  const IndexedStackWidget({Key? key}) : super(key: key);

  @override
  State<IndexedStackWidget> createState() => _IndexedStackWidgetState();
}

class _IndexedStackWidgetState extends State<IndexedStackWidget> {
  int index = 0;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: Column(
        children: <Widget>[
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: <Widget>[
              ElevatedButton(
                child: const Text('0'),
                onPressed: () {
                  setState(() {
                    index = 0;
                  });
                },
              ),
              ElevatedButton(
                child: const Text('1'),
                onPressed: () {
                  setState(() {
                    index = 1;
                  });
                },
              ),
              ElevatedButton(
                child: const Text('2'),
                onPressed: () {
                  setState(() {
                    index = 2;
                  });
                },
              ),
            ],
          ),
          IndexedStack(
            index: index,
            children: <Widget>[
              Center(
                child: Image.network(
                  "https://tinyurl.com/yc4pctt5",
                ),
              ),
              Center(
                child: Image.network(
                  "https://tinyurl.com/22yj4f66",
                ),
              ),
              Center(
                child: Image.network(
                  "https://tinyurl.com/5n97bfvp",
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
