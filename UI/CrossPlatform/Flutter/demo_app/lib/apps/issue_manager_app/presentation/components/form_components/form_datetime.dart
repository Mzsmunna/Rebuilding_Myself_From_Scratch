import 'package:demo_app/apps/issue_manager_app/application/configs/themes/issue_manager_themes.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class FormDateField extends StatefulWidget {
  final TextEditingController controller;
  final String hintText;
  final bool obscureText;
  final Function(DateTime?)? onDatePick;

  const FormDateField(
      {super.key,
      required this.controller,
      required this.hintText,
      required this.obscureText,
      required this.onDatePick});

  @override
  State<FormDateField> createState() => _FormDateFieldState();
}

class _FormDateFieldState extends State<FormDateField> {
  @override
  Widget build(BuildContext context) {
    DateTime? pickedDate = DateTime.now();
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 25.0),
      child: TextFormField(
        controller: widget.controller,
        obscureText: widget.obscureText,
        decoration: IssueManagerTheme.getFormInputDecoration(widget.hintText),
        readOnly: true, // when true user cannot edit text
        onTap: () async {
          //when click we have to show the datepicker
          pickedDate = await showDatePicker(
            context: context,
            initialDate: DateTime.now(), //get today's date
            firstDate: DateTime(
                1900), //DateTime.now() - not to allow to choose before today.
            lastDate: DateTime.now(),
          );

          if (pickedDate != null) {
            String formattedDate = DateFormat('MM-dd-yyyy').format(
                pickedDate!); // format date in required form here we use yyyy-MM-dd that means time is removed //formatted date output using intl package =>  2022-07-04
            //You can format date as per your need

            setState(() {
              widget.controller.text =
                  formattedDate; //set foratted date to TextField value.
            });
            if (widget.onDatePick != null) {
              widget.onDatePick!(pickedDate);
            }
          }
        },
      ),
    );
  }
}
