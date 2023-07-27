//! Stream builder

import 'package:flutter/material.dart';

class StreamBuilderWidget extends StatefulWidget {
  const StreamBuilderWidget({Key? key}) : super(key: key);

  @override
  State<StreamBuilderWidget> createState() => _StreamBuilderWidgetState();
}

//FAKE FIREBASE STREAM
Stream<int> generateStream = (() async* {
  await Future<void>.delayed(const Duration(seconds: 2));
  yield 1;
  await Future<void>.delayed(const Duration(seconds: 1));
  yield 2;
  //throw 'An error occured';
  await Future<void>.delayed(const Duration(seconds: 1));
  yield 3;
})();

class _StreamBuilderWidgetState extends State<StreamBuilderWidget> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: StreamBuilder(
        stream: generateStream,
        initialData: 0,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const CircularProgressIndicator.adaptive();
          }
          if (snapshot.hasError) {
            return const Text('Error');
          } else {
            return Text(
              snapshot.data.toString(),
              style: const TextStyle(fontSize: 40),
            );
          }
        },
      ),
    );
  }
}
