import 'package:demo_app/apps/issue_manager_app/domain/entities/user_model.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_button.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_datetime.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_dropdown.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_number_picker.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_square_tile.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_textfield.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/register/bloc/register_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

class RegisterPage extends StatelessWidget {
  RegisterPage({super.key});

  // text editing controllers
  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();
  final genderController = TextEditingController();
  final dobController = TextEditingController();
  final ageController = TextEditingController();
  final phoneController = TextEditingController();
  final addressController = TextEditingController();
  final departmentController = TextEditingController();
  final designationController = TextEditingController();
  final positionController = TextEditingController();
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmPasswordController = TextEditingController();

  final registerBloc = RegisterBloc();
  final formKey = GlobalKey<FormState>();
  final UserModel userModel = UserModel();

  // signup user in method
  void signUserUp() {
    if (formKey.currentState!.validate()) {
      registerBloc.add(OnSubmitRegisterEvent(
          userModel: userModel,
          confirmPassword: confirmPasswordController.text));
    }
  }

  void onFirstNameChange(String value) {
    userModel.firstName = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onLastNameChange(String value) {
    userModel.lastName = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onGenderChange(String? value) {
    userModel.gender = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onBirthDateChange(DateTime? value) {
    userModel.birthDate = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onAgeChange(int value) {
    userModel.age = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPhoneNumberChange(String value) {
    userModel.phone = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onAddressChange(String value) {
    userModel.address = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onDepartmentChange(String? value) {
    userModel.department = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onDesignationChange(String value) {
    userModel.designation = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPositionChange(String? value) {
    userModel.position = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onEmailChange(String value) {
    userModel.email = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onPasswordChange(String value) {
    userModel.password = value;
    registerBloc.add(OnChangeRegisterEvent(
        userModel: userModel, confirmPassword: confirmPasswordController.text));
  }

  void onConfirmPasswordChange(String value) {
    registerBloc.add(
        OnChangeRegisterEvent(userModel: userModel, confirmPassword: value));
  }

  // (String? value) {
  //   // This is called when the user selects an item.
  //   setState(() {
  //     widget.dropdownValue = value!;
  //   });
  // },

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<RegisterBloc, RegisterState>(
      bloc: registerBloc,
      listenWhen: (previous, current) {
        bool doListen = false;
        if (current is LoginNavigateRegisterState ||
            current is SubmitRegisterState ||
            current is ErrorRegisterState ||
            current is SuccessRegisterState) {
          doListen = true;
        }
        return doListen;
      },
      buildWhen: (previous, current) {
        bool doBuild = true;
        if (current is LoginNavigateRegisterState) {
          doBuild = false;
        }
        return doBuild;
      },
      listener: (context, state) {
        if (state is LoginNavigateRegisterState) {
          //print("state is OnRegisterNavigateLoginEvent");
          GoRouter.of(context).go("/IssueManager/Login");
        } else if (state is SuccessRegisterState) {
          //print("state is OnRegisterNavigateLoginEvent");
          //GoRouter.of(context).go("/IssueManager/Home");
          ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
              content: Text("Registration Successful!! Please login now")));
          Future.delayed(const Duration(seconds: 1), () {
            GoRouter.of(context).go("/IssueManager/Login");
          });
        } else if (state is ErrorRegisterState) {
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

                      // logo
                      const Icon(
                        Icons.lock,
                        size: 100,
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        currentValue: 30,
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        onValidate: (value) => (state is InvalidRegisterState &&
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
                        text: "Sign Up",
                        onTap:
                            (state is ValidRegisterState) ? signUserUp : null,
                      ),

                      const SizedBox(height: 20),

                      // or continue with
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 25.0),
                        child: Row(
                          children: [
                            Expanded(
                              child: Divider(
                                thickness: 0.5,
                                color: Colors.grey[400],
                              ),
                            ),
                            Padding(
                              padding:
                                  const EdgeInsets.symmetric(horizontal: 10.0),
                              child: Text(
                                'Or continue with',
                                style: TextStyle(color: Colors.grey[700]),
                              ),
                            ),
                            Expanded(
                              child: Divider(
                                thickness: 0.5,
                                color: Colors.grey[400],
                              ),
                            ),
                          ],
                        ),
                      ),

                      const SizedBox(height: 15),

                      // google + apple sign in buttons
                      const Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          // google button
                          FormSquareTile(
                            imagePath:
                                'lib/apps/issue_manager_app/application/assets/icons/google.png',
                            height: 20,
                          ),

                          SizedBox(width: 20),

                          // apple button
                          FormSquareTile(
                            imagePath:
                                'lib/apps/issue_manager_app/application/assets/icons/apple.png',
                            height: 20,
                          ),
                        ],
                      ),

                      const SizedBox(height: 20),

                      // not a member? register now
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                            'Already a member?',
                            style: TextStyle(color: Colors.grey[700]),
                          ),
                          const SizedBox(width: 4),
                          GestureDetector(
                            child: const Text(
                              'Login now',
                              style: TextStyle(
                                color: Colors.blue,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            onTap: () {
                              GoRouter.of(context).go("/IssueManager/Login");
                            },
                          ),
                        ],
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
