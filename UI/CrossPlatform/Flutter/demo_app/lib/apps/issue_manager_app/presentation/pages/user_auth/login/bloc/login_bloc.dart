import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/auth_service.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/utilities/shared_preference_utility.dart';
import 'package:dio/dio.dart';
import 'package:equatable/equatable.dart';
// ignore: depend_on_referenced_packages

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
    } else if (!event.isValidEmail || !event.isValidPassword) {
      //print("InvalidLoginState");
      emit(
        InvalidLoginState(
            email: event.email,
            password: event.password,
            isValidEmail: event.isValidEmail,
            isValidPassword: event.isValidPassword),
      );
    } else {
      //print("ValidLoginState");
      emit(const ValidLoginState());
    }
  }

  FutureOr<void> onSubmitLoginEvent(
      OnSubmitLoginEvent event, Emitter<LoginState> emit) async {
    var userModel = UserModel();
    userModel.email = event.email;
    userModel.password = event.password;

    emit(SubmitLoginState(email: event.email, password: event.password));

    // var client = http.Client();
    // try {
    //   // var response = await client.post(
    //   //     Uri.https('localhost:7207', '/api/Auth/LoginWithEmail'),
    //   //     body: userModel);
    //   //var decodedResponse = jsonDecode(utf8.decode(response.bodyBytes)) as Map;
    //   //var uri = Uri.parse(decodedResponse['uri'] as String);

    //   final url = Uri.parse('https://localhost:7207/api/Auth/LoginWithEmail');
    //   final headers = {
    //     'Content-Type': 'application/json',
    //     'Access-Control-Allow-Origin': '*',
    //   };
    //   final body = json.encode(userModel);

    //   final response = await http.post(url, headers: headers, body: body);
    //   final responseData = json.decode(response.body);

    //   print(response.body);
    // } finally {
    //   client.close();
    // }

    try {
      var authService = AuthService();
      var response = await authService.doLogin(userModel);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        var authToken = response.data.toString();
        var sharedPrefs = AppSharedPreferences.getSharedPreferenceInstance();
        //sharedPrefs?.remove("auth_token");
        sharedPrefs?.setString("auth_token", authToken);
        emit(SuccessLoginState(token: authToken));
      } else {
        emit(ErrorLoginState(
            error:
                response.statusMessage ?? "Unable to login! Please try again"));
      }
    } on DioException catch (ex) {
      //print(ex);
      emit(ErrorLoginState(
          error: ex.message ??
              "Something went wrong while logging in! Please try again"));
    } finally {}
  }

  void onRegisterNavigateLoginEvent(
      OnRegisterNavigateLoginEvent event, Emitter<LoginState> emit) {
    emit(RegisterNavigateLoginState(
        email: event.email, password: event.password));
  }
}
