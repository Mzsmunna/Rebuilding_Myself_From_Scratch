import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { CustomValidation } from '../../../helpers/validations/custom-validation.model';
import { AuthService } from '../../../services/auth/auth.service';
import { AlertService } from '../../../services/common/alert/alert.service';
import { UnsubscribeService } from '../../../services/common/unsubscribe/unsubscribe.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends UnsubscribeService implements OnInit {

  user: User;
  registerForm: FormGroup;

  constructor(private authService: AuthService, private alertService: AlertService, private route: Router) {

    super();
    this.user = {} as User;

    //One Way
    //this.registerForm = new FormGroup({
    //  'FirstName': new FormControl('', Validators.compose([Validators.required, Validators.minLength(5)])),
    //  'LastName': new FormControl('', Validators.compose([Validators.required, Validators.minLength(5)])),
    //  'Gender': new FormControl('', Validators.required),
    //  'BirthDate': new FormControl(''),
    //  'Age': new FormControl(''),
    //  'Email': new FormControl('', Validators.compose([Validators.required, Validators.email])),
    //  'Password': new FormControl('', Validators.compose([Validators.required, Validators.minLength(5)])),
    //  'ConfirmPassword': new FormControl('', Validators.required),
    //  'Role': new FormControl(''),
    //});

    //Another Way
    this.registerForm = new FormGroup({
      FirstName: new FormControl('', Validators.compose([Validators.required, Validators.minLength(3), Validators.pattern("[a-zA-Z ]*")])),
      LastName: new FormControl('', Validators.compose([Validators.required, Validators.minLength(3), Validators.pattern("[a-zA-Z ]*")])),
      Gender: new FormControl('male', Validators.required),
      BirthDate: new FormControl(''),
      Age: new FormControl(''),
      Phone: new FormControl('', Validators.pattern('(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})')),
      Address: new FormControl(''),
      Department: new FormControl(''),
      Designation: new FormControl(''),
      Position: new FormControl(''),
      Email: new FormControl('', Validators.compose([Validators.required, Validators.email])),
      Password: new FormControl('', Validators.compose([Validators.required, Validators.minLength(5)])),
      ConfirmPassword: new FormControl('', Validators.compose([Validators.required, Validators.minLength(5)])),
      //Role: new FormControl('user', Validators.required),
    }, { validators: CustomValidation.passwordMatchValidate });
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
      this.user.Phone = this.registerForm.value.Phone;
      this.user.Address = this.registerForm.value.Address;
      this.user.Department = this.registerForm.value.Department;
      this.user.Designation = this.registerForm.value.Designation;
      this.user.Position = this.registerForm.value.Position;
      this.user.Email = this.registerForm.value.Email;
      this.user.Password = this.registerForm.value.Password;
      this.user.Role = 'user'; //this.registerForm.value.Role;
      this.user.IsActive = true;

      console.log(this.user);
      console.log(this.registerForm.value);

      if (this.registerForm.value.Password == this.registerForm.value.ConfirmPassword) {

        this.authService.Register(this.user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

          console.log(result);

          if (result) {

            this.alertService.SuccessDetails("Registration Successful!!", "Hola!!", "You will be redirected to Home page.", true);
            this.user = result as User;
            this.Login();

          } else {

            console.log("Registration Failed!");
            this.alertService.ErrorDetails("Something went wrong!!", "Opps!! Registration failed!", "Please try again!!", true);
          }

        },
        error => {

          console.log("registration server error:", error);

          if (error.status === 409) {

            this.alertService.ErrorDetails("Try a different email!!", "Opps!! Email already exist!", "Or Login if already registered!", true);

          } else {

            this.alertService.ErrorDetails("Something went wrong!!", "Opps!! Registration failed!", "Please try again!!", true);
          }

        },
        () => console.log('yay'));

      } else {

        console.log("Password didn't match");
      }     
    }
  }

  Login() {

    console.log(this.user);

    if (this.user != null) {

      this.authService.Login(this.user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

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
