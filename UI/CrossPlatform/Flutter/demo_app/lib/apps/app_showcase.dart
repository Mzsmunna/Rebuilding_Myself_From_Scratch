import 'package:connectivity_plus/connectivity_plus.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:demo_app/common/layouts/app_drawer/app_default_drawer.dart';
import 'package:demo_app/common/widgets/scrolling_gesture_detector_cards_column_widget.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
//import '../../widgets/access_widgets.dart';

class AppShowcase extends StatefulWidget {
  const AppShowcase({super.key});

  @override
  State<AppShowcase> createState() => _AppShowcaseState();
}

class _AppShowcaseState extends State<AppShowcase> {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    getDarkThemeConfig();
    return StreamBuilder<ConnectivityResult>(
      stream: Connectivity().onConnectivityChanged,
      builder: (context, snapshot) {
        return ValueListenableBuilder(
          valueListenable: isAppDarkMode,
          builder: (context, isDarkMode, child) {
            return MaterialApp(
              title: 'App Showcase',
              debugShowCheckedModeBanner: false,
              theme: isDarkMode
                  ? DefaultAppTheme.darkTheme
                  : DefaultAppTheme.materialThree,
              home: Scaffold(
                appBar: AppBar(
                  title: const Text("App Showcase"),
                ),
                drawer: const AppDefaultDrawer(),
                drawerEnableOpenDragGesture: true,
                body: snapshot.data == ConnectivityResult.none
                    ? const Center(
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Icon(
                              Icons.wifi_off_rounded,
                              size: 50,
                            ),
                            Text("No internet connection"),
                          ],
                        ),
                      )
                    : const ScrollingGestureDetectorCardsColumnWidget(),
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
                  selectedIndex: 0,
                  onDestinationSelected: (int value) {
                    if (value > 0) {
                      //GoRouter.of(context).go("/Profile/Mzs");
                      GoRouter.of(context)
                          //.goNamed('Profile', pathParameters: {"username": "Mzs"});
                          .goNamed('Profile', queryParameters: {
                        "username": "Mamun & Maisha's"
                      });
                    }
                  },
                ),
              ),
            );
          },
        );
      },
    );
  }
}
