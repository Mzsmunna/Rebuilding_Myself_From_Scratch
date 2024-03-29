import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class AppTopBar {
  static AppBar getDefaultAppBar(String title, BuildContext context, Widget app,
      {bool useGoRouer = false, String goRouterPath = ""}) {
    return AppBar(
      title: Text(title),
      leading: IconButton(
        onPressed: () {
          if (useGoRouer) {
            GoRouter.of(context).go(goRouterPath);
          } else {
            Navigator.pop(context);
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) {
                  return app;
                },
              ),
            );
          }
        },
        icon: const Icon(Icons.dangerous),
      ),
    );
  }

  static AppBar getWidgetAppBar(
      String title, BuildContext context, Widget app) {
    return AppBar(
      title: Text(title),
      leading: IconButton(
        onPressed: () {
          Navigator.pop(context);
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) {
                return app;
              },
            ),
          );
        },
        icon: const Icon(Icons.dangerous),
      ),
      actions: <Widget>[
        IconButton(
          icon: const Icon(Icons.list_alt),
          onPressed: () {},
        ),
        IconButton(
          icon: const Icon(Icons.library_books_outlined),
          onPressed: () {},
        ),
        IconButton(
          icon: const Icon(Icons.grid_on),
          onPressed: () {},
        ),
      ],
    );
  }
}
