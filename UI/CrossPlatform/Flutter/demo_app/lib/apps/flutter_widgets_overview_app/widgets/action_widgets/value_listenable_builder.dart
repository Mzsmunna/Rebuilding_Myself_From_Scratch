//! ValueListenableBuilder

import 'package:flutter/material.dart';

final ValueNotifier<int> number = ValueNotifier(0);

class ValueListenableBuilderWidget extends StatelessWidget {
  const ValueListenableBuilderWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          IconButton(
            onPressed: () {
              number.value += 1;
            },
            icon: const Icon(Icons.add),
          ),
          const SizedBox(height: 30),
          ValueListenableBuilder(
            valueListenable: number,
            builder: (BuildContext context, int value, Widget? child) {
              return Text(
                '$value',
                style: const TextStyle(fontSize: 30),
              );
            },
          ),
        ],
      ),
    );
  }
}
