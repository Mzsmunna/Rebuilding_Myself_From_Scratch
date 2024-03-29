part of 'register_bloc.dart';

sealed class RegisterState extends Equatable {
  const RegisterState();

  @override
  List<Object> get props => [];
}

class InitialRegisterState extends RegisterState {
  const InitialRegisterState();
}

class InvalidRegisterState extends RegisterState {
  final UserModel userModel;
  final String confirmPassword;
  final bool isValidFirstName;
  final bool isValidLastName;
  final bool isValidGender;
  final bool isValidPhone;
  final bool isValidEmail;
  final bool isValidPassword;
  final bool isConfirmPassword;
  const InvalidRegisterState(
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

class ValidRegisterState extends RegisterState {
  const ValidRegisterState();
}

class SubmitRegisterState extends RegisterState {
  final UserModel userModel;
  final String confirmPassword;
  const SubmitRegisterState(
      {required this.userModel, required this.confirmPassword});

  @override
  List<Object> get props => [userModel, confirmPassword];
}

class ErrorRegisterState extends RegisterState {
  final String error;
  const ErrorRegisterState({required this.error});

  @override
  List<Object> get props => [error];
}

class SuccessRegisterState extends RegisterState {
  final String token;
  const SuccessRegisterState({required this.token});

  @override
  List<Object> get props => [token];
}

class LoginNavigateRegisterState extends RegisterState {
  final String email;
  final String password;
  const LoginNavigateRegisterState(
      {required this.email, required this.password});

  @override
  List<Object> get props => [email, password];
}
