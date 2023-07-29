import 'package:demo_app/apps/app_showcase.dart';
import 'package:demo_app/common/layouts/app_bar/app_top_bar.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
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
      theme: DefaultAppTheme.materialThree,
      home: Scaffold(
        appBar: AppTopBar.getDefaultAppBar(
          "Issue Manager App",
          context,
          const AppShowcase(),
        ),
        //body: const AbsorbPointerWidget(),
      ),
    );
  }
}
