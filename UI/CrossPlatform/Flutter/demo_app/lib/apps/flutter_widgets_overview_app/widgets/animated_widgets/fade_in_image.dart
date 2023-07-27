//!FadeInImage

import 'package:flutter/material.dart';

class FadeInImageWidget extends StatelessWidget {
  const FadeInImageWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: FadeInImage.assetNetwork(
        placeholder: 'assets/icon/ocean.jpg',
        image: 'https://tinyurl.com/p4475pwh',
      ),
    );
  }
}
