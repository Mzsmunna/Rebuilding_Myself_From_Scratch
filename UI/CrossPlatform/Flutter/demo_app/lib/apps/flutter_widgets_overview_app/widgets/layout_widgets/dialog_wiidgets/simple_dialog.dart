//! SimpleDialog

import 'package:flutter/material.dart';

class SimpleDialogWidget extends StatefulWidget {
  const SimpleDialogWidget({Key? key}) : super(key: key);

  @override
  State<SimpleDialogWidget> createState() => _SimpleDialogState();
}

class _SimpleDialogState extends State<SimpleDialogWidget> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ElevatedButton(
        onPressed: () {
          showDialog(
            context: context,
            builder: (context) => SimpleDialog(
              title: const Text('Flutter Mapp'),
              contentPadding: const EdgeInsets.all(20.0),
              children: [
                const Text('More information'),
                TextButton(
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  child: const Text('Close'),
                )
              ],
            ),
          );
        },
        child: const Text('Show Dialog'),
      ),
    );
  }
}
