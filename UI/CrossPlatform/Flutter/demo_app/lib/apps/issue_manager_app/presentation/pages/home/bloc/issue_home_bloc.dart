import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'issue_home_event.dart';
part 'issue_home_state.dart';

class IssueHomeBloc extends Bloc<IssueHomeEvent, IssueHomeState> {
  IssueHomeBloc() : super(const IssueHomeInitialState(tabIndex: 0)) {
    on<OnIssueHomeTabChangeEvent>(onIssueHomeTabChangeEvent);
  }

  FutureOr<void> onIssueHomeTabChangeEvent(
      OnIssueHomeTabChangeEvent event, Emitter<IssueHomeState> emit) async {
    emit(IssueHomeTabChangedState(tabIndex: event.tabIndex));
  }
}
