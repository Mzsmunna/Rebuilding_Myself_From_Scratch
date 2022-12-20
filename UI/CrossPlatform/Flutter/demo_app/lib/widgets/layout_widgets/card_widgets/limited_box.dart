//!LimitedBox

import 'package:flutter/material.dart';

class LimitedBoxWidget extends StatelessWidget {
  const LimitedBoxWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: LimitedBox(
          maxHeight: 50,
          //maxWidth: 300,
          child: Card(
            child: ListTile(
              leading: Icon(
                Icons.person,
                size: 50,
              ),
              title: Text('Flutter Mapp'),
            ),
          ),
        ),
      ),
    );
  }
}
