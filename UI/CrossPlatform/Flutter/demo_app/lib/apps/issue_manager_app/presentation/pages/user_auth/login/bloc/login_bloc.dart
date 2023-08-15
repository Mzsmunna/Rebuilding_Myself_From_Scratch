import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
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

    //const String baseUrl = "https://localhost:7207";
    //const String baseUrl = "https://192.168.1.106:7207";
    const String baseUrl = "https://10.0.2.2:7207";

    final dio = Dio();
    final Map<String, dynamic> userJson = userModel.toJson();

    try {
      var response =
          await dio.post("$baseUrl/api/Auth/LoginWithEmail", data: userJson);
      print(response.statusCode);
      print(response.data);
    } on DioException catch (ex) {
      print(ex);
    } finally {
      dio.close();
    }

    emit(SubmitLoginState(email: event.email, password: event.password));
  }

  void onRegisterNavigateLoginEvent(
      OnRegisterNavigateLoginEvent event, Emitter<LoginState> emit) {
    emit(RegisterNavigateLoginState(
        email: event.email, password: event.password));
  }
}
