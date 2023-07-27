import 'package:flutter/material.dart';

//! AnimatedOpacity

class AnimatedOpacityWidget extends StatefulWidget {
  const AnimatedOpacityWidget({Key? key}) : super(key: key);

  @override
  State<AnimatedOpacityWidget> createState() => AnimatedOpacityWidgetState();
}

class AnimatedOpacityWidgetState extends State<AnimatedOpacityWidget> {
  double opacityLevel = 1.0;
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: <Widget>[
          AnimatedOpacity(
            opacity: opacityLevel,
            duration: const Duration(seconds: 2),
            child: const FlutterLogo(
              size: 50,
            ),
          ),
          ElevatedButton(
            child: const Text('Fade Logo'),
            onPressed: () {
              setState(
                () => opacityLevel = opacityLevel == 0 ? 1.0 : 0.0,
              );
            },
          ),
        ],
      ),
    );
  }
}
