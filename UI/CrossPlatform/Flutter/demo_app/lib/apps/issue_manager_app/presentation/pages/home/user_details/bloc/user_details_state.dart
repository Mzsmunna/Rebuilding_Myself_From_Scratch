part of 'user_details_bloc.dart';

sealed class UserDetailsState extends Equatable {
  const UserDetailsState();

  @override
  List<Object> get props => [];
}

class InitialUserDetailsState extends UserDetailsState {
  const InitialUserDetailsState();
}

class InvalidUserDetailsState extends UserDetailsState {
  final UserModel userModel;
  final String confirmPassword;
  final bool isValidFirstName;
  final bool isValidLastName;
  final bool isValidGender;
  final bool isValidPhone;
  final bool isValidEmail;
  final bool isValidPassword;
  final bool isConfirmPassword;
  const InvalidUserDetailsState(
      {required this.userModel,
      required this.confirmPassword,
      required this.isValidFirstName,
      required this.isValidLastName,
      required this.isValidGender,
      required this.isValidPhone,
      required this.isValidEmail,
      required this.isValidPassword,
      required this.isConfirmPassword});

  @override
  List<Object> get props => [
        userModel,
        confirmPassword,
        isValidFirstName,
        isValidLastName,
        isValidGender,
        isValidPhone,
        isValidEmail,
        isValidPassword,
        isConfirmPassword
      ];
}

class ValidUserDetailsState extends UserDetailsState {
  const ValidUserDetailsState();
}

class SubmitUserDetailsState extends UserDetailsState {
  final UserModel userModel;
  final String confirmPassword;
  const SubmitUserDetailsState(
      {required this.userModel, required this.confirmPassword});

  @override
  List<Object> get props => [userModel, confirmPassword];
}

class ErrorUserDetailsState extends UserDetailsState {
  final String error;
  const ErrorUserDetailsState({required this.error});

  @override
  List<Object> get props => [error];
}

class SuccessUserDetailsState extends UserDetailsState {
  final UserModel userModel;
  const SuccessUserDetailsState({required this.userModel});

  @override
  List<Object> get props => [userModel];
}

class LoginNavigateUserDetailsState extends UserDetailsState {
  final String email;
  final String password;
  const LoginNavigateUserDetailsState(
      {required this.email, required this.password});

  @override
  List<Object> get props => [email, password];
}
