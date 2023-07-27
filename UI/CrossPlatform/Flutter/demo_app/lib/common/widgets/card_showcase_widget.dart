import 'package:flutter/material.dart';

class CardShowcaseWidget extends StatelessWidget {
  final String title;
  final String description;
  final String image;
  final Widget app;

  const CardShowcaseWidget(
      {super.key,
      required this.title,
      required this.description,
      required this.image,
      required this.app});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) {
              return app;
            },
          ),
        );
      },
      child: Card(
        child: Container(
          padding: const EdgeInsets.all(5),
          width: double.infinity,
          child: Column(
            children: [
              const SizedBox(
                height: 5.0,
              ),
              Image.asset(image),
              Text(
                title,
                style: const TextStyle(
                  fontSize: 22,
                  fontWeight: FontWeight.bold,
                ),
              ),
              Text(description),
              const SizedBox(
                height: 5.0,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
