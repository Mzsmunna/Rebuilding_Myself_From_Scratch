import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'issue_state.dart';

class IssueCubit extends Cubit<IssueState> {
  IssueCubit() : super(IssueInitial());
}
