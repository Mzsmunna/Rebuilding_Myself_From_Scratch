import 'package:flutter/material.dart';

class FormSquareTile extends StatelessWidget {
  final String imagePath;
  final double height;
  const FormSquareTile({
    super.key,
    required this.imagePath,
    required this.height,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(20),
      decoration: BoxDecoration(
        border: Border.all(color: Colors.white),
        borderRadius: BorderRadius.circular(16),
        color: Colors.grey[200],
      ),
      child: Image.asset(
        imagePath,
        height: height,
      ),
    );
  }
}
