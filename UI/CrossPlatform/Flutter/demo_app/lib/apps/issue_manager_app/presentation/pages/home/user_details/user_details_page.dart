import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_button.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_datetime.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_dropdown.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_number_picker.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_square_tile.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_textfield.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/home/user_details/bloc/user_details_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';
import 'package:intl/intl.dart';

// ignore: must_be_immutable
class UserDetailsPage extends StatelessWidget {
  final UserModel userModel;

// text editing controllers
  late TextEditingController firstNameController;
  late TextEditingController lastNameController;
  late TextEditingController genderController;
  late TextEditingController dobController;
  late TextEditingController ageController;
  late TextEditingController phoneController;
  late TextEditingController addressController;
  late TextEditingController departmentController;
  late TextEditingController designationController;
  late TextEditingController positionController;
  late TextEditingController emailController;
  late TextEditingController passwordController;
  late TextEditingController confirmPasswordController;

  UserDetailsPage({super.key, required this.userModel}) {
    firstNameController = TextEditingController(text: userModel.firstName);
    lastNameController = TextEditingController(text: userModel.lastName);
    genderController = TextEditingController(text: userModel.gender);
    dobController = TextEditingController(
        text: userModel.birthDate == null
            ? ""
            : DateFormat('yyyy-MM-dd').format(userModel.birthDate!));
    ageController = TextEditingController(text: userModel.age.toString());
    phoneController = TextEditingController(text: userModel.phone);
    addressController = TextEditingController(text: userModel.address);
    departmentController = TextEditingController(text: userModel.department);
    designationController = TextEditingController(text: userModel.designation);
    positionController = TextEditingController(text: userModel.position);
    emailController = TextEditingController(text: userModel.email);
    passwordController = TextEditingController();
    confirmPasswordController = TextEditingController();
  }

  final userDetailsBloc = UserDetailsBloc();
  final formKey = GlobalKey<FormState>();

  void updateUserInfo() {
    if (formKey.currentState!.validate()) {
      userDetailsBloc.add(OnSubmitUserDetailsEvent(
          userModel: userModel,
          confirmPassword: confirmPasswordController.text));
    }
  }

  void onFirstNameChange(String value) {
    userModel.firstName = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onLastNameChange(String value) {
    userModel.lastName = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onGenderChange(String? value) {
    userModel.gender = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onBirthDateChange(DateTime? value) {
    userModel.birthDate = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onAgeChange(int value) {
    userModel.age = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPhoneNumberChange(String value) {
    userModel.phone = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onAddressChange(String value) {
    userModel.address = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onDepartmentChange(String? value) {
    userModel.department = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onDesignationChange(String value) {
    userModel.designation = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPositionChange(String? value) {
    userModel.position = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onEmailChange(String value) {
    userModel.email = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPasswordChange(String value) {
    userModel.password = value;
    userDetailsBloc.add(OnChangeUserDetailsEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onConfirmPasswordChange(String value) {
    userDetailsBloc.add(
        OnChangeUserDetailsEvent(userModel: userModel, confirmPassword: value));
  }

  // (String? value) {
  //   // This is called when the user selects an item.
  //   setState(() {
  //     widget.dropdownValue = value!;
  //   });
  // },

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<UserDetailsBloc, UserDetailsState>(
      bloc: userDetailsBloc,
      listenWhen: (previous, current) {
        bool doListen = false;
        if (current is LoginNavigateUserDetailsState ||
            current is SubmitUserDetailsState ||
            current is ErrorUserDetailsState ||
            current is SuccessUserDetailsState) {
          doListen = true;
        }
        return doListen;
      },
      buildWhen: (previous, current) {
        bool doBuild = true;
        if (current is LoginNavigateUserDetailsState) {
          doBuild = false;
        }
        return doBuild;
      },
      listener: (context, state) {
        if (state is LoginNavigateUserDetailsState) {
          //print("state is OnUserDetailsNavigateLoginEvent");
          GoRouter.of(context).go("/IssueManager/Login");
        } else if (state is SuccessUserDetailsState) {
          //print("state is OnUserDetailsNavigateLoginEvent");
          //GoRouter.of(context).go("/IssueManager/Home");
          ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
              content: Text("Registration Successful!! Please login now")));
          Future.delayed(const Duration(seconds: 1), () {
            GoRouter.of(context).go("/IssueManager/Login");
          });
        } else if (state is ErrorUserDetailsState) {
          //print("state is ErrorLoginState");
          ScaffoldMessenger.of(context)
              .showSnackBar(SnackBar(content: Text(state.error)));
        }
      },
      builder: (context, state) {
        return Scaffold(
          backgroundColor: Colors.grey[300],
          body: SafeArea(
            child: Center(
              child: SingleChildScrollView(
                child: Form(
                  key: formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      const SizedBox(height: 10),

                      // Image
                      const Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          // google button
                          FormSquareTile(
                            imagePath:
                                'lib/apps/issue_manager_app/application/assets/icons/google.png',
                            height: 320,
                          ),
                        ],
                      ),

                      const SizedBox(height: 20),

                      // welcome back, you've been missed!
                      Text(
                        "Welcome! Let's on board to resolve issues",
                        style: TextStyle(
                          color: Colors.grey[700],
                          fontSize: 16,
                        ),
                      ),

                      const SizedBox(height: 20),

                      // firstname textfield
                      FormTextField(
                        controller: firstNameController,
                        hintText: 'First Name',
                        obscureText: false,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onFirstNameChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isValidFirstName)
                                ? "Not a valid Name"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // lastname textfield
                      FormTextField(
                        controller: lastNameController,
                        hintText: 'Last Name',
                        obscureText: false,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onLastNameChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isValidLastName)
                                ? "Not a valid Name"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // gender dropdown
                      FormDropdown(
                        controller: genderController,
                        obscureText: false,
                        list: const <String>[
                          'Gender',
                          'Male',
                          'Female',
                          'Other'
                        ],
                        onChanged: onGenderChange,
                      ),

                      const SizedBox(height: 10),

                      // dob textfield
                      FormDateField(
                        controller: dobController,
                        hintText: 'Birth Date',
                        obscureText: false,
                        onDatePick: onBirthDateChange,
                      ),

                      const SizedBox(height: 10),

                      // age textfield
                      FormNumberPicker(
                        hintText: 'Age',
                        axis: Axis.horizontal,
                        currentValue:
                            userModel.age == null ? 0 : userModel.age!,
                        minValue: 0,
                        maxValue: 150,
                        onChanged: onAgeChange,
                      ),

                      const SizedBox(height: 10),

                      // phonenumber textfield
                      FormTextField(
                        controller: phoneController,
                        hintText: 'Phone Number',
                        obscureText: false,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onPhoneNumberChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isValidPhone)
                                ? "Not a valid Phone Number"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // address textarea field
                      FormTextField(
                          controller: addressController,
                          hintText: 'Address',
                          obscureText: false,
                          maxLines: 5,
                          autovalidateMode: AutovalidateMode.onUserInteraction,
                          onChanged: onAddressChange),

                      const SizedBox(height: 10),

                      // departments dropdown
                      FormDropdown(
                        controller: departmentController,
                        obscureText: false,
                        list: const <String>[
                          'Departments',
                          'None',
                          'IT',
                          'QA',
                          'Engineer',
                          'Data Science',
                          'UI / UX',
                          'Marketing',
                          'Human Resource'
                        ],
                        onChanged: onDepartmentChange,
                      ),

                      const SizedBox(height: 10),

                      // designation textfield
                      FormTextField(
                        controller: designationController,
                        hintText: 'Designation',
                        obscureText: false,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onDesignationChange,
                      ),

                      const SizedBox(height: 10),

                      // Position dropdown
                      FormDropdown(
                        controller: positionController,
                        obscureText: false,
                        list: const <String>[
                          'Position',
                          'Unknown',
                          'Internship',
                          'Fresher',
                          'Junior',
                          'Mid',
                          'Senior',
                          'VP'
                        ],
                        onChanged: onPositionChange,
                      ),

                      const SizedBox(height: 10),

                      // email textfield
                      FormTextField(
                        controller: emailController,
                        hintText: 'Email',
                        obscureText: false,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onEmailChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isValidEmail)
                                ? "Not a valid Email"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // password textfield
                      FormTextField(
                        controller: passwordController,
                        hintText: 'Password',
                        obscureText: true,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onPasswordChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isValidPhone)
                                ? "Not a valid Password"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // confirm password textfield
                      FormTextField(
                        controller: confirmPasswordController,
                        hintText: 'Confirm Password',
                        obscureText: true,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onChanged: onConfirmPasswordChange,
                        onValidate: (value) =>
                            (state is InvalidUserDetailsState &&
                                    !state.isConfirmPassword)
                                ? "Password Didn't match"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // forgot password?
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 25.0),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            Text(
                              'Forgot Password?',
                              style: TextStyle(color: Colors.grey[600]),
                            ),
                          ],
                        ),
                      ),

                      const SizedBox(height: 20),

                      // sign up button
                      FormButton(
                        text: "Update",
                        onTap: (state is ValidUserDetailsState)
                            ? updateUserInfo
                            : null,
                      ),

                      const SizedBox(height: 20),
                    ],
                  ),
                ),
              ),
            ),
          ),
        );
      },
    );
  }
}
