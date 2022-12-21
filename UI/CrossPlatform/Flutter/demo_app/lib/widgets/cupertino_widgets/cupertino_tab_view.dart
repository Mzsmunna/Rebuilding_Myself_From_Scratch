//!CupertinoTabView

import 'package:flutter/cupertino.dart';

class CupertinoTabViewWidget extends StatefulWidget {
  const CupertinoTabViewWidget({Key? key}) : super(key: key);

  @override
  State<CupertinoTabViewWidget> createState() => _CupertinoTabViewWidgetState();
}

class _CupertinoTabViewWidgetState extends State<CupertinoTabViewWidget> {
  @override
  Widget build(BuildContext context) {
    return CupertinoTabScaffold(
      tabBar: CupertinoTabBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(CupertinoIcons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(CupertinoIcons.settings),
            label: 'Settings',
          ),
        ],
      ),
      tabBuilder: (BuildContext context, int index) {
        return CupertinoTabView(
          builder: (BuildContext context) {
            return Center(
              child: Icon(
                index == 0 ? CupertinoIcons.home : CupertinoIcons.settings,
              ),
            );
          },
        );
      },
    );
  }
}
