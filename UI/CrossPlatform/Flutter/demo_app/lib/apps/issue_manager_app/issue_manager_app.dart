import 'package:flutter/material.dart';
//import '../../widgets/access_widgets.dart';

class IssueManagerApp extends StatelessWidget {
  const IssueManagerApp({super.key});

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
          title: const Text("Issue Manager App"),
        ),
        //body: const AbsorbPointerWidget(),
      ),
    );
  }
}
