//! Transform

import 'package:flutter/material.dart';

class TransformWidget extends StatelessWidget {
  const TransformWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Transform(
        alignment: Alignment.center,
        transform: Matrix4.rotationZ(45),
        child: Image.asset('assets/icon/ocean.jpg'),
      ),
    );
  }
}
