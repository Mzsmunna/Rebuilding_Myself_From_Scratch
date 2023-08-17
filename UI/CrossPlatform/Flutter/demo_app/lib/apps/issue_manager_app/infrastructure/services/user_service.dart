import 'dart:async';
import 'dart:convert';

import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/helpers/issue_manager_helper.dart';
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
    //String searchQueriesString = encoder.convert(searchQueries);
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio
        .get("$baseApiUrl/GetAllUserCount?searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllUsers(
      int currentPage,
      int pageSize,
      String sortField,
      String sortDirection,
      List<SearchFieldModel> searchQueries) async {
    final String searchQueriesString = encoder.convert(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllUsers?currentPage=$currentPage&pageSize=$pageSize&sortField=$sortField&sortDirection=$sortDirection&searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllUserToAssign() async {
    //return this.http.get('${baseApiUrl}GetAllUserToAssign') as Observable<AssignUser[]>;
    var response = await dio.get("$baseApiUrl/GetAllUserToAssign");
    return response;
  }

  FutureOr<Response<dynamic>> getUser(String userId) async {
    var response = await dio.get('$baseApiUrl/GetUser?userId=$userId');
    return response;
  }

  FutureOr<Response<dynamic>> saveUser(UserModel userModel) async {
    var response = await dio.post('$baseApiUrl/SaveUser', data: userModel);
    return response;
  }

  FutureOr<Response<dynamic>> updateUser(UserModel userModel) async {
    var response = await dio.put('$baseApiUrl/UpdateUser', data: userModel);
    return response;
  }

  FutureOr<Response<dynamic>> deleteUser(UserModel userModel) async {
    var response =
        await dio.delete('$baseApiUrl/DeleteUser?userId=${userModel.id}');
    return response;
  }

// FutureOr<Response<dynamic>> saveMedia(file = any): Observable<string> {

//   return this.http.post('${baseApiUrl}SaveMedia', file) as Observable<string>;
// }
}
