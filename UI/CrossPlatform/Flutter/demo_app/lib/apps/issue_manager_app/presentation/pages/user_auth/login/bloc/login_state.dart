part of 'login_bloc.dart';

sealed class LoginState extends Equatable {
  const LoginState();

  @override
  List<Object> get props => [];
}

class InitialLoginState extends LoginState {
  const InitialLoginState();
}

class InvalidLoginState extends LoginState {
  final String validation;
  const InvalidLoginState({required this.validation});
}

class ValidLoginState extends LoginState {
  const ValidLoginState();
}

class SubmitLoginState extends LoginState {
  final String email;
  final String password;
  const SubmitLoginState({required this.email, required this.password});
}

class ErrorLoginState extends LoginState {
  final String error;
  const ErrorLoginState({required this.error});
}

class SuccessLoginState extends LoginState {
  final String token;
  const SuccessLoginState({required this.token});
}

class RegisterNavigateLoginState extends LoginState {
  final String email;
  final String password;
  const RegisterNavigateLoginState(
      {required this.email, required this.password});
}
