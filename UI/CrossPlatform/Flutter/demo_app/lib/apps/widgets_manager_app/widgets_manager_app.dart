import 'package:flutter/material.dart';
import '../../apps/widgets_manager_app/pages/flutter_widget_list.dart';

class WidgetsManagerApp extends StatelessWidget {
  const WidgetsManagerApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Demo AFF',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.green,
      ),
      home: Scaffold(
        appBar: AppBar(
          title: const Text("Review Flutter Widgets"),
        ),
        body: const FlutterWidgetList(),
      ),
    );
  }
}
