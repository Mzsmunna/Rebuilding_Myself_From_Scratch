//!ModalBarrier

import 'package:flutter/material.dart';

class ModalBarrierWidget extends StatefulWidget {
  const ModalBarrierWidget({Key? key}) : super(key: key);

  @override
  State<ModalBarrierWidget> createState() => _ModalBarrierWidgetState();
}

class _ModalBarrierWidgetState extends State<ModalBarrierWidget> {
  bool activated = true;
  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Center(
          child: ElevatedButton(
            onPressed: () {
              setState(() {
                activated = !activated;
              });
            },
            child: const Text('Reactivate'),
          ),
        ),
        if (activated)
          Opacity(
            opacity: 0.4,
            child: ModalBarrier(
              dismissible: false,
              onDismiss: () {
                setState(() {
                  activated = !activated;
                });
              },
              color: Colors.orangeAccent,
            ),
          ),
      ],
    );
  }
}
