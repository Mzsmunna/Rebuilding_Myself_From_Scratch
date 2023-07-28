//!MergeSemantics

import 'package:flutter/material.dart';

class MergeSemanticsWidget extends StatelessWidget {
  const MergeSemanticsWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const MergeSemantics(
      child: Row(
        children: [
          Icon(Icons.person),
          Text('Flutter Mapp'),
        ],
      ),
    );
  }
}
