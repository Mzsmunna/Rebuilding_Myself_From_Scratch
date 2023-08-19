import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:jwt_decoder/jwt_decoder.dart';
import 'package:shared_preferences/shared_preferences.dart';

class DioHttp {
  static Dio? dio;
  static String? authToken;
  static bool isLoggedIn = false;
  static SharedPreferences? sharedPrefs =
      sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();

  DioHttp() {
    dio ??= Dio();
  }

  static Dio getDioInstance() {
    dio ??= Dio();
    return dio!;
  }

  static bool injectAuthToken({String? authKey}) {
    getDioInstance();
    authKey ??= "auth_token";
    authToken = sharedPrefs?.getString(authKey);
    bool isTokenExpired = JwtDecoder.isExpired(authToken!);
    if (!isTokenExpired) {
      dio?.interceptors.add(
        InterceptorsWrapper(
          onRequest: (options, handler) {
            // Add the access token to the request header
            options.headers['Authorization'] = 'Bearer $authToken';
            return handler.next(options);
          },
          onError: (DioException e, handler) async {
            if (e.response?.statusCode == 401) {
              isLoggedIn = false;

              // If a 401 response is received, refresh the access token
              //String newAccessToken = await refreshToken();

              //sharedPrefs?.remove("auth_token");

              // Update the request header with the new access token
              //e.requestOptions.headers['Authorization'] = 'Bearer $newAccessToken';

              // Repeat the request with the updated header
              //return handler.resolve(await dio.fetch(e.requestOptions));
            } else {
              isLoggedIn = true;
            }
            return handler.next(e);
          },
        ),
      );
    } else {
      isLoggedIn = true;
    }
    return isLoggedIn;
  }
}
