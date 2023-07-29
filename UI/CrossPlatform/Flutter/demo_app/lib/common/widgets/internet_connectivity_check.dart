import 'dart:async';

import 'package:connectivity_plus/connectivity_plus.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class InternetConnectivityWidget extends StatefulWidget {
  final Widget screen;
  const InternetConnectivityWidget({super.key, required this.screen});

  @override
  State<InternetConnectivityWidget> createState() =>
      // ignore: no_logic_in_create_state
      _InternetConnectivityWidgetState(screen: screen);
}

class _InternetConnectivityWidgetState
    extends State<InternetConnectivityWidget> {
  late ConnectivityResult connectivityResult;
  late StreamSubscription subscription;
  final Widget screen;

  _InternetConnectivityWidgetState({required this.screen});

  @override
  void initState() {
    super.initState();
    startStreaming();
  }

  checkInternet() async {
    connectivityResult = await Connectivity().checkConnectivity();

    if (connectivityResult == ConnectivityResult.none) {
      //print("no internet");
      showDialogBox();
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
    setState(() {});
  }

  showDialogBox() {
    showDialog(
      //barrierDismissible: false,
      context: context,
      builder: (context) => AlertDialog(
        title: const Text("No Internet Connection"),
        content: const Text("Please check your internet connection"),
        actions: [
          TextButton(
            child: const Text("Retry"),
            onPressed: () {
              //checkInternet();
              GoRouter.of(context)
                  //.goNamed('Profile', pathParameters: {"username": "Mzs"});
                  .goNamed('Profile',
                      queryParameters: {"username": "Mamun & Maisha's"});
            },
          ),
        ],
      ),
    );
  }

  startStreaming() {
    subscription = Connectivity().onConnectivityChanged.listen(
      (event) async {
        checkInternet();
      },
    );
  }

  // Be sure to cancel subscription after you are done
  @override
  dispose() {
    subscription.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return screen;
  }
}
