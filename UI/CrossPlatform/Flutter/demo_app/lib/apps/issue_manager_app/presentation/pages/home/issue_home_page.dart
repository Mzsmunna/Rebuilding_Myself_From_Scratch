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
      listener: (context, state) {
        // TODO: implement listener
      },
      builder: (context, state) {
        return Scaffold(
          backgroundColor: Colors.grey[300],
          body: SafeArea(
            child: ListView.builder(
                itemCount: 10,
                itemBuilder: (context, index) => const Card(
                      child: ListTile(
                        leading: CircleAvatar(
                          radius: 28,
                          backgroundImage: NetworkImage("url"),
                        ),
                        title: Text('username'),
                        subtitle: Column(
                          children: [
                            Text("email"),
                            Text("designation"),
                            Text("department"),
                            Text("status"),
                          ],
                        ),
                        trailing: Icon(Icons.arrow_forward),
                      ),
                    )),
          ),
        );
      },
    );
  }
}
