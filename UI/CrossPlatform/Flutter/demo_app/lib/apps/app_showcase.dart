import 'dart:async';

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
  late StreamSubscription<ConnectivityResult> connectivitySubscription;

  @override
  void initState() {
    super.initState();
    connectivitySubscription = Connectivity().onConnectivityChanged.listen(
      (ConnectivityResult connectivityResult) {
        //print("connectivityResult....");
        if (connectivityResult == ConnectivityResult.none) {
          //print("no internet");
          // I am not connected to any network.
        } else {
          //print("success");
          if (connectivityResult == ConnectivityResult.mobile) {
            // I am connected to a mobile network.
          } else if (connectivityResult == ConnectivityResult.wifi) {
            // I am connected to a wifi network.
          } else if (connectivityResult == ConnectivityResult.ethernet) {
            // I am connected to a ethernet network.
          } else if (connectivityResult == ConnectivityResult.vpn) {
            // I am connected to a vpn network.
            // Note for iOS and macOS:
            // There is no separate network interface type for [vpn].
            // It returns [other] on any device (also simulator)
          } else if (connectivityResult == ConnectivityResult.bluetooth) {
            // I am connected to a bluetooth.
          } else if (connectivityResult == ConnectivityResult.other) {
            // I am connected to a network which is not in the above mentioned networks.
          }
        }
      },
    );
  }

  // Be sure to cancel subscription after you are done
  @override
  dispose() {
    connectivitySubscription.cancel();
    super.dispose();
  }

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
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
            body: const ScrollingGestureDetectorCardsColumnWidget(),
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
                      .goNamed('Profile',
                          queryParameters: {"username": "Mamun & Maisha's"});
                }
              },
            ),
          ),
        );
      },
    );
  }
}
