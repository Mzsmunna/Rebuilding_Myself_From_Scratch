part of 'counter_bloc.dart';

abstract class CounterState {
  int count;
  CounterState({required this.count});
}

class InitialState extends CounterState {
  InitialState() : super(count: 0);
}

class IncreaseState extends CounterState {
  IncreaseState({required int count}) : super(count: count);
}

class DecreaseState extends CounterState {
  DecreaseState({required int count}) : super(count: count);
}
