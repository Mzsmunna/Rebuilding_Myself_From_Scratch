import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_button.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_datetime.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_dropdown.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_square_tile.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_textfield.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class RegisterPage extends StatelessWidget {
  RegisterPage({super.key});

  // text editing controllers
  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();
  //final genderController = TextEditingController();
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

  // sign user in method
  void signUserIn() {}

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[300],
      body: SafeArea(
        child: Center(
          child: SingleChildScrollView(
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
                  "Welcome! Let's resolve issues",
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
                ),

                const SizedBox(height: 10),

                // lastname textfield
                FormTextField(
                  controller: lastNameController,
                  hintText: 'Last Name',
                  obscureText: false,
                ),

                const SizedBox(height: 10),

                // gender dropdown
                const FormDropdown(
                  list: <String>['Gender', 'Male', 'Female', 'Other'],
                ),

                const SizedBox(height: 10),

                // dob textfield
                FormDateField(
                  controller: dobController,
                  hintText: 'Birth Date',
                  obscureText: false,
                ),

                const SizedBox(height: 10),

                // password textfield
                FormTextField(
                  controller: passwordController,
                  hintText: 'Password',
                  obscureText: true,
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
                  onTap: signUserIn,
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
                        padding: const EdgeInsets.symmetric(horizontal: 10.0),
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
    );
  }
}
