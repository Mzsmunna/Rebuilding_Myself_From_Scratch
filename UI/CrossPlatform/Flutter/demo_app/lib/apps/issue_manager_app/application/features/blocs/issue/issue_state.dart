part of 'issue_bloc.dart';

abstract class IssueState extends Equatable {
  const IssueState();
  
  @override
  List<Object> get props => [];
}

class IssueInitial extends IssueState {}
