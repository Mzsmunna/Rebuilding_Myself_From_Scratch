import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:demo_app/common/widgets/scrolling_gesture_detector_cards_column_widget.dart';
import 'package:flutter/material.dart';
//import '../../widgets/access_widgets.dart';

class AppShowcase extends StatelessWidget {
  const AppShowcase({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'App Showcase',
      debugShowCheckedModeBanner: false,
      theme: DefaultAppTheme.materialThree,
      home: Scaffold(
        appBar: AppBar(
          title: const Text("App Showcase"),
        ),
        body: const ScrollingGestureDetectorCardsColumnWidget(),
      ),
    );
  }
}
