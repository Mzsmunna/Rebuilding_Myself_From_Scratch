part of 'counter_bloc.dart';

abstract class CounterEvent {
  CounterEvent();
}

class InitialEvent extends CounterEvent {}

class IncreaseEvent extends CounterEvent {}

class DecreaseEvent extends CounterEvent {}
