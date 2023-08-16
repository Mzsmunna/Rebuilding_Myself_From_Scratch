import 'dart:async';

import 'package:shared_preferences/shared_preferences.dart';

class AppSharedPreferences {
  static SharedPreferences? sharedPrefs;

  AppSharedPreferences() {
    getSharedPreferenceInstance();
  }

  static FutureOr<SharedPreferences?> getSharedPreferenceInstance() async {
    sharedPrefs ??= await SharedPreferences.getInstance();
    return sharedPrefs;
  }
}
