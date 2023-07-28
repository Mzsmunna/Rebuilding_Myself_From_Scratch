// ignore_for_file: must_be_immutable

import 'package:demo_app/apps/app_showcase.dart';
import 'package:demo_app/common/configs/app_bar/app_top_bar.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
//import '../../widgets/access_widgets.dart';

class AppProfile extends StatelessWidget {
  String? username = '';
  AppProfile({super.key, this.username});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'User Profile',
      debugShowCheckedModeBanner: false,
      theme: DefaultAppTheme.materialThree,
      home: Scaffold(
        appBar: AppTopBar.getDefaultAppBar(
          "$username Profile",
          context,
          const AppShowcase(),
          useGoRouer: true,
          goRouterPath: '/Home',
        ),
        //body: const AbsorbPointerWidget(),
        bottomNavigationBar: NavigationBar(
          destinations: const [
            NavigationDestination(
              icon: Icon(Icons.apps),
              label: "Apps",
            ),
            NavigationDestination(
              icon: Icon(Icons.person),
              label: "Profile",
            ),
          ],
          selectedIndex: 1,
          onDestinationSelected: (int value) {
            if (value < 1) {
              GoRouter.of(context).go("/Home");
            }
          },
        ),
      ),
    );
  }
}
