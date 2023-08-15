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
  final String email;
  final String password;
  final bool isValidEmail;
  final bool isValidPassword;

  const InvalidLoginState(
      {required this.email,
      required this.password,
      required this.isValidEmail,
      required this.isValidPassword});

  InvalidLoginState copyWith(
      {String? email,
      String? password,
      String? validation,
      bool? isValidEmail,
      bool? isValidPassword}) {
    return InvalidLoginState(
        email: email ?? this.email,
        password: password ?? this.password,
        isValidEmail: isValidEmail ?? this.isValidEmail,
        isValidPassword: isValidPassword ?? this.isValidPassword);
  }

  @override
  List<Object> get props => [email, password, isValidEmail, isValidPassword];
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
