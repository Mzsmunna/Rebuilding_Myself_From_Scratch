import 'package:flutter/material.dart';
import 'package:demo_app/apps/app_profile.dart';
import 'package:demo_app/apps/app_showcase.dart';
import 'package:go_router/go_router.dart';

class GoRouterConfig extends StatelessWidget {
  const GoRouterConfig({super.key});

  static final GoRouter _routerConfig = GoRouter(
    initialLocation: "/",
    routes: [
      GoRoute(
          path: '/',
          builder: (context, state) => const AppShowcase(),
          routes: [
            GoRoute(
              name: 'Home',
              path: 'Home',
              builder: (context, state) => const AppShowcase(),
            ),
            GoRoute(
              name: 'Profile',
              //path: 'Profile/:username',
              path: 'Profile',
              builder: (context, state) => AppProfile(
                //username: state.pathParameters['username'],
                username: state.uri.queryParameters['username'],
              ),
            ),
          ]),
    ],
  );

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      title: 'Go Router Config',
      debugShowCheckedModeBanner: false,
      routerConfig: _routerConfig,
    );
  }
}
