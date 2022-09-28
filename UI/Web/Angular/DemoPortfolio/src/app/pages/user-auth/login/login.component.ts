import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { AuthService } from '../../../services/auth/auth.service';
import { AlertService } from '../../../services/common/alert/alert.service';
import { UnsubscribeService } from '../../../services/common/unsubscribe/unsubscribe.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends UnsubscribeService implements OnInit, OnDestroy {

  user: User;

  constructor(private authService: AuthService, private alertService: AlertService, private route: Router) {

    super();
    this.user = {} as User;
  }

  ngOnInit(): void {

    this.authService.Logout();
  }

  Login(isValid: boolean) {

    console.log(this.user);

    if (isValid) {

      this.authService.Login(this.user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

        console.log(result);

        if (result) {

          localStorage.removeItem("token");
          localStorage.clear();
          localStorage.setItem('token', result);
          this.alertService.Success("Login Successful!!", "Yay!!", true);
          this.route.navigate(['/home']);

        } else {

          console.log("Login Failed!");
          this.alertService.Error("Please try again!!", "Login failed!!", true);
        }

      },
      error => {

        console.log("login server error:", error);
        this.alertService.Error("Please try again!!", "Login failed!!", true);
      },
      () => console.log('yay'));
    }
  }
}
