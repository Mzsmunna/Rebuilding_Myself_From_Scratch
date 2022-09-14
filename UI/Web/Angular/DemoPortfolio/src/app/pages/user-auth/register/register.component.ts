import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: User;
  registerForm: FormGroup;

  constructor(private authService: AuthService, private route: Router) {

    this.user = {} as User;
    this.registerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      gender: new FormControl(''),
      birthDate: new FormControl(''),
      age: new FormControl(''),
      email: new FormControl('', Validators.compose([Validators.required, Validators.email])),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      role: new FormControl(''),
    })
  }

  ngOnInit(): void {

    console.log(this.user);
    console.log(this.registerForm.value);
  }

  Register(isValid: boolean) {

    if (isValid) {

      this.user.firstName = this.registerForm.value.firstName;
      this.user.lastName = this.registerForm.value.lastName;
      this.user.gender = this.registerForm.value.gender;
      this.user.birthDate = new Date(this.registerForm.value.birthDate);
      this.user.age = this.registerForm.value.age;
      this.user.email = this.registerForm.value.email;
      this.user.password = this.registerForm.value.password;
      this.user.role = this.registerForm.value.role;
      this.user.isActive = true;

      console.log(this.user);
      console.log(this.registerForm.value);

      if (this.registerForm.value.password == this.registerForm.value.confirmPassword) {

        this.authService.Register(this.user).subscribe(result => {

          console.log(result);

          if (result) {

            this.user = result as User;
            this.Login();

          } else {

            console.log("Registration Failed!");
          }

        });

      } else {

        console.log("Password didn't match");
      }     
    }
  }

  Login() {

    console.log(this.user);

    if (this.user != null) {

      this.authService.Login(this.user).subscribe(result => {

        console.log(result);

        if (result) {

          localStorage.setItem('token', result);
          this.route.navigate(['/home']);

        } else {

          console.log("Login Failed!");
        }

      });
    }
  }

}
