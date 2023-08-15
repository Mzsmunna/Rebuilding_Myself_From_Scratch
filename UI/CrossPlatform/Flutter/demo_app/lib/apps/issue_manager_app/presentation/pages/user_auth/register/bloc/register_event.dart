part of 'register_bloc.dart';

sealed class RegisterEvent extends Equatable {
  const RegisterEvent();

  @override
  List<Object> get props => [];
}

// ignore: must_be_immutable
class OnChangeRegisterEvent extends RegisterEvent {
  final UserModel userModel;
  final String confirmPassword;
  bool isValidFirstName = false;
  bool isValidLastName = false;
  bool isValidGender = false;
  bool isValidPhone = false;
  bool isValidEmail = false;
  bool isValidPassword = false;
  bool isConfirmPassword = false;
  RegExp get validEmailRegex =>
      RegExp(r"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z]+");
  RegExp get validNameRegex =>
      RegExp(r"^[a-zA-Z](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$");
  RegExp get validPasswordRegex => RegExp(
      r'^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#\><*~]).{8,}/pre>');
  RegExp get validPhoneRegex => RegExp(
      r"(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})");
  //RegExp(r'^[+]{1}(?:[0-9\\-\\(\\)\\/""\\.]\\s?){6, 15}[0-9]{1}$');

  OnChangeRegisterEvent(
      {required this.userModel, required this.confirmPassword}) {
    print(userModel.toJson());
    if (userModel.firstName != "" &&
        !validNameRegex.hasMatch(userModel.firstName!) &&
        userModel.firstName!.length < 3) {
      isValidFirstName = false;
    } else {
      isValidFirstName = true;
    }

    if (userModel.lastName != "" &&
        !validNameRegex.hasMatch(userModel.lastName!) &&
        userModel.lastName!.length < 3) {
      isValidLastName = false;
    } else {
      isValidLastName = true;
    }

    if (userModel.gender != null ||
        userModel.gender != "" ||
        userModel.gender!.toLowerCase() != "gender") {
      isValidGender = false;
    } else {
      isValidGender = true;
    }

    if (userModel.phone != "" && !validPhoneRegex.hasMatch(userModel.phone!)) {
      isValidPhone = false;
    } else {
      isValidPhone = true;
    }

    if (userModel.email != "" && !validEmailRegex.hasMatch(userModel.email!)) {
      isValidEmail = false;
      //validation = "Not a valid email";
    } else {
      isValidEmail = true;
    }

    if (userModel.password != "" &&
        !validPasswordRegex.hasMatch(userModel.password!) &&
        userModel.password!.length < 6) {
      isValidPassword = false;
      //validation = "Not a valid password";
    } else {
      isValidPassword = true;
    }

    if (userModel.password != confirmPassword) {
      isConfirmPassword = false;
      //validation = "Not a valid password";
    } else {
      isConfirmPassword = true;
    }
  }
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
