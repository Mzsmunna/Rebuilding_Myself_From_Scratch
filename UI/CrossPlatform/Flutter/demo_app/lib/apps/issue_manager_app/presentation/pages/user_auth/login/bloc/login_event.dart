part of 'login_bloc.dart';

sealed class LoginEvent extends Equatable {
  const LoginEvent();

  @override
  List<Object> get props => [];
}

// ignore: must_be_immutable
class OnChangeLoginEvent extends LoginEvent {
  final String email;
  final String password;
  bool isValidEmail = false;
  bool isValidPassword = false;
  RegExp get validEmailRegex =>
      RegExp(r"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z]+");
  RegExp get validPasswordRegex => RegExp(
      r'^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#\><*~]).{8,}/pre>');

  OnChangeLoginEvent({required this.email, required this.password}) {
    if (email == "" && password == "") {
      isValidEmail = false;
      isValidPassword = false;
      //validation = "Both email & password is required";
    }

    if (email != "" && !validEmailRegex.hasMatch(email)) {
      isValidEmail = false;
      //validation = "Not a valid email";
    } else {
      isValidEmail = true;
    }

    if (password != "" &&
        !validPasswordRegex.hasMatch(password) &&
        password.length < 6) {
      isValidPassword = false;
      //validation = "Not a valid password";
    } else {
      isValidPassword = true;
    }
  }
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
