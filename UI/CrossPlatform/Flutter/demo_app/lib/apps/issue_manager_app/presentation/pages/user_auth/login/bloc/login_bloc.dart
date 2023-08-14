import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  LoginBloc() : super(const InitialLoginState()) {
    on<OnChangeLoginEvent>(onChangeLoginEvent);
    on<OnSubmitLoginEvent>(onSubmitLoginEvent);
    on<OnRegisterNavigateLoginEvent>(onRegisterNavigateLoginEvent);

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

  void onChangeLoginEvent(OnChangeLoginEvent event, Emitter<LoginState> emit) {
    //print("email: ${event.email}");
    //print("password: ${event.password}");
    if (event.email == "" && event.password == "") {
      //print("InitialLoginState");
      emit(const InitialLoginState());
    } else if (event.email == "") {
      //print("Please enter your email");
      emit(const InvalidLoginState(validation: "Please enter your email"));
    } else if (event.password == "") {
      //print("Please enter your password");
      emit(const InvalidLoginState(validation: "Please enter your password"));
    } else if (!event.email.contains("@") && !event.email.contains(".")) {
      //print("Not a valid email");
      emit(const InvalidLoginState(validation: "Not a valid email"));
    } else {
      //print("ValidLoginState");
      emit(const ValidLoginState());
    }
  }

  void onSubmitLoginEvent(OnSubmitLoginEvent event, Emitter<LoginState> emit) {
    emit(SubmitLoginState(email: event.email, password: event.password));
  }

  void onRegisterNavigateLoginEvent(
      OnRegisterNavigateLoginEvent event, Emitter<LoginState> emit) {
    emit(RegisterNavigateLoginState(
        email: event.email, password: event.password));
  }
}
