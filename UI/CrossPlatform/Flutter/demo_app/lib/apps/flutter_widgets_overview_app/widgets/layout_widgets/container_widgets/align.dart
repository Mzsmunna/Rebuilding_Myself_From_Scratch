import 'package:flutter/material.dart';

//! Align

class AlignWidget extends StatelessWidget {
  const AlignWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Container(
        height: 120.0,
        width: double.infinity,
        color: Colors.blueGrey,
        child: const Align(
          alignment: Alignment.bottomLeft,
          child: FlutterLogo(
            size: 60,
          ),
        ),
      ),
    );
  }
}
