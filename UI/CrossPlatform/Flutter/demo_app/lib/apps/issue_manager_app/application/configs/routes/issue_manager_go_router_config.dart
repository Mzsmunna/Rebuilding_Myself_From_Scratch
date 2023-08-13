import 'package:demo_app/apps/app_error.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/login/login_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/register/register_page.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class IssueManagerGoRouterConfig extends StatelessWidget {
  final bool isConditional;
  late final GoRouter _issueManagerRouterConfig;
  IssueManagerGoRouterConfig({super.key, required this.isConditional}) {
    _issueManagerRouterConfig = GoRouter(
      initialLocation: "/IssueManager",
      errorBuilder: (context, state) => const AppError(),
      // redirect: (context, state) {
      //   if (isConditional) {
      //     return '/Profile';
      //   } else {
      //     return '/';
      //     //return '/Oops';
      //   }
      // },
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
