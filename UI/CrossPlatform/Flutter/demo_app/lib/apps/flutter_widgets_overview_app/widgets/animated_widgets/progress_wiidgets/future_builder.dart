//! Future builder
import 'package:flutter/material.dart';

class FutureBuilderWidget extends StatefulWidget {
  const FutureBuilderWidget({Key? key}) : super(key: key);

  @override
  State<FutureBuilderWidget> createState() => _FutureBuilderWidgetState();
}

class _FutureBuilderWidgetState extends State<FutureBuilderWidget> {
  Future<String> getData() async {
    await Future.delayed(
      const Duration(seconds: 1),
    );
    //throw 'Error';
    return 'Super!';
  }

  @override
  Widget build(BuildContext context) {
    return Center(
      child: FutureBuilder(
        future: getData(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const CircularProgressIndicator();
          }
          if (snapshot.hasError) {
            return Text(
              snapshot.error.toString(),
            );
          } else {
            return Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Text(
                  snapshot.data.toString(),
                ),
                ElevatedButton(
                  onPressed: () {
                    setState(() {});
                  },
                  child: const Text('Refresh'),
                ),
              ],
            );
          }
        },
      ),
    );
  }
}
