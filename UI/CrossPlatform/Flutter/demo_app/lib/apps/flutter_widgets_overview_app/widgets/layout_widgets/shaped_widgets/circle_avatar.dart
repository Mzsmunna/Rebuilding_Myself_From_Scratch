//! CircleAvatar
import 'package:flutter/material.dart';

class CircleAvatarWidget extends StatelessWidget {
  const CircleAvatarWidget({Key? key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return const Center(
      child: CircleAvatar(
        backgroundColor: Colors.orangeAccent,
        radius: 55,
        backgroundImage: AssetImage('assets/icon/blue.jpg'),
        child: Text('Hi'),
      ),
    );
  }
}
