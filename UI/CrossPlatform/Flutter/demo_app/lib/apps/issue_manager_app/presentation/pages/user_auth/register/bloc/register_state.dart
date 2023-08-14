// ignore_for_file: must_be_immutable

part of 'register_bloc.dart';

sealed class RegisterState extends Equatable {
  UserModel userModel;
  RegisterState({required this.userModel});

  @override
  List<Object> get props => [];
}

class InitialRegisterState extends RegisterState {
  InitialRegisterState()
      : super(
          userModel: UserModel(
            id: "",
            firstName: "",
            lastName: "",
            gender: "",
            age: 0,
            phone: "",
            birthDate: null,
            address: "",
            department: "",
            designation: "",
            position: "",
            img: "",
            email: "",
            password: "",
            //passwordHash: [],
            //passwordSalt: [],
            tokenCreated: null,
            tokenExpires: null,
            refreshToken: "",
            role: "",
            isActive: true,
            createdOn: DateTime.now(),
            modifiedOn: null,
            createdBy: "",
            modifiedBy: "",
          ),
        );
}

class OnChangeRegisterState extends RegisterState {
  OnChangeRegisterState({required UserModel userModel})
      : super(userModel: userModel);
}

class OnValidRegisterState extends RegisterState {
  OnValidRegisterState({required UserModel userModel})
      : super(userModel: userModel);
}

class OnSubmitRegisterState extends RegisterState {
  OnSubmitRegisterState({required UserModel userModel})
      : super(userModel: userModel);
}

class OnErrorRegisterState extends RegisterState {
  OnErrorRegisterState({required UserModel userModel})
      : super(userModel: userModel);
}

class OnSuccessRegisterState extends RegisterState {
  OnSuccessRegisterState({required UserModel userModel})
      : super(userModel: userModel);
}

class OnLoginNavigateLoginState extends RegisterState {
  OnLoginNavigateLoginState({required UserModel userModel})
      : super(userModel: userModel);
}
