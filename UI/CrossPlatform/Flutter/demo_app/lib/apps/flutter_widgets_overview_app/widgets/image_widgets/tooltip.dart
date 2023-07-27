//!Tooltip
import 'package:flutter/material.dart';

class TooltipWidget extends StatelessWidget {
  const TooltipWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Tooltip(
        message: 'This is an image',
        child: Image.asset('lib/assets/icons/wave.png'),
      ),
    );
  }
}
