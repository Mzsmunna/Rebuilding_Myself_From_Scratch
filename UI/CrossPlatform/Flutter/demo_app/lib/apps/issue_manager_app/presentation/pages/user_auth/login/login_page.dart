import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_button.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_square_tile.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/components/form_components/form_textfield.dart';
import 'package:demo_app/apps/issue_manager_app/presentation/pages/user_auth/login/bloc/login_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  // text editing controllers
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final loginBloc = LoginBloc();
  final formKey = GlobalKey<FormState>();

  // sign user in method
  void onSignIn() {
    if (formKey.currentState!.validate()) {
      loginBloc.add(OnSubmitLoginEvent(
          email: emailController.text, password: passwordController.text));
    }
  }

  void onSignUpNavigate() {
    loginBloc.add(OnRegisterNavigateLoginEvent(
        email: emailController.text, password: passwordController.text));
    //print("onSignUpNavigate");
  }

  void onEmailChange(String value) {
    loginBloc.add(
        OnChangeLoginEvent(email: value, password: passwordController.text));
  }

  void onPasswordChange(String value) {
    loginBloc
        .add(OnChangeLoginEvent(email: emailController.text, password: value));
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LoginBloc, LoginState>(
      bloc: loginBloc,
      listenWhen: (previous, current) {
        bool doListen = false;
        if (current is RegisterNavigateLoginState ||
            current is SubmitLoginState ||
            current is ErrorLoginState ||
            current is SuccessLoginState) {
          doListen = true;
        }
        return doListen;
      },
      buildWhen: (previous, current) {
        bool doBuild = true;
        if (current is RegisterNavigateLoginState ||
            current is SubmitLoginState ||
            current is ErrorLoginState ||
            current is SuccessLoginState) {
          doBuild = false;
        }
        return doBuild;
      },
      listener: (context, state) {
        if (state is RegisterNavigateLoginState) {
          //print("state is RegisterNavigateLoginState");
          GoRouter.of(context).go("/IssueManager/Register");
        } else if (state is ErrorLoginState) {
          //print("state is ErrorLoginState");
          ScaffoldMessenger.of(context)
              .showSnackBar(SnackBar(content: Text(state.error)));
        } else if (state is SuccessLoginState) {
          //print("state is SuccessLoginState");
          ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(content: Text("Login Successful!!")));
          Future.delayed(const Duration(seconds: 1), () {
            GoRouter.of(context).go("/IssueManager/IssueHome");
          });
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
                      // logo
                      const Icon(
                        Icons.lock,
                        size: 100,
                      ),

                      const SizedBox(height: 20),

                      // welcome back, you've been missed!
                      Text(
                        'Welcome back you\'ve been missed!',
                        style: TextStyle(
                          color: Colors.grey[700],
                          fontSize: 16,
                        ),
                      ),

                      const SizedBox(height: 20),

                      // email textfield
                      FormTextField(
                        controller: emailController,
                        hintText: 'Email',
                        obscureText: false,
                        onChanged: onEmailChange,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onValidate: (value) =>
                            (state is InvalidLoginState && !state.isValidEmail)
                                ? "Not a valid Email"
                                : null,
                      ),

                      const SizedBox(height: 10),

                      // password textfield
                      FormTextField(
                        controller: passwordController,
                        hintText: 'Password',
                        obscureText: true,
                        onChanged: onPasswordChange,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        onValidate: (value) => (state is InvalidLoginState &&
                                !state.isValidPassword)
                            ? "Not a valid Password"
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

                      // sign in button
                      FormButton(
                        text: "Sign In",
                        onTap: (state is ValidLoginState) ? onSignIn : null,
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
                            height: 40,
                          ),

                          SizedBox(width: 20),

                          // apple button
                          FormSquareTile(
                            imagePath:
                                'lib/apps/issue_manager_app/application/assets/icons/apple.png',
                            height: 40,
                          ),
                        ],
                      ),

                      const SizedBox(height: 20),

                      // not a member? register now
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                            'Not a member?',
                            style: TextStyle(color: Colors.grey[700]),
                          ),
                          const SizedBox(width: 4),
                          GestureDetector(
                            onTap: onSignUpNavigate,
                            child: const Text(
                              'Register now',
                              style: TextStyle(
                                color: Colors.blue,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                          ),
                        ],
                      ),
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
