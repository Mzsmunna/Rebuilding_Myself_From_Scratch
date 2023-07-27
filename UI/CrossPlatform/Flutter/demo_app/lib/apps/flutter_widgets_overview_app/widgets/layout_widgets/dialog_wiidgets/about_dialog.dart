import 'package:flutter/material.dart';

//!AboutDialog

class AboutDialogWidget extends StatefulWidget {
  const AboutDialogWidget({
    Key? key,
  }) : super(key: key);

  @override
  State<AboutDialogWidget> createState() => _AboutDialogWidgetState();
}

class _AboutDialogWidgetState extends State<AboutDialogWidget> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ElevatedButton(
        child: const Text('Show About Dialog'),
        onPressed: () {
          showDialog(
            context: context,
            builder: (context) => const AboutDialog(
              applicationIcon: FlutterLogo(),
              applicationLegalese: 'Legalese',
              applicationName: 'Flutter App',
              applicationVersion: 'version 1.0.0',
              children: [
                Text('This is a text created by Flutter Mapp'),
              ],
            ),
          );
        },
      ),
    );
  }
}
