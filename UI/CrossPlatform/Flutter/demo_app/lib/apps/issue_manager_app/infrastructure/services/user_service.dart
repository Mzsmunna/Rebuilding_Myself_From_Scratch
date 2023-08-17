import 'dart:async';
import 'dart:convert';

import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:shared_preferences/shared_preferences.dart';

class UserService {
  SharedPreferences? sharedPrefs;
  String? authToken;
  final String baseApiUrl = "http://192.168.1.106:5255/api/User";
  final Dio dio = Dio();
  final JsonEncoder encoder = const JsonEncoder();
  UserService() {
    sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
    authToken = sharedPrefs?.getString("auth_token");
    dio.interceptors.add(
      InterceptorsWrapper(
        onRequest: (options, handler) {
          // Add the access token to the request header
          options.headers['Authorization'] = 'Bearer $authToken';
          return handler.next(options);
        },
        onError: (DioException e, handler) async {
          if (e.response?.statusCode == 401) {
          } else {}
          return handler.next(e);
        },
      ),
    );
  }

  FutureOr<Response<dynamic>> getAllUserCount(
      List<SearchFieldModel> searchQueries) async {
    //return this.http.get(baseApiUrl + "GetAllUserCount?searchQueries=" + jsonString);
    final String searchQueriesString = encoder.convert(searchQueries);
    var response = await dio
        .get("$baseApiUrl/GetAllUserCount?searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<List<UserModel>> getAllUsers(
      int currentPage,
      int pageSize,
      String sortField,
      String sortDirection,
      List<SearchFieldModel> searchQueries) async {
    // return this.http.get(baseApiUrl + "GetAllUsers?currentPage=" + currentPage
    //   + "&pageSize=" + pageSize
    //   + "&sortField=" + sortField
    //   + "&sortDirection=" + sortDirection
    //   + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries)));

    final String searchQueriesString = encoder.convert(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllUsers?currentPage=$currentPage&pageSize=$pageSize&sortField=$sortField&sortDirection=$sortDirection&searchQueries=$searchQueriesString");
    return response.data;
  }

// FutureOr<List<AssignUser>> GetAllUserToAssign() async {

//   //return this.http.get('${baseApiUrl}GetAllUserToAssign') as Observable<AssignUser[]>;
//   var response = await dio.post("$baseApiUrl/GetAllUserToAssign");
//     return response.data;
// }

// GetUser(userId = string): Observable<User> {

//   return this.http.get('${baseApiUrl}GetUser?userId=' + userId) as Observable<User>;
// }

// SaveUser(user = User): Observable<User> {

//   return this.http.post('${baseApiUrl}SaveUser', user) as Observable<User>;
// }

// UpdateUser(user = User): Observable<User> {

//   return this.http.put('${baseApiUrl}UpdateUser', user) as Observable<User>;
// }

// DeleteUser(user = User): Observable<boolean> {

//   return this.http.delete('${baseApiUrl}DeleteUser?userId=' + user.Id) as Observable<boolean>;
// }

// SaveMedia(file = any): Observable<string> {

//   return this.http.post('${baseApiUrl}SaveMedia', file) as Observable<string>;
// }
}
