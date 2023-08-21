import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/user_service.dart';
import 'package:dio/dio.dart';
import 'package:equatable/equatable.dart';

part 'user_details_event.dart';
part 'user_details_state.dart';

class UserDetailsBloc extends Bloc<UserDetailsEvent, UserDetailsState> {
  UserDetailsBloc() : super(const InitialUserDetailsState()) {
    on<OnChangeUserDetailsEvent>(onChangeUserDetailsEvent);
    on<OnSubmitUserDetailsEvent>(onSubmitUserDetailsEvent);
    on<OnLoginNavigateUserDetailsEvent>(onLoginNavigateUserDetailsEvent);

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

  void onChangeUserDetailsEvent(
      OnChangeUserDetailsEvent event, Emitter<UserDetailsState> emit) {
    if (event.userModel.firstName == "" &&
        event.userModel.lastName == "" &&
        event.userModel.gender == "" &&
        event.userModel.phone == "" &&
        event.userModel.email == "" &&
        event.userModel.password == "" &&
        event.confirmPassword == "") {
      //print("InitialUserDetailsState");
      emit(const InitialUserDetailsState());
    } else if (!event.isValidFirstName ||
        !event.isValidLastName ||
        !event.isValidGender ||
        !event.isValidPhone ||
        !event.isValidEmail ||
        !event.isValidPassword ||
        !event.isConfirmPassword) {
      //print("Not a valid email");
      emit(InvalidUserDetailsState(
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
      //print("ValidUserDetailsState");
      emit(const ValidUserDetailsState());
    }
  }

  void onSubmitUserDetailsEvent(
      OnSubmitUserDetailsEvent event, Emitter<UserDetailsState> emit) async {
    emit(SubmitUserDetailsState(
        userModel: event.userModel, confirmPassword: event.confirmPassword));

    try {
      var userService = UserService();
      var response = await userService.updateUser(event.userModel);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        Map<String, dynamic> dynamo = response.data;
        var user = UserModel.fromJson(dynamo);
        emit(SuccessUserDetailsState(userModel: user));
      } else {
        emit(ErrorUserDetailsState(
            error: response.statusMessage ??
                "Unable to update User details! Please try again"));
      }
    } on DioException catch (ex) {
      //print(ex);
      emit(ErrorUserDetailsState(
          error: ex.message ??
              "Something went wrong while updating User details! Please try again"));
    } finally {}
  }

  void onLoginNavigateUserDetailsEvent(
      OnLoginNavigateUserDetailsEvent event, Emitter<UserDetailsState> emit) {
    emit(LoginNavigateUserDetailsState(
        email: event.email, password: event.password));
  }
}
