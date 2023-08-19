import 'package:shared_preferences/shared_preferences.dart';

class AppSharedPreferences {
  static late SharedPreferences localStorage;

  AppSharedPreferences() {
    init();
  }

  static Future<SharedPreferences> init() async {
    localStorage = await SharedPreferences.getInstance();
    return localStorage;
  }

  static SharedPreferences getSharedPreferenceInstance() {
    // ignore: unnecessary_null_comparison
    if (localStorage == null) {
      SharedPreferences.getInstance().then((value) {
        localStorage = value;
        return localStorage;
      });
    }
    return localStorage;
  }
}
