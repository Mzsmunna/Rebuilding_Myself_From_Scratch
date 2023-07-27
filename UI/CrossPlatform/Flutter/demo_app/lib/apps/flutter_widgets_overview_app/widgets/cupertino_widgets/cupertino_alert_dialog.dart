//!CupertinoAlertDialog

import 'package:flutter/cupertino.dart';

class CupertinoAlertDialogWidget extends StatefulWidget {
  const CupertinoAlertDialogWidget({Key? key}) : super(key: key);

  @override
  State<CupertinoAlertDialogWidget> createState() =>
      _CupertinoAlertDialogWidgetState();
}

class _CupertinoAlertDialogWidgetState
    extends State<CupertinoAlertDialogWidget> {
  @override
  Widget build(BuildContext context) {
    return CupertinoPageScaffold(
      child: Center(
        child: CupertinoButton(
          onPressed: () {
            showCupertinoDialog<void>(
              context: context,
              builder: (BuildContext context) => CupertinoAlertDialog(
                title: const Text('Alert'),
                content: const Text('Are you subscribe to Flutter Mapp?'),
                actions: <CupertinoDialogAction>[
                  CupertinoDialogAction(
                    isDestructiveAction: true,
                    onPressed: () {
                      Navigator.pop(context);
                    },
                    child: const Text('No'),
                  ),
                  CupertinoDialogAction(
                    child: const Text('Yes'),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                  )
                ],
              ),
            );
          },
          child: const Text('CupertinoAlertDialog'),
        ),
      ),
    );
  }
}
