import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/auth_service.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:equatable/equatable.dart';

part 'register_event.dart';
part 'register_state.dart';

class RegisterBloc extends Bloc<RegisterEvent, RegisterState> {
  RegisterBloc() : super(const InitialRegisterState()) {
    on<OnChangeRegisterEvent>(onChangeRegisterEvent);
    on<OnSubmitRegisterEvent>(onSubmitRegisterEvent);
    on<OnLoginNavigateRegisterEvent>(onLoginNavigateRegisterEvent);

    // on<InitialEvent>((event, emit) {
    //   emit(InitialState());
    // });

    // on<IncreaseEvent>((event, emit) {
    //   emit(IncreaseState(count: state.count + 1));
    // });

    // on<DecreaseEvent>((event, emit) {
    //   emit(DecreaseState(count: state.count - 1));
    // });
  }

  void onChangeRegisterEvent(
      OnChangeRegisterEvent event, Emitter<RegisterState> emit) {
    if (event.userModel.firstName == "" &&
        event.userModel.lastName == "" &&
        event.userModel.gender == "" &&
        event.userModel.phone == "" &&
        event.userModel.email == "" &&
        event.userModel.password == "" &&
        event.confirmPassword == "") {
      //print("InitialRegisterState");
      emit(const InitialRegisterState());
    } else if (!event.isValidFirstName ||
        !event.isValidLastName ||
        !event.isValidGender ||
        !event.isValidPhone ||
        !event.isValidEmail ||
        !event.isValidPassword ||
        !event.isConfirmPassword) {
      //print("Not a valid email");
      emit(InvalidRegisterState(
        userModel: event.userModel,
        confirmPassword: event.confirmPassword,
        isValidFirstName: event.isValidFirstName,
        isValidLastName: event.isValidLastName,
        isValidGender: event.isValidGender,
        isValidPhone: event.isValidPhone,
        isValidEmail: event.isValidEmail,
        isValidPassword: event.isValidPassword,
        isConfirmPassword: event.isConfirmPassword,
      ));
    } else {
      //print("ValidRegisterState");
      emit(const ValidRegisterState());
    }
  }

  void onSubmitRegisterEvent(
      OnSubmitRegisterEvent event, Emitter<RegisterState> emit) async {
    emit(SubmitRegisterState(
        userModel: event.userModel, confirmPassword: event.confirmPassword));

    try {
      var authService = AuthService();
      var response = await authService.doRegister(event.userModel);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        var authToken = response.data.toString();
        var sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
        //sharedPrefs?.remove("auth_token");
        sharedPrefs?.setString("auth_token", authToken);
        emit(SuccessRegisterState(token: authToken));
      } else {
        emit(ErrorRegisterState(
            error: response.statusMessage ??
                "Unable to register! Please try again"));
      }
    } on DioException catch (ex) {
      //print(ex);
      emit(ErrorRegisterState(
          error: ex.message ??
              "Something went wrong while creating account! Please try again"));
    } finally {}
  }

  void onLoginNavigateRegisterEvent(
      OnLoginNavigateRegisterEvent event, Emitter<RegisterState> emit) {
    emit(LoginNavigateRegisterState(
        email: event.email, password: event.password));
  }
}
