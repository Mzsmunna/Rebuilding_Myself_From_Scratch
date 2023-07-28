import 'package:demo_app/apps/counter_app/pages/counter_app.dart';
import 'package:demo_app/apps/counter_app_bloc/pages/counter_app_bloc.dart';
import 'package:demo_app/apps/flutter_widgets_overview_app/pages/flutter_widgets_overview_app.dart';
import 'package:demo_app/apps/issue_manager_app/pages/issue_manager_app.dart';
import 'package:demo_app/common/widgets/gesture_detector_cards_column_widget.dart';
import 'package:flutter/material.dart';

class ScrollingGestureDetectorCardsColumnWidget extends StatelessWidget {
  const ScrollingGestureDetectorCardsColumnWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: const [
          GestureDetectorCardsColumnWidget(
            title: "Counter App",
            description: "default flutter app",
            image: "lib/assets/images/counter_app.png",
            app: CounterApp(),
          ),
          GestureDetectorCardsColumnWidget(
            title: "Counter Bloc App",
            description: "a simple app with bloc pattern",
            image: "lib/assets/images/counter_bloc_app.png",
            app: CounterAppBloc(),
          ),
          GestureDetectorCardsColumnWidget(
            title: "Flutter Widgets App",
            description: "get to know about all available flutter widgets",
            image: "lib/assets/images/flutter_widgets_app.png",
            app: FlutterwidgetsApp(),
          ),
          GestureDetectorCardsColumnWidget(
            title: "Issue Manager App",
            description: "upcoming app",
            image: "lib/assets/images/issues_app.png",
            app: IssueManagerApp(),
          ),
        ],
      ),
    );
  }
}
