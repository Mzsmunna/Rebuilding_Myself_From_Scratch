//!CupertinoSlider

import 'package:flutter/cupertino.dart';

class CupertinoSliderWidget extends StatefulWidget {
  const CupertinoSliderWidget({Key? key}) : super(key: key);

  @override
  CupertinoSliderWidgetState createState() => CupertinoSliderWidgetState();
}

class CupertinoSliderWidgetState extends State<CupertinoSliderWidget> {
  double _currentValue = 1;
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Column(
        children: [
          const SizedBox(height: 50),
          Text(_currentValue.toString()),
          const SizedBox(height: 50),
          CupertinoSlider(
            value: _currentValue,
            min: 0,
            max: 10,
            divisions: 10,
            onChanged: (selectedValue) {
              setState(() {
                _currentValue = selectedValue;
              });
            },
          ),
        ],
      ),
    );
  }
}
