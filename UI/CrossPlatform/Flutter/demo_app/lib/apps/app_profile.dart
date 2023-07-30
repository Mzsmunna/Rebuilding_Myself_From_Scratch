// ignore_for_file: must_be_immutable

import 'package:demo_app/apps/app_showcase.dart';
import 'package:demo_app/common/layouts/app_bar/app_top_bar.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:demo_app/common/layouts/app_drawer/app_default_drawer.dart';
import 'package:demo_app/common/widgets/image_capture_or_picker_widget.dart';
import 'package:demo_app/common/widgets/internet_connectivity_check.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
//import '../../widgets/access_widgets.dart';

class AppProfile extends StatelessWidget {
  String? username = '';
  AppProfile({super.key, this.username});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return ValueListenableBuilder(
      valueListenable: isAppDarkMode,
      builder: (context, isDarkMode, child) {
        return MaterialApp(
          title: 'User Profile',
          debugShowCheckedModeBanner: false,
          theme: isDarkMode
              ? DefaultAppTheme.darkTheme
              : DefaultAppTheme.materialThree,
          home: Scaffold(
            appBar: AppTopBar.getDefaultAppBar(
              "$username Profile",
              context,
              const AppShowcase(),
              useGoRouer: true,
              goRouterPath: '/Home',
            ),
            body: InternetConnectivityWidget(
              screen: Column(
                children: [
                  SizedBox(
                    width: 300,
                    height: 300,
                    child: ValueListenableBuilder(
                      valueListenable: selectedImageFile,
                      builder: (context, selectedImage, child) {
                        return CircleAvatar(
                          backgroundImage: AssetImage(selectedImage),
                          radius: 50,
                        );
                      },
                    ),
                  ),
                  const SizedBox(height: 10),
                  const ListTile(
                    leading: Icon(Icons.male),
                    title: Text('Mamun'),
                  ),
                  const ListTile(
                    leading: Icon(Icons.female),
                    title: Text('Maisha'),
                  ),
                  const ListTile(
                    leading: Icon(Icons.date_range_outlined),
                    title: Text('28/01/2022'),
                  ),
                ],
              ),
            ),
            floatingActionButton: const ImageCaptureOrPickerWidget(),
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
      },
    );
  }
}
