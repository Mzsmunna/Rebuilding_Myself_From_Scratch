//! Theme

import 'package:flutter/material.dart';

class ThemeWidget extends StatelessWidget {
  const ThemeWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        brightness: Brightness.dark,
        primaryColor: Colors.orangeAccent,
      ),
      home: Scaffold(
        body: Container(
          width: double.infinity,
          height: double.infinity,
          color: Theme.of(context).colorScheme.primary,
        ),
      ),
    );
  }
}
