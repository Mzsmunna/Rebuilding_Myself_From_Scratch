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
              path: 'Home',
              builder: (context, state) => const AppShowcase(),
            ),
            GoRoute(
              path: 'Profile/:username',
              builder: (context, state) => AppProfile(
                username: state.pathParameters['username'],
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
