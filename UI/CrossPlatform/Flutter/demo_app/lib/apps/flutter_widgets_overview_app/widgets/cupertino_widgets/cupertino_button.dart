//!CupertinoButton

import 'package:flutter/cupertino.dart';

class CupertinoButtonWidget extends StatelessWidget {
  const CupertinoButtonWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: const <Widget>[
          CupertinoButton(
            onPressed: null,
            child: Text('Enabled'),
          ),
          SizedBox(height: 30),
          CupertinoButton.filled(
            onPressed: null,
            child: Text('Enabled'),
          ),
        ],
      ),
    );
  }
}
