//!DraggableScrollableSheet

import 'package:flutter/material.dart';

class DraggableScrollableSheetWidget extends StatelessWidget {
  const DraggableScrollableSheetWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return DraggableScrollableSheet(
      builder: (BuildContext context, ScrollController scrollController) {
        return Container(
          color: Colors.orangeAccent,
          child: ListView.builder(
            controller: scrollController,
            itemCount: 25,
            itemBuilder: (BuildContext context, int index) {
              return ListTile(
                title: Text('Item $index'),
              );
            },
          ),
        );
      },
    );
  }
}
