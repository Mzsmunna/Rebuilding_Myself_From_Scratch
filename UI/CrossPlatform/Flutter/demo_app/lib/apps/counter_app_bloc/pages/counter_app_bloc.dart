import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:demo_app/apps/counter_app_bloc/features/blocs/counter_bloc/counter_bloc.dart';

class CounterAppBloc extends StatelessWidget {
  const CounterAppBloc({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => CounterBloc(),
      child: MaterialApp(
        title: 'Flutter Bloc Demo',
        debugShowCheckedModeBanner: false,
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        home: const CounterBlocPage(title: 'Mzs Bloc Demo App'),
      ),
    );
  }
}

class CounterBlocPage extends StatelessWidget {
  final String title;
  const CounterBlocPage({super.key, required this.title});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(title),
      ),
      body: Center(
        child:
            BlocBuilder<CounterBloc, CounterState>(builder: (context, state) {
          return Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Text(
                "Count value is:",
                style: Theme.of(context).textTheme.headlineSmall,
              ),
              Text(
                "${BlocProvider.of<CounterBloc>(context).state.count}",
                style: Theme.of(context).textTheme.headlineMedium,
              ),
            ],
          );
        }),
      ),
      floatingActionButton: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: <Widget>[
          FloatingActionButton(
            onPressed: () =>
                BlocProvider.of<CounterBloc>(context).add(IncreaseEvent()),
            tooltip: 'Increment',
            child: const Icon(Icons.add),
          ),
          const SizedBox(
            width: 5.0,
          ),
          FloatingActionButton(
            onPressed: () =>
                BlocProvider.of<CounterBloc>(context).add(DecreaseEvent()),
            tooltip: 'Decrement',
            child: const Icon(Icons.remove),
          ),
        ],
      ),
    );
  }
}
