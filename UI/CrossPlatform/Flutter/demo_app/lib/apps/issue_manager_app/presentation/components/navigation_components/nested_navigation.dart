import 'package:demo_app/apps/issue_manager_app/presentation/components/navigation_components/navigation_bar_custom.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/navigation_components/navigation_rail_custom.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

// Stateful navigation based on:
// https://github.com/flutter/packages/blob/main/packages/go_router/example/lib/stateful_shell_route.dart
class NestedNavigationCustom extends StatelessWidget {
  const NestedNavigationCustom({
    Key? key,
    required this.navigationShell,
  }) : super(key: key ?? const ValueKey<String>('NestedNavigationCustom'));
  final StatefulNavigationShell navigationShell;

  void _goBranch(int index) {
    navigationShell.goBranch(
      index,
      // A common pattern when using bottom navigation bars is to support
      // navigating to the initial location when tapping the item that is
      // already active. This example demonstrates how to support this behavior,
      // using the initialLocation parameter of goBranch.
      initialLocation: index == navigationShell.currentIndex,
    );
  }

  @override
  Widget build(BuildContext context) {
    return LayoutBuilder(builder: (context, constraints) {
      if (constraints.maxWidth < 450) {
        return NavigationBarCustom(
          body: navigationShell,
          selectedIndex: navigationShell.currentIndex,
          onDestinationSelected: _goBranch,
        );
      } else {
        return NavigationRailCustom(
          body: navigationShell,
          selectedIndex: navigationShell.currentIndex,
          onDestinationSelected: _goBranch,
        );
      }
    });
  }
}
