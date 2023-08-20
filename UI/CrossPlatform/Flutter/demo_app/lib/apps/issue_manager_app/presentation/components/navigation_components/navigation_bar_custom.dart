import 'package:flutter/material.dart';

class NavigationBarCustom extends StatelessWidget {
  const NavigationBarCustom({
    super.key,
    required this.body,
    required this.selectedIndex,
    required this.onDestinationSelected,
  });
  final Widget body;
  final int selectedIndex;
  final ValueChanged<int> onDestinationSelected;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: body,
      bottomNavigationBar: NavigationBar(
        selectedIndex: selectedIndex,
        destinations: const [
          NavigationDestination(label: 'Users', icon: Icon(Icons.people_alt)),
          NavigationDestination(label: 'Issues', icon: Icon(Icons.task_alt)),
        ],
        onDestinationSelected: onDestinationSelected,
      ),
    );
  }
}
