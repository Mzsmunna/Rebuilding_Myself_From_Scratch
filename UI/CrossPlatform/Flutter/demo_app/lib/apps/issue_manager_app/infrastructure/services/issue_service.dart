import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';

class IssueService {
  bool isLoggedIn = false;
  IssueService();

  bool isAuthenticated() {
    var sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
    var authToken = sharedPrefs?.getString("auth_token");

    if (authToken != null) {
      const String baseUrl = "http://10.0.2.2:5255";
      final dio = Dio();
      //final Map<String, dynamic> queryJson = {"searchQueries": ""};

      try {
        dio.interceptors.add(
          InterceptorsWrapper(
            onRequest: (options, handler) {
              // Add the access token to the request header
              options.headers['Authorization'] = 'Bearer $authToken';
              return handler.next(options);
            },
            onError: (DioException e, handler) async {
              if (e.response?.statusCode == 401) {
                // If a 401 response is received, refresh the access token
                //String newAccessToken = await refreshToken();
                isLoggedIn = false;
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

        dio
            .get("$baseUrl/api/Issue/GetAllIssueCount?searchQueries=")
            .then((response) {
          //queryParameters: queryJson);
          //print(response.statusCode);
          //print(response.data);
          if (response.statusCode == 401) {
            isLoggedIn = false;
            //sharedPrefs?.remove("auth_token");
          } else {
            isLoggedIn = true;
          }
        });
      } catch (ex) {
        // ignore: avoid_print
        print(ex);
        isLoggedIn = false;
      } finally {
        dio.close();
      }
    } else {
      isLoggedIn = false;
    }
    return isLoggedIn;
  }
}
