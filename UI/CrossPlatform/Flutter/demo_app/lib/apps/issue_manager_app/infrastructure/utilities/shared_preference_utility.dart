import 'package:shared_preferences/shared_preferences.dart';

class AppSharedPreferences {
  static SharedPreferences? sharedPrefs;

  AppSharedPreferences() {
    getSharedPreferenceInstance();
  }

  static SharedPreferences? getSharedPreferenceInstance() {
    if (sharedPrefs == null) {
      SharedPreferences.getInstance().then((value) {
        sharedPrefs = value;
        return sharedPrefs;
      });
    }
    return sharedPrefs;
  }
}
