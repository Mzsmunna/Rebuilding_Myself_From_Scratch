part of 'issue_home_bloc.dart';

sealed class IssueHomeEvent extends Equatable {
  const IssueHomeEvent();

  @override
  List<Object> get props => [];
}

class OnIssueHomeTabChangeEvent extends IssueHomeEvent {
  final int tabIndex;
  const OnIssueHomeTabChangeEvent({required this.tabIndex});

  @override
  List<Object> get props => [tabIndex];
}
