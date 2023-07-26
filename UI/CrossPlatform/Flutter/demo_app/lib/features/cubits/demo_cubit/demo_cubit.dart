import 'package:bloc/bloc.dart';
// 'package:meta/meta.dart';

part 'demo_state.dart';

class DemoCubit extends Cubit<DemoState> {
  DemoCubit() : super(DemoInitial());
}
