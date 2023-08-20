import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/user_service.dart';
import 'package:equatable/equatable.dart';

part 'user_list_event.dart';
part 'user_list_state.dart';

class UserListBloc extends Bloc<UserListEvent, UserListState> {
  UserListBloc() : super(const UserListInitialState(userModels: null)) {
    on<UserListGetUserEvent>(onGetUserUserListEvent);
  }

  FutureOr<void> onGetUserUserListEvent(
      UserListGetUserEvent event, Emitter<UserListState> emit) async {
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
        emit(UserListUserLoaded(userModels: userList));
      } else {
        emit(UserListUserLoadError(
            userModels: null,
            error:
                response.statusMessage ?? "Unable to login! Please try again"));
      }
    } catch (ex) {
      //print(ex);
      emit(
        const UserListUserLoadError(
            userModels: null,
            error:
                "Something went wrong while logging in! Please try again"), //ex.toString() ??
      );
    } finally {}
  }
}
