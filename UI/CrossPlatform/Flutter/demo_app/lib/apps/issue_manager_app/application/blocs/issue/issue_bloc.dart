import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'issue_event.dart';
part 'issue_state.dart';

class IssueBloc extends Bloc<IssueEvent, IssueState> {
  IssueBloc() : super(IssueInitial()) {
    on<IssueEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
