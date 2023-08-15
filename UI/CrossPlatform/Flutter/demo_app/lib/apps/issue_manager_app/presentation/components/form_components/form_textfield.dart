import 'package:demo_app/apps/issue_manager_app/application/configs/themes/issue_manager_themes.dart';
import 'package:flutter/material.dart';

class FormTextField extends StatelessWidget {
  final TextEditingController controller;
  final String hintText;
  final bool obscureText;
  final AutovalidateMode autovalidateMode;
  final Function(String)? onChanged;
  final String? Function(String?)? onValidate;
  final int maxLines;

  const FormTextField(
      {super.key,
      required this.controller,
      required this.hintText,
      required this.obscureText,
      required this.autovalidateMode,
      this.onChanged,
      this.onValidate,
      this.maxLines = 1});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25.0),
      child: TextFormField(
        controller: controller,
        obscureText: (maxLines > 1) ? false : obscureText,
        keyboardType: TextInputType.multiline,
        maxLines: maxLines,
        decoration: IssueManagerTheme.getFormInputDecoration(hintText),
        autovalidateMode: autovalidateMode,
        onChanged: onChanged,
        validator: onValidate,
      ),
    );
  }
}
