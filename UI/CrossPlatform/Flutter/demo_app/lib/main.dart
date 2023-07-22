import 'package:demo_app/apps/counter_app/counter_app.dart';
import 'package:demo_app/apps/counter_app_bloc/counter_app_bloc.dart';
import 'package:demo_app/apps/issue_manager_app/issue_manager_app.dart';
import 'package:demo_app/apps/widgets_manager_app/widgets_manager_app.dart';
import 'package:flutter/material.dart';

void main() {
  //runApp(const CounterApp());
  runApp(const CounterAppBloc());
  //runApp(const WidgetsManagerApp());
  //runApp(const IssueManagerApp());
}
