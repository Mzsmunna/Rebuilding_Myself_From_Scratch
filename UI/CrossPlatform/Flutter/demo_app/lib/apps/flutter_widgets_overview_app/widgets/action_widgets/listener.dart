//!Listener

import 'package:flutter/material.dart';

class ListenerWidget extends StatefulWidget {
  const ListenerWidget({Key? key}) : super(key: key);

  @override
  State<ListenerWidget> createState() => _ListenerWidgetState();
}

class _ListenerWidgetState extends State<ListenerWidget> {
  int numberOfPresses = 0;
  int numberOfreleases = 0;
  double x = 0.0;
  double y = 0.0;

  @override
  Widget build(BuildContext context) {
    return Listener(
      onPointerDown: (PointerDownEvent event) {
        setState(() {
          numberOfPresses++;
        });
      },
      onPointerMove: (PointerEvent details) {
        setState(() {
          x = details.position.dx;
          y = details.position.dy;
        });
      },
      onPointerUp: (PointerEvent details) {
        setState(() {
          numberOfreleases++;
        });
      },
      child: Container(
        width: double.infinity,
        height: double.infinity,
        color: Colors.orangeAccent,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Text(
              'presses: $numberOfPresses',
              style: const TextStyle(
                fontSize: 40,
              ),
            ),
            Text(
              'releases: $numberOfreleases',
              style: const TextStyle(
                fontSize: 40,
              ),
            ),
            Text(
              'Curser: (${x.toStringAsFixed(2)}, ${y.toStringAsFixed(2)})',
              style: const TextStyle(
                fontSize: 25,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
