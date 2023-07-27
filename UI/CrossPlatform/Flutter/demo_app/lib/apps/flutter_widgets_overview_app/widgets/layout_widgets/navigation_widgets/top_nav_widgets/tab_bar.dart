//! TabBar

import 'package:flutter/material.dart';

class TabBarWidget extends StatelessWidget {
  const TabBarWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
      length: 3,
      child: Scaffold(
        appBar: AppBar(
          bottom: const TabBar(
            tabs: [
              Tab(
                icon: Icon(Icons.home),
              ),
              Tab(
                icon: Icon(Icons.settings),
              ),
              Tab(
                icon: Icon(Icons.person),
              ),
            ],
          ),
          title: const Text('Flutter Mapp'),
        ),
        body: const TabBarView(
          children: [
            Icon(Icons.home),
            Icon(Icons.settings),
            Icon(Icons.person),
          ],
        ),
      ),
    );
  }
}
