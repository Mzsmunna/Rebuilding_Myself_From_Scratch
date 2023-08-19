import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:demo_app/apps/issue_manager_app/domain/entities/issue_model.dart';
import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';
import 'package:demo_app/apps/issue_manager_app/infrastructure/services/issue_service.dart';
import 'package:equatable/equatable.dart';

part 'issue_list_event.dart';
part 'issue_list_state.dart';

class IssueListBloc extends Bloc<IssueListEvent, IssueListState> {
  IssueListBloc() : super(const IssueListInitialState(issueModels: null)) {
    on<GetIssueListEvent>(onGetIssueListEvent);
  }

  FutureOr<void> onGetIssueListEvent(
      GetIssueListEvent event, Emitter<IssueListState> emit) async {
    try {
      var issueService = IssueService();
      //var authService = AuthService();
      //var userId = authService.getCurrentUserId();

      List<SearchFieldModel> issuesSearchQueries = [];
      SearchFieldModel searchQuery = SearchFieldModel();
      searchQuery.key = "Email";
      searchQuery.dataType = "string";
      issuesSearchQueries.add(searchQuery);

      //var count = await issueListervice.getAllIssueCount(IssueListearchQueries);
      var response = await issueService.getAllIssues(
          0, 10, "FirstName", "ascending", issuesSearchQueries);
      //print(response.statusCode);
      //print(response.data);
      if (response.statusCode == 200) {
        List<IssueModel> userList = [];
        // response.data
        //     .map((Map<String, dynamic> val) => UserModel.fromJson(val))
        //     .toList();

        // response.data.forEach((data) {
        //   var user = IssueModel.fromJson(data);
        //   userList.add(user);
        // });

        for (int i = 0; i < response.data.length; i++) {
          Map<String, dynamic> dynamo = response.data[i];
          var user = IssueModel.fromJson(dynamo);
          userList.add(user);
        }
        emit(IssueListLoaded(issueModels: userList));
      } else {
        emit(IssueListLoadError(
            issueModels: null,
            error:
                response.statusMessage ?? "Unable to login! Please try again"));
      }
    } catch (ex) {
      //print(ex);
      emit(
        const IssueListLoadError(
            issueModels: null,
            error:
                "Something went wrong while logging in! Please try again"), //ex.toString() ??
      );
    } finally {}
  }
}
