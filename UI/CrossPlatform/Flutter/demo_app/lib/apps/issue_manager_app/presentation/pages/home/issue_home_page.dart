import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/issue_home_bloc.dart';

class IssueHome extends StatefulWidget {
  final issueHomeBloc = IssueHomeBloc();
  IssueHome({super.key});

  @override
  State<IssueHome> createState() => _IssueHomeState();
}

class _IssueHomeState extends State<IssueHome> {
  @override
  void initState() {
    super.initState();
    widget.issueHomeBloc.add(IssueHomeGetUserEvent());
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<IssueHomeBloc, IssueHomeState>(
      bloc: widget.issueHomeBloc,
      listener: (context, state) {
        // TODO: implement listener
      },
      builder: (context, state) {
        return Scaffold(
          backgroundColor: Colors.grey[300],
          body: SafeArea(
            child: ListView.builder(
                itemCount:
                    state.userModels != null ? state.userModels?.length : 0,
                itemBuilder: (context, index) {
                  UserModel? user = state.userModels?[index];
                  return Card(
                    child: ListTile(
                      leading: CircleAvatar(
                        radius: 28,
                        backgroundImage: NetworkImage("${user?.img}"),
                      ),
                      title: Text("${user?.firstName} ${user?.lastName}"),
                      subtitle: Column(
                        children: [
                          Text("${user?.email}"),
                          Text("${user?.designation}"),
                          Text("${user?.department}"),
                          Text("${user?.isActive}"),
                        ],
                      ),
                      trailing: const Icon(Icons.arrow_forward),
                    ),
                  );
                }),
          ),
        );
      },
    );
  }
}
