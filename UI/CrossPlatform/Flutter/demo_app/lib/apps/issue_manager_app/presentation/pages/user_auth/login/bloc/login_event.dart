part of 'login_bloc.dart';

sealed class LoginEvent extends Equatable {
  const LoginEvent();

  @override
  List<Object> get props => [];
}

class OnChangeLoginEvent extends LoginEvent {
  final String email;
  final String password;

  const OnChangeLoginEvent({required this.email, required this.password});
}

class OnSubmitLoginEvent extends LoginEvent {
  final String email;
  final String password;

  const OnSubmitLoginEvent({required this.email, required this.password});
}

class OnRegisterNavigateLoginEvent extends LoginEvent {
  final String email;
  final String password;

  const OnRegisterNavigateLoginEvent(
      {required this.email, required this.password});
}
