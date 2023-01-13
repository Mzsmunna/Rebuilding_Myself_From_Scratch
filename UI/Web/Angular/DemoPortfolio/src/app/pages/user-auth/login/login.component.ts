import { Component, OnDestroy, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { AuthService } from '../../../services/auth/auth.service';
import { AlertService } from '../../../services/common/alert/alert.service';
import { UnsubscribeService } from '../../../services/common/unsubscribe/unsubscribe.service';
import { User } from '../../../view_models/auth/user.model';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends UnsubscribeService implements OnInit, OnDestroy {

  user: User;
  clientId: string = '729270420162-eqgm0blm2u34lgu9m9ck0b6cq6q47oi3.apps.googleusercontent.com';


  constructor(private authService: AuthService, private alertService: AlertService, private route: Router, private ngZone: NgZone) {

    super();
    this.user = {} as User;
  }

  ngOnInit(): void {

    this.authService.Logout();

    (window as any).onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: this.clientId,
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      // @ts-ignore
      google.accounts.id.renderButton(
        // @ts-ignore
        document.getElementById("googleSignIn"),
        { theme: "outline", size: "large", width: "100%" }
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => { });
    };
  }

  async handleCredentialResponse(response: CredentialResponse) {
    //debugger;
    await this.authService.LoginWithGoogle(response.credential).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

      console.log(result);

      if (result) {

        localStorage.removeItem("token");
        localStorage.clear();
        localStorage.setItem('token', result);
        this.alertService.Success("Login Successful!!", "Yay!!", true);

        this.ngZone.run(() => {
          this.route.navigate(['/home']);
        })

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
