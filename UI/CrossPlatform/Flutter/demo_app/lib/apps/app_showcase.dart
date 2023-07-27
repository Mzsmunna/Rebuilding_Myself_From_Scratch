import 'package:demo_app/apps/counter_app/pages/counter_app.dart';
import 'package:demo_app/apps/counter_app_bloc/pages/counter_app_bloc.dart';
import 'package:demo_app/apps/flutter_widgets_overview_app/pages/flutter_widgets_overview_app.dart';
import 'package:demo_app/apps/issue_manager_app/pages/issue_manager_app.dart';
import 'package:demo_app/common/configs/themes/default_app_theme.dart';
import 'package:demo_app/common/widgets/card_showcase_widget.dart';
import 'package:flutter/material.dart';
//import '../../widgets/access_widgets.dart';

class AppShowcase extends StatelessWidget {
  const AppShowcase({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'App Showcase',
      debugShowCheckedModeBanner: false,
      theme: DefaultAppTheme.materialThree,
      home: Scaffold(
        appBar: AppBar(
          title: const Text("App Showcase"),
        ),
        body: SingleChildScrollView(
          child: Column(
            children: const [
              CardShowcaseWidget(
                title: "Counter App",
                description: "default flutter app",
                image: "lib/assets/images/counter_app.png",
                app: CounterApp(),
              ),
              CardShowcaseWidget(
                title: "Counter Bloc App",
                description: "a simple app with bloc pattern",
                image: "lib/assets/images/counter_bloc_app.png",
                app: CounterAppBloc(),
              ),
              CardShowcaseWidget(
                title: "Flutter Widgets App",
                description: "get to know about all available flutter widgets",
                image: "lib/assets/images/flutter_widgets_app.png",
                app: FlutterwidgetsApp(),
              ),
              CardShowcaseWidget(
                title: "Issue Manager App",
                description: "upcoming app",
                image: "lib/assets/images/issues_app.png",
                app: IssueManagerApp(),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
