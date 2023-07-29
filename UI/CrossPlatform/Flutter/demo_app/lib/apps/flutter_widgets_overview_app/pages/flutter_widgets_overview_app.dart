import 'package:demo_app/apps/app_showcase.dart';
import 'package:demo_app/common/layouts/app_bar/app_top_bar.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:flutter/material.dart';
import 'flutter_widget_list.dart';

class FlutterwidgetsApp extends StatelessWidget {
  const FlutterwidgetsApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Demo AFF',
      debugShowCheckedModeBanner: false,
      theme: DefaultAppTheme.darkTheme,
      home: const Scaffold(
        appBar: MyAppBar(),
        body: FlutterWidgetList(),
      ),
    );
  }
}

class MyAppBar extends StatefulWidget implements PreferredSizeWidget {
  const MyAppBar({Key? key}) : super(key: key);

  @override
  Size get preferredSize => const Size.fromHeight(60);

  @override
  State<MyAppBar> createState() => _MyAppBarState();
}

class _MyAppBarState extends State<MyAppBar> {
  @override
  Widget build(BuildContext context) {
    return AppTopBar.getWidgetAppBar(
      "Review Flutter Widgets",
      context,
      const AppShowcase(),
    );
  }
}
