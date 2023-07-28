import 'package:flutter/material.dart';
import 'package:demo_app/apps/app_profile.dart';
import 'package:demo_app/apps/app_showcase.dart';
import 'package:go_router/go_router.dart';

class GoRouterConfig extends StatelessWidget {
  final bool isConditional;
  late final GoRouter _routerConfig;
  GoRouterConfig({super.key, required this.isConditional}) {
    _routerConfig = GoRouter(
      initialLocation: "/",
      routes: [
        GoRoute(
            path: '/',
            builder: (context, state) => const AppShowcase(),
            // redirect: (context, state) {
            //   if (isConditional) {
            //     return '/Profile';
            //   } else {
            //     return '/';
            //   }
            // },
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
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      title: 'Go Router Config',
      debugShowCheckedModeBanner: false,
      routerConfig: _routerConfig,
    );
  }
}
