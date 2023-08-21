import 'package:demo_app/apps/app_error.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/auth_service.dart';
//import 'package:demo_app/apps/issue_manager_app/presentation/components/navigation_components/nested_navigation.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issue_home_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/user_details/user_details_page.dart';
//import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issue_home_page.dart';
//import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issues/issue_list_page.dart';
//import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/users/user_list_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/login/login_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/register/register_page.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

// private navigators
final _rootNavigatorKey = GlobalKey<NavigatorState>(debugLabel: 'IssueManager');
//final _shellNavigatorUsersKey = GlobalKey<NavigatorState>(debugLabel: 'Users');
// final _shellNavigatorIssuesKey =
//     GlobalKey<NavigatorState>(debugLabel: 'Issues');

// ignore: must_be_immutable
class IssueManagerGoRouterConfig extends StatelessWidget {
  final bool isConditional;
  bool isLoggedIn = false;
  late final AuthService _authService;
  late final GoRouter _issueManagerRouterConfig;
  IssueManagerGoRouterConfig({super.key, required this.isConditional}) {
    _authService = AuthService();
    _issueManagerRouterConfig = GoRouter(
      initialLocation: "/IssueManager",
      navigatorKey: _rootNavigatorKey,
      errorBuilder: (context, state) => const AppError(),
      //redirect: (context, state) => redirect(context, state),
      // redirect: (context, state) {
      //   if (isConditional) {
      //     var sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
      //     var authToken = sharedPrefs?.getString("auth_token");
      //     if (authToken != null) {
      //       //Map<String, dynamic> decodedToken = JwtDecoder.decode(authToken);
      //       bool hasExpired = JwtDecoder.isExpired(authToken);
      //       if (hasExpired) {
      //         isLoggedIn = false;
      //       } else {
      //         isLoggedIn = true;
      //       }
      //     }
      //     if (isLoggedIn) {
      //       return '/IssueManager/IssueHome';
      //     } else {
      //       return '/IssueManager';
      //     }
      //   } else {
      //     return '/IssueManager';
      //   }
      // },
      routes: [
        GoRoute(
          path: '/IssueManager',
          redirect: (context, state) => redirect(context, state),
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
              builder: (context, state) => IssueHome(),
              routes: [
                GoRoute(
                  name: 'UsersDetails',
                  path: 'UsersDetails',
                  builder: (context, state) {
                    UserModel user =
                        state.extra as UserModel; // -> casting is important
                    return UserDetailsPage(userModel: user);
                  },
                ),
              ],
            ),
            // StatefulShellRoute.indexedStack(
            //   parentNavigatorKey: _rootNavigatorKey,
            //   builder: (context, state, navigationShell) {
            //     return NestedNavigationCustom(navigationShell: navigationShell);
            //   },
            //   branches: [
            //     StatefulShellBranch(
            //       navigatorKey: _shellNavigatorUsersKey,
            //       routes: [
            //         GoRoute(
            //           path: 'IssueHome',
            //           pageBuilder: (context, state) => NoTransitionPage(
            //             child: UserList(),
            //           ),
            //           // routes: [
            //           //   GoRoute(
            //           //     path: 'details',
            //           //     builder: (context, state) =>
            //           //         const UserDetailsScreen(label: 'User Details'),
            //           //   ),
            //           // ],
            //         ),
            //       ],
            //     ),
            //     StatefulShellBranch(
            //       navigatorKey: _shellNavigatorIssuesKey,
            //       routes: [
            //         // Shopping Cart
            //         GoRoute(
            //           path: 'Issues',
            //           pageBuilder: (context, state) => NoTransitionPage(
            //             child: IssueList(),
            //           ),
            //           // routes: [
            //           //   GoRoute(
            //           //     path: 'details',
            //           //     builder: (context, state) =>
            //           //         const IssueDetailsScreen(label: 'Issue Details'),
            //           //   ),
            //           // ],
            //         ),
            //       ],
            //     ),
            //   ],
            // ),
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

  String redirect(BuildContext context, GoRouterState state) {
    isLoggedIn = _authService.isAuthenticated(isConditional);
    if (isLoggedIn) {
      if (state.fullPath != null && state.fullPath!.contains("IssueHome")) {
        return state.fullPath!;
      } else {
        return '/IssueManager/IssueHome';
      }
    } else {
      if (state.fullPath != null && !state.fullPath!.contains("IssueHome")) {
        return state.fullPath!;
      } else {
        return '/IssueManager';
      }
    }
  }
}
