// ignore_for_file: unused_import

import 'package:demo_app/apps/app_showcase.dart';
import 'package:demo_app/apps/counter_app/pages/counter_app.dart';
import 'package:demo_app/apps/counter_app_bloc/pages/counter_app_bloc.dart';
import 'package:demo_app/apps/issue_manager_app/pages/issue_manager_app.dart';
import 'package:demo_app/apps/flutter_widgets_overview_app/pages/flutter_widgets_overview_app.dart';
import 'package:demo_app/common/configs/routes/go_router_config.dart';
import 'package:flutter/material.dart';

void main() {
  //runApp(const CounterApp());
  //runApp(const CounterAppBloc());
  //runApp(const FlutterwidgetsApp());
  //runApp(const IssueManagerApp());
  //runApp(const AppShowcase());
  runApp(GoRouterConfig(
    isConditional: false,
  ));
}
