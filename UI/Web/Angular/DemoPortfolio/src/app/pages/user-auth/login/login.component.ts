import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User;

  constructor(private authService: AuthService, private route: Router) {

    this.user = {} as User;
  }

  ngOnInit(): void {

    //localStorage.removeItem("token");
    localStorage.clear();
  }

  Login(isValid: boolean) {

    console.log(this.user);

    if (isValid) {

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
