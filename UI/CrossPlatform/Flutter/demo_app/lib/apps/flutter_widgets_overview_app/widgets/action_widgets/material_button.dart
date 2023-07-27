//!MaterialButton

import 'package:flutter/material.dart';

class MaterialButtonWidget extends StatelessWidget {
  const MaterialButtonWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: MaterialButton(
        onPressed: () {},
        highlightColor: Colors.orangeAccent,
        splashColor: Colors.redAccent,
        color: Colors.blueGrey,
        child: const Text('Click'),
      ),
    );
  }
}
