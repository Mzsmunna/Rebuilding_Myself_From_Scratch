import 'package:demo_app/apps/app_error.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issue_home_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/login/login_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/register/register_page.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:jwt_decoder/jwt_decoder.dart';

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
          var sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
          var authToken = sharedPrefs?.getString("auth_token");
          if (authToken != null) {
            //Map<String, dynamic> decodedToken = JwtDecoder.decode(authToken);
            bool hasExpired = JwtDecoder.isExpired(authToken);
            if (hasExpired) {
              isLoggedIn = false;
            } else {
              isLoggedIn = true;
            }
          }
          if (isLoggedIn) {
            return '/IssueManager/IssueHome';
          } else {
            return '/IssueManager';
          }
        } else {
          return '/IssueManager';
        }
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

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      title: 'Issue Manager Go Router Config',
      debugShowCheckedModeBanner: false,
      routerConfig: _issueManagerRouterConfig,
    );
  }
}
