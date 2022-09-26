import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { AlertService } from '../../../services/common/alert/alert.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User;

  constructor(private authService: AuthService, private alertService: AlertService, private route: Router) {

    this.user = {} as User;
  }

  ngOnInit(): void {

    this.authService.Logout();
  }

  Login(isValid: boolean) {

    console.log(this.user);

    if (isValid) {

      this.authService.Login(this.user).subscribe(result => {

        console.log(result);

        if (result) {

          localStorage.setItem('token', result);
          this.alertService.Success("Login Successful!!", "Yay!!", true);
          this.route.navigate(['/home']);

        } else {

          console.log("Login Failed!");
        }

      });
    }
  }
}
