import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'sample_state.dart';

class SampleCubit extends Cubit<SampleState> {
  SampleCubit() : super(SampleInitial());
}
