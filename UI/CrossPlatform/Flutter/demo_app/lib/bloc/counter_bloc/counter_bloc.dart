import 'dart:async';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:equatable/equatable.dart';

part 'counter_event.dart';
part 'counter_state.dart';

class CounterBloc extends Bloc<CounterEvent, CounterState> {
  CounterBloc() : super(InitialState()) {
    //on<InitialEvent>(initialCounterEvent);
    //on<IncreaseEvent>(increaseCounterEvent);
    //on<DecreaseEvent>(decreseCounterEvent);

    on<IncreaseEvent>((event, emit) {
      emit(IncreaseState(count: state.count + 1));
    });

    on<DecreaseEvent>((event, emit) {
      emit(DecreaseState(count: state.count - 1));
    });
  }

  // FutureOr<void> initialCounterEvent(
  //     InitialEvent event, Emitter<CounterState> emit) {
  //   emit(InitialState());
  // }

  // FutureOr<void> increaseCounterEvent(
  //     IncreaseEvent event, Emitter<CounterState> emit) {
  //   emit(IncreaseState(count: state.count++));
  // }

  // FutureOr<void> decreseCounterEvent(
  //     DecreaseEvent event, Emitter<CounterState> emit) {
  //   emit(DecreaseState(count: state.count--));
  // }
}
