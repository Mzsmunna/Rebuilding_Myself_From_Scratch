//import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/issues/issue_list_page.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/users/user_list_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/issue_home_bloc.dart';

class IssueHome extends StatefulWidget {
  final List<BottomNavigationBarItem> bottomNavItems =
      const <BottomNavigationBarItem>[
    BottomNavigationBarItem(
      icon: Icon(Icons.people_alt),
      label: 'Users',
    ),
    BottomNavigationBarItem(
      icon: Icon(Icons.task_alt),
      label: 'Issues',
    ),
  ];

  final List<Widget> bottomNavScreen = <Widget>[
    UserList(),
    IssueList(),
  ];
  final issueHomeBloc = IssueHomeBloc();
  IssueHome({super.key});

  @override
  State<IssueHome> createState() => _IssueHomeState();
}

class _IssueHomeState extends State<IssueHome> {
  @override
  void initState() {
    super.initState();
    //widget.issueHomeBloc.add(const OnIssueHomeTabChangeEvent(tabIndex: 0));
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<IssueHomeBloc, IssueHomeState>(
      bloc: widget.issueHomeBloc,
      listener: (context, state) {},
      builder: (context, state) {
        return Scaffold(
          backgroundColor: Colors.grey[300],
          body: SafeArea(
            child: widget.bottomNavScreen.elementAt(state.tabIndex),
          ),
          bottomNavigationBar: BottomNavigationBar(
            items: widget.bottomNavItems,
            currentIndex: state.tabIndex,
            selectedItemColor: Theme.of(context).colorScheme.primary,
            unselectedItemColor: Colors.grey,
            onTap: (index) {
              // BlocProvider.of<IssueHomeBloc>(context)
              //     .add(OnIssueHomeTabChangeEvent(tabIndex: index));
              widget.issueHomeBloc
                  .add(OnIssueHomeTabChangeEvent(tabIndex: index));
            },
          ),
        );
      },
    );
  }
}
