import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/user_service.dart';
import 'package:dio/dio.dart';
import 'package:equatable/equatable.dart';

part 'issue_home_event.dart';
part 'issue_home_state.dart';

class IssueHomeBloc extends Bloc<IssueHomeEvent, IssueHomeState> {
  IssueHomeBloc() : super(const IssueHomeInitialState(userModels: null)) {
    on<IssueHomeGetUserEvent>(onGetUserIssueHomeEvent);
  }

  FutureOr<void> onGetUserIssueHomeEvent(
      IssueHomeGetUserEvent event, Emitter<IssueHomeState> emit) async {
    try {
      var userService = UserService();
      //var authService = AuthService();
      //var userId = authService.getCurrentUserId();

      List<SearchFieldModel> userSearchQueries = [];
      SearchFieldModel searchQuery = SearchFieldModel();
      searchQuery.key = "Email";
      searchQuery.dataType = "string";
      userSearchQueries.add(searchQuery);

      var response = await userService.getAllUserCount(userSearchQueries);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        emit(IssueHomeUserLoaded(userModels: response.data));
      } else {
        emit(IssueHomeUserLoadError(
            userModels: null,
            error:
                response.statusMessage ?? "Unable to login! Please try again"));
      }
    } on DioException catch (ex) {
      //print(ex);
      emit(IssueHomeUserLoadError(
          userModels: null,
          error: ex.message ??
              "Something went wrong while logging in! Please try again"));
    } finally {}
  }
}
