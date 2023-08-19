part of 'issue_list_bloc.dart';

sealed class IssueListEvent extends Equatable {
  const IssueListEvent();

  @override
  List<Object> get props => [];
}

class GetIssueListEvent extends IssueListEvent {}
