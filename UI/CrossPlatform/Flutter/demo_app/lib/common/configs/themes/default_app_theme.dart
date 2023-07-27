import 'package:flutter/material.dart';

class DefaultAppTheme {
  static Color lightPrimaryColor = getHexColor('#DF0054');
  static Color darkPrimaryColor = getHexColor('#6495ED');
  static Color secondaryColor = getHexColor('#FF8B6A');
  static Color accentColor = getHexColor('#FFD2BB');

  static ThemeData materialThree = ThemeData(
    primarySwatch: Colors.blue,
    useMaterial3: true,
  );

  static ThemeData materialTwo = ThemeData(
    primarySwatch: Colors.blue,
  );

  static ThemeData lightTheme = ThemeData(
    primaryColor: ThemeData.light().scaffoldBackgroundColor,
    colorScheme: const ColorScheme.light()
        .copyWith(primary: lightPrimaryColor, secondary: secondaryColor),
  );

  static ThemeData darkTheme = ThemeData(
    primaryColor: ThemeData.dark().scaffoldBackgroundColor,
    colorScheme: const ColorScheme.dark().copyWith(
      primary: darkPrimaryColor,
    ),
  );

  static Color getHexColor(String hexColor) {
    return Color(int.parse(hexColor.substring(1, 7), radix: 16) + 0xFF000000);
  }
}
