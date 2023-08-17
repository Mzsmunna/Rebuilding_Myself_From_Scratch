part of 'issue_home_bloc.dart';

sealed class IssueHomeEvent extends Equatable {
  const IssueHomeEvent();

  @override
  List<Object> get props => [];
}

class IssueHomeGetUserEvent extends IssueHomeEvent {}
