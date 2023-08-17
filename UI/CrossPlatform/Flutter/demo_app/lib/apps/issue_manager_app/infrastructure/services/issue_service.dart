import 'dart:async';
import 'dart:convert';

import 'package:demo_app/apps/issue_manager_app/domain/entities/issue_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/helpers/issue_manager_helper.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:shared_preferences/shared_preferences.dart';

class IssueService {
  SharedPreferences? sharedPrefs;
  String? authToken;
  final String baseApiUrl = "http://192.168.1.106:5255/api/Issue";
  final Dio dio = Dio();
  final JsonEncoder encoder = const JsonEncoder();
  IssueService() {
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

  FutureOr<Response<dynamic>> getAllIssueCount(
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio
        .get("$baseApiUrl/GetAllIssueCount?searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllIssuesByAssignerCount(
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllIssuesByAssignerCount?searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllIssuesByAssignedCount(
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllIssuesByAssignedCount?searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllIssues(
      int currentPage,
      int pageSize,
      String sortField,
      String sortDirection,
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllIssues?currentPage=$currentPage&pageSize=$pageSize&sortField=$sortField&sortDirection=$sortDirection&searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getIssueStatByUserId(String userId) async {
    var response =
        await dio.get("$baseApiUrl/GetIssueStatByUserId?userId=$userId");
    return response;
  }

  FutureOr<Response<dynamic>> getAllIssuesByAssigner(
      int currentPage,
      int pageSize,
      String sortField,
      String sortDirection,
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllIssuesByAssigner?currentPage=$currentPage&pageSize=$pageSize&sortField=$sortField&sortDirection=$sortDirection&searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> getAllIssuesByAssigned(
      int currentPage,
      int pageSize,
      String sortField,
      String sortDirection,
      List<SearchFieldModel> searchQueries) async {
    String searchQueriesString =
        IssueManagerHelper.getSearchQueriesjsonEncode(searchQueries);
    var response = await dio.get(
        "$baseApiUrl/GetAllIssuesByAssigned?currentPage=$currentPage&pageSize=$pageSize&sortField=$sortField&sortDirection=$sortDirection&searchQueries=$searchQueriesString");
    return response;
  }

  FutureOr<Response<dynamic>> saveIssue(IssueModel issue) async {
    var response = await dio.post('$baseApiUrl/SaveIssue', data: issue);
    return response;
  }

  FutureOr<Response<dynamic>> deleteIssue(IssueModel issue) async {
    var response =
        await dio.delete('$baseApiUrl/DeleteIssue?issueId=${issue.id}');
    return response;
  }
}
