import 'dart:async';

import 'package:demo_app/apps/app_error.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issue_home_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/login/login_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/register/register_page.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

// ignore: must_be_immutable
class IssueManagerGoRouterConfig extends StatelessWidget {
  final bool isConditional;
  bool isLoggedIn = false;
  late final GoRouter _issueManagerRouterConfig;
  IssueManagerGoRouterConfig({super.key, required this.isConditional}) {
    _issueManagerRouterConfig = GoRouter(
      initialLocation: "/IssueManager",
      errorBuilder: (context, state) => const AppError(),
      redirect: (context, state) {
        if (isConditional) {
          isAuthenticated();
          if (isLoggedIn) {
            return '/IssueManager/IssueHome';
          }
        }
        return '/IssueManager';
      },
      routes: [
        GoRoute(
          path: '/IssueManager',
          builder: (context, state) => LoginPage(),
          routes: [
            GoRoute(
              name: 'Login',
              path: 'Login',
              builder: (context, state) => LoginPage(),
            ),
            GoRoute(
              name: 'Register',
              path: 'Register',
              builder: (context, state) => RegisterPage(),
            ),
            GoRoute(
              name: 'IssueHome',
              path: 'IssueHome',
              builder: (context, state) => const IssueHome(),
            ),
          ],
        ),
      ],
    );
  }

  FutureOr<bool> isAuthenticated() async {
    var sharedPrefs = await AppSharedPreferences.getSharedPreferenceInstance();

    var authToken = sharedPrefs?.getString("auth_token");

    if (authToken != null) {
      const String baseUrl = "http://10.0.2.2:5255";

      final dio = Dio();
      final Map<String, dynamic> queryJson = {"searchQueries": ""};

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

        var response =
            await dio.get("$baseUrl/api/Issue/GetAllIssueCount?searchQueries=");
        //queryParameters: queryJson);
        //print(response.statusCode);
        //print(response.data);
        if (response.statusCode == 401) {
          isLoggedIn = false;
          sharedPrefs?.remove("auth_token");
        } else {
          isLoggedIn = true;
        }
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

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      title: 'Issue Manager Go Router Config',
      debugShowCheckedModeBanner: false,
      routerConfig: _issueManagerRouterConfig,
    );
  }
}
