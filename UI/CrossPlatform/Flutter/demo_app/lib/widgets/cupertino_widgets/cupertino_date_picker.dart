//!CupertinoDatePicker

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class CupertinoDatePickerWidget extends StatefulWidget {
  const CupertinoDatePickerWidget({Key? key}) : super(key: key);

  @override
  State<CupertinoDatePickerWidget> createState() =>
      _CupertinoDatePickerWidgetState();
}

class _CupertinoDatePickerWidgetState extends State<CupertinoDatePickerWidget> {
  Duration duration = const Duration(seconds: 1);

  @override
  Widget build(BuildContext context) {
    return CupertinoPageScaffold(
      child: Center(
        child: CupertinoButton(
          child: Text(
              '${duration.inHours}-${duration.inMinutes}-${duration.inSeconds}'),
          onPressed: () {
            showCupertinoModalPopup(
              context: context,
              builder: (BuildContext context) => SizedBox(
                height: 250,
                child: CupertinoTimerPicker(
                  backgroundColor: Colors.orangeAccent,
                  onTimerDurationChanged: (Duration newTime) {
                    setState(() => duration = newTime);
                  },
                ),
              ),
            );
          },
        ),
      ),
    );
  }
}
