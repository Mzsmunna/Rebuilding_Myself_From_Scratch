part of 'issue_home_bloc.dart';

sealed class IssueHomeState extends Equatable {
  final int tabIndex;
  const IssueHomeState({required this.tabIndex});

  @override
  List<Object> get props => [tabIndex];
}

final class IssueHomeInitialState extends IssueHomeState {
  const IssueHomeInitialState({required int tabIndex})
      : super(tabIndex: tabIndex);

  @override
  List<Object> get props => [tabIndex];
}

final class IssueHomeTabChangedState extends IssueHomeState {
  const IssueHomeTabChangedState({required int tabIndex})
      : super(tabIndex: tabIndex);

  @override
  List<Object> get props => [tabIndex];
}
