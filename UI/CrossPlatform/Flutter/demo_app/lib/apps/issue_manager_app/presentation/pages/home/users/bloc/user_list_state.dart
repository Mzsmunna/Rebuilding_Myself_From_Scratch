part of 'user_list_bloc.dart';

sealed class UserListState extends Equatable {
  final List<UserModel>? userModels;
  const UserListState({required this.userModels});

  @override
  List<Object?> get props => [userModels];
}

final class UserListInitialState extends UserListState {
  const UserListInitialState({required List<UserModel>? userModels})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels];
}

final class UserListUserLoaded extends UserListState {
  const UserListUserLoaded({required List<UserModel>? userModels})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels];
}

final class UserListUserLoadError extends UserListState {
  final String error;
  const UserListUserLoadError(
      {required List<UserModel>? userModels, required this.error})
      : super(userModels: userModels);

  @override
  List<Object?> get props => [userModels, error];
}
