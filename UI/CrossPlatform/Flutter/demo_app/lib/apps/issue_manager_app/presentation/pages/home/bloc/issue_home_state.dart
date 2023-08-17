part of 'issue_home_bloc.dart';

sealed class IssueHomeState extends Equatable {
  final List<UserModel>? userModels;
  const IssueHomeState({required this.userModels});

  @override
  List<Object?> get props => [userModels];
}

final class IssueHomeInitialState extends IssueHomeState {
  const IssueHomeInitialState({required List<UserModel>? userModels})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels];
}

final class IssueHomeUserLoaded extends IssueHomeState {
  const IssueHomeUserLoaded({required List<UserModel>? userModels})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels];
}

final class IssueHomeUserLoadError extends IssueHomeState {
  final String error;
  const IssueHomeUserLoadError(
      {required List<UserModel>? userModels, required this.error})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels, error];
}
