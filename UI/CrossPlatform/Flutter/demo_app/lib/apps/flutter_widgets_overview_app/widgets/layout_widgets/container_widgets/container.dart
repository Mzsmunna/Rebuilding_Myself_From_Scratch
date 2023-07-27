//!Container

import 'package:flutter/material.dart';

class ContainerWidget extends StatelessWidget {
  const ContainerWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(8.0),
      color: Colors.orangeAccent,
      alignment: Alignment.center,
      constraints: const BoxConstraints.expand(height: 200),
      transform: Matrix4.rotationZ(0.2),
      child: const Text('Flutter Mapp'),
    );
  }
}
