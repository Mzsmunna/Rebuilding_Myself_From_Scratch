import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/user_list_bloc.dart';

class UserList extends StatefulWidget {
  final userListBloc = UserListBloc();
  UserList({super.key});

  @override
  State<UserList> createState() => _UserListState();
}

class _UserListState extends State<UserList> {
  @override
  void initState() {
    super.initState();
    widget.userListBloc.add(UserListGetUserEvent());
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<UserListBloc, UserListState>(
      bloc: widget.userListBloc,
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
                        //backgroundImage: NetworkImage("${user?.img}"),
                        child: Text("${user?.img}"),
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
