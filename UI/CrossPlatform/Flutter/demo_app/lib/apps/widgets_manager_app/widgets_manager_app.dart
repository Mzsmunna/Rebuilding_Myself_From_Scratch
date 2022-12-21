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
        primarySwatch: Colors.blueGrey,
      ),
      home: Scaffold(
        appBar: MyAppBar(),
        body: FlutterWidgetList(),
      ),
    );
  }
}

class MyAppBar extends StatefulWidget implements PreferredSizeWidget {
  MyAppBar() : super();

  @override
  Size get preferredSize => const Size.fromHeight(60);

  @override
  _MyAppBarState createState() => _MyAppBarState();
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
