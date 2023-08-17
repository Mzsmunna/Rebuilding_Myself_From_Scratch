import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/user_service.dart';
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

      //var count = await userService.getAllUserCount(userSearchQueries);
      var response = await userService.getAllUsers(
          0, 10, "FirstName", "ascending", userSearchQueries);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        List<UserModel> userList = [];
        // response.data
        //     .map((Map<String, dynamic> val) => UserModel.fromJson(val))
        //     .toList();

        // response.data.forEach((data) {
        //   var user = UserModel.fromJson(data);
        //   userList.add(user);
        // });

        for (int i = 0; i < response.data.length; i++) {
          Map<String, dynamic> dynamo = response.data[i];
          var user = UserModel.fromJson(dynamo);
          userList.add(user);
        }
        emit(IssueHomeUserLoaded(userModels: userList));
      } else {
        emit(IssueHomeUserLoadError(
            userModels: null,
            error:
                response.statusMessage ?? "Unable to login! Please try again"));
      }
    } catch (ex) {
      //print(ex);
      emit(
        const IssueHomeUserLoadError(
            userModels: null,
            error:
                "Something went wrong while logging in! Please try again"), //ex.toString() ??
      );
    } finally {}
  }
}
