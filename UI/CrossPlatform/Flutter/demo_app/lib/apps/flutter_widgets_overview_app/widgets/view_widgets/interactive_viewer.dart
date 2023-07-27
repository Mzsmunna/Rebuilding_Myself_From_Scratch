//! InteractiveViewer

import 'package:flutter/material.dart';

class InteractiveViewerWidget extends StatefulWidget {
  const InteractiveViewerWidget({Key? key}) : super(key: key);

  @override
  State<InteractiveViewerWidget> createState() =>
      _InteractiveViewerWidgetState();
}

class _InteractiveViewerWidgetState extends State<InteractiveViewerWidget> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.orangeAccent,
      body: InteractiveViewer(
        boundaryMargin: const EdgeInsets.all(
          double.infinity,
        ),
        child: Scaffold(
          appBar: AppBar(
            title: const Text(
              'Flutter Mapp',
            ),
          ),
        ),
      ),
    );
  }
}
