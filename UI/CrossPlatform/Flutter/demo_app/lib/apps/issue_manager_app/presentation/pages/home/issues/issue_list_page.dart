import 'package:demo_app/apps/issue_manager_app/domain/entities/issue_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/issue_list_bloc.dart';

class IssueList extends StatefulWidget {
  final issueListBloc = IssueListBloc();
  IssueList({super.key});

  @override
  State<IssueList> createState() => _IssueListState();
}

class _IssueListState extends State<IssueList> {
  @override
  void initState() {
    super.initState();
    widget.issueListBloc.add(GetIssueListEvent());
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<IssueListBloc, IssueListState>(
      bloc: widget.issueListBloc,
      listener: (context, state) {
        // TODO: implement listener
      },
      builder: (context, state) {
        return ListView.builder(
          itemCount: state.issueModels != null ? state.issueModels?.length : 0,
          itemBuilder: (context, index) {
            IssueModel? issue = state.issueModels?[index];
            return Card(
              child: ListTile(
                title: Text("${issue?.title}"),
                subtitle: Column(
                  children: [
                    Text("${issue?.type}"),
                    Text("${issue?.description}"),
                    Text("${issue?.status}"),
                    Text("${issue?.isActive}"),
                  ],
                ),
                trailing: const Icon(Icons.arrow_forward),
              ),
            );
          },
        );
      },
    );
  }
}
