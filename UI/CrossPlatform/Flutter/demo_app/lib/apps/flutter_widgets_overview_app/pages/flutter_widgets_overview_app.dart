import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:flutter/material.dart';
import 'flutter_widget_list.dart';

class WidgetsManagerApp extends StatelessWidget {
  const WidgetsManagerApp({super.key});

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
    return AppBar(
      title: const Text("Review Flutter Widgets"),
      actions: <Widget>[
        IconButton(
          icon: const Icon(Icons.list_alt),
          onPressed: () {},
        ),
        IconButton(
          icon: const Icon(Icons.library_books_outlined),
          onPressed: () {},
        ),
        IconButton(
          icon: const Icon(Icons.grid_on),
          onPressed: () {},
        ),
      ],
    );
  }
}
