import 'package:flutter/material.dart';

ValueNotifier<bool> isAppDarkMode = ValueNotifier(false);

class AppDefaultDrawer extends StatefulWidget {
  const AppDefaultDrawer({super.key});

  @override
  State<AppDefaultDrawer> createState() => _AppDefaultDrawerState();
}

class _AppDefaultDrawerState extends State<AppDefaultDrawer> {
  @override
  Widget build(BuildContext context) {
    return ValueListenableBuilder(
      valueListenable: isAppDarkMode,
      builder: (context, isDarkMode, child) {
        return Container(
          width: 288,
          height: double.infinity,
          color: isDarkMode ? Colors.black : Colors.white,
          child: SafeArea(
            child: Column(
              children: [
                const DrawerHeader(
                  decoration: BoxDecoration(color: Colors.blueGrey),
                  child: ListTile(
                    title: Text(
                      'Mzs Apps',
                      style: TextStyle(
                        color: Colors.white,
                        fontSize: 40,
                      ),
                    ),
                  ),
                ),
                SwitchListTile(
                  value: isDarkMode,
                  title: const Text(
                    'Dark Mode',
                  ),
                  onChanged: (bool value) {
                    isAppDarkMode.value = !isAppDarkMode.value;
                  },
                  secondary: const Icon(Icons.dark_mode),
                ),
                const ListTile(
                  leading: Icon(Icons.settings),
                  title: Text(
                    'Settings',
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }
}
