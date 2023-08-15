part of 'register_bloc.dart';

sealed class RegisterEvent extends Equatable {
  const RegisterEvent();

  @override
  List<Object> get props => [];
}

class OnChangeRegisterEvent extends RegisterEvent {
  final UserModel userModel;
  final String confirmPassword;
  const OnChangeRegisterEvent(
      {required this.userModel, required this.confirmPassword});
}

class OnSubmitRegisterEvent extends RegisterEvent {
  final UserModel userModel;
  final String confirmPassword;
  const OnSubmitRegisterEvent(
      {required this.userModel, required this.confirmPassword});
}

class OnLoginNavigateRegisterEvent extends RegisterEvent {
  final String email;
  final String password;
  const OnLoginNavigateRegisterEvent(
      {required this.email, required this.password});
}
