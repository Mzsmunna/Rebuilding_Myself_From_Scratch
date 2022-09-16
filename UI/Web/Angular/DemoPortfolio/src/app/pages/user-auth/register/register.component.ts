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
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      Gender: new FormControl(''),
      BirthDate: new FormControl(''),
      Age: new FormControl(''),
      Email: new FormControl('', Validators.compose([Validators.required, Validators.email])),
      Password: new FormControl('', Validators.required),
      ConfirmPassword: new FormControl('', Validators.required),
      Role: new FormControl(''),
    })
  }

  ngOnInit(): void {

    console.log(this.user);
    console.log(this.registerForm.value);
  }

  Register(isValid: boolean) {

    if (isValid) {

      this.user.FirstName = this.registerForm.value.FirstName;
      this.user.LastName = this.registerForm.value.LastName;
      this.user.Gender = this.registerForm.value.Gender;
      this.user.BirthDate = new Date(this.registerForm.value.BirthDate);
      this.user.Age = this.registerForm.value.Age;
      this.user.Email = this.registerForm.value.Email;
      this.user.Password = this.registerForm.value.Password;
      this.user.Role = this.registerForm.value.Role;
      this.user.IsActive = true;

      console.log(this.user);
      console.log(this.registerForm.value);

      if (this.registerForm.value.Password == this.registerForm.value.ConfirmPassword) {

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
