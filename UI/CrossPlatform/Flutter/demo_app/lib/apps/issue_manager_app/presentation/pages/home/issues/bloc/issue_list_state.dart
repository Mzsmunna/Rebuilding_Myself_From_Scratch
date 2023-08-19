part of 'issue_list_bloc.dart';

sealed class IssueListState extends Equatable {
  final List<IssueModel>? issueModels;
  const IssueListState({required this.issueModels});

  @override
  List<Object?> get props => [issueModels];
}

final class IssueListInitialState extends IssueListState {
  const IssueListInitialState({required List<IssueModel>? issueModels})
      : super(issueModels: issueModels);

  @override
  List<Object?> get props => [issueModels];
}

final class IssueListLoaded extends IssueListState {
  const IssueListLoaded({required List<IssueModel>? issueModels})
      : super(issueModels: issueModels);

  @override
  List<Object?> get props => [issueModels];
}

final class IssueListLoadError extends IssueListState {
  final String error;
  const IssueListLoadError(
      {required List<IssueModel>? issueModels, required this.error})
      : super(issueModels: issueModels);

  @override
  List<Object?> get props => [issueModels, error];
}
