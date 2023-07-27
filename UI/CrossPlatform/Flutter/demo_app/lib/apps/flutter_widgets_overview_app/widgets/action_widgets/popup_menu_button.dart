//!PopupMenuButton

import 'package:flutter/material.dart';

class PopupMenuButtonWidget extends StatefulWidget {
  const PopupMenuButtonWidget({Key? key}) : super(key: key);

  @override
  State<PopupMenuButtonWidget> createState() => _PopupMenuButtonWidgetState();
}

class _PopupMenuButtonWidgetState extends State<PopupMenuButtonWidget> {
  String title = 'First item';
  String item1 = 'First item';
  String item2 = 'Second item';

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Text(title),
      trailing: PopupMenuButton(
        itemBuilder: (context) => [
          PopupMenuItem(
            value: item1,
            child: Text(item1),
          ),
          PopupMenuItem(
            value: item2,
            child: Text(item2),
          )
        ],
        onSelected: (String newValue) {
          setState(() {
            title = newValue;
          });
        },
      ),
    );
  }
}
