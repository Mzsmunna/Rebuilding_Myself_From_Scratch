import 'dart:async';

import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:jwt_decoder/jwt_decoder.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthService {
  bool isLoggedIn = false;
  SharedPreferences? sharedPrefs;
  String? authToken;
  //final String authApiUrl = "http://localhost:5280/api/Auth";
  //final String authApiUrl = "http://192.168.1.106:5280/api/Auth";
  final String authApiUrl = "http://10.0.2.2:5280/api/Auth";
  final String issueApiUrl = "http://10.0.2.2:5255/api/Issue";
  final Dio dio = Dio();
  String userId = "";
  AuthService() {
    sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
    authToken = sharedPrefs?.getString("auth_token");
  }

  bool isAuthenticated(bool validateToken) {
    if (authToken != null) {
      if (validateToken) {
        bool hasExpired = JwtDecoder.isExpired(authToken!);
        if (hasExpired) {
          isLoggedIn = false;
        } else {
          isLoggedIn = true;
        }
      } else {
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
              .get("$issueApiUrl/GetAllIssueCount?searchQueries=")
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
      }
    } else {
      isLoggedIn = false;
    }
    return isLoggedIn;
  }

  FutureOr<String> getRefreshToken(UserModel userModel) async {
    //return this.http.post('${authApiUrl}GetRefreshToken', user);
    final Map<String, dynamic> userJson = userModel.toJson();
    var response =
        await dio.post("$authApiUrl/GetRefreshToken", data: userJson);
    return response.data;
  }

  FutureOr<Response<dynamic>> doRegister(UserModel userModel) async {
    //return this.http.post('${authApiUrl}RegisterWithEmail', user);
    final Map<String, dynamic> userJson = userModel.toJson();
    var response =
        await dio.post("$authApiUrl/RegisterWithEmail", data: userJson);
    return response;
  }

  FutureOr<Response<dynamic>> doLogin(UserModel userModel) async {
    //return this.http.post('${authApiUrl}LoginWithEmail', user, { responseType: 'text' });
    final Map<String, dynamic> userJson = userModel.toJson();
    var response = await dio.post("$authApiUrl/LoginWithEmail", data: userJson);
    return response;
  }

  FutureOr<String> doLoginWithGoogle(String credential) async {
    //const header = HttpHeaders().set('Content-type', 'application/json');
    //return this.http.post(this.authApiUrl + "LoginWithGoogle", JSON.stringify(credentials), { headers: header, responseType: 'text' }) as Observable<string>;
    final Map<String, dynamic> credentialJson = {"credential": credential};
    var response = await dio.post("$authApiUrl/LoginWithGoogle",
        queryParameters: credentialJson);
    return response.data;
  }

  FutureOr<UserModel> getLoggedUser() async {
    userId = getCurrentUserId();
    //return this.http.get(this.baseApiUrl + 'GetUser?userId=' + userId);
    final Map<String, dynamic> userIdJson = {"userId": userId};
    var response =
        await dio.post("$authApiUrl/GetUser", queryParameters: userIdJson);
    return response.data;
  }

  doLogout() {
    sharedPrefs?.remove("auth_token");
    //this.route.navigate(['auth/login']);
  }

  String? getToken() {
    authToken = sharedPrefs?.getString("auth_token");
    if (authToken != null) {
      return authToken;
    } else {
      return '';
    }
  }

  String? getCurrentUserRole() {
    authToken = sharedPrefs?.getString("auth_token");
    if (authToken != null) {
      Map<String, dynamic> claims = JwtDecoder.decode(authToken!);
      return claims[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    } else {
      return '';
    }
  }

  String getCurrentUserId() {
    authToken = sharedPrefs?.getString("auth_token");
    if (authToken != null) {
      Map<String, dynamic> claims = JwtDecoder.decode(authToken!);
      return claims[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    } else {
      return '';
    }
  }

  bool isAdmin() {
    var role = getCurrentUserRole();
    if (role != null && role != "" && role.toLowerCase() != 'user') {
      return true;
    } else {
      return false;
    }
  }
}
