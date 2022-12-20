import 'package:flutter/material.dart';
import '../../../widgets/app_widgets.dart';

class FlutterWidgetList extends StatefulWidget {
  const FlutterWidgetList({Key? key}) : super(key: key);

  @override
  _FlutterWidgetListState createState() => _FlutterWidgetListState();
}

class _FlutterWidgetListState extends State<FlutterWidgetList> {
  @override
  Widget build(BuildContext context) {
    return ListView(children: [
      getListTileWidget(const AbsorbPointerWidget(), "Absorb Pointer Widget"),
      getListTileWidget(const ChipWidget(), "Chip Widget"),
      getListTileWidget(const ChoiceChipWidget(), "Choice Chip Widget"),
    ]);
  }

  Widget getListTileWidget(Widget bindWidget, String title) {
    return ListTile(
      title: Text(title),
      tileColor: Colors.white30,
      onTap: () {
        //print("navgating to...");
        Navigator.of(context).push(MaterialPageRoute(builder: (context) {
          return Scaffold(
            appBar: AppBar(
              title: Text(title),
            ),
            body: bindWidget,
          );
        }));
      },
      leading: const Icon(Icons.widgets),
      trailing: const Icon(Icons.arrow_forward),
    );
  }
}
