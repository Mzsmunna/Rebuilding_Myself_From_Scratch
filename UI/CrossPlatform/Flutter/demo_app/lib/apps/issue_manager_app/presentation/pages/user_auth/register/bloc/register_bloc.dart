import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
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
    if (event.userModel.firstName == "" ||
        event.userModel.lastName == "" ||
        event.userModel.gender == "" ||
        event.userModel.email == "" ||
        event.userModel.password == "" ||
        event.confirmPassword == "") {
      //print("InitialRegisterState");
      emit(const InitialRegisterState());
    }
    // else if (event.email == "") {
    //   //print("Please enter your email");
    //   emit(const InvalidRegisterState(validation: "Please enter your email"));
    // } else if (event.password == "") {
    //   //print("Please enter your password");
    //   emit(
    //       const InvalidRegisterState(validation: "Please enter your password"));
    // } else if (!event.email.contains("@") && !event.email.contains(".")) {
    //   //print("Not a valid email");
    //   emit(const InvalidRegisterState(validation: "Not a valid email"));
    // } else {
    //   //print("ValidRegisterState");
    //   emit(const ValidRegisterState());
    // }
  }

  void onSubmitRegisterEvent(
      OnSubmitRegisterEvent event, Emitter<RegisterState> emit) {
    emit(SubmitRegisterState(
        userModel: event.userModel, confirmPassword: event.confirmPassword));
  }

  void onLoginNavigateRegisterEvent(
      OnLoginNavigateRegisterEvent event, Emitter<RegisterState> emit) {
    emit(LoginNavigateRegisterState(
        email: event.email, password: event.password));
  }
}
