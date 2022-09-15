import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../view_models/auth/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseApiUrl: string = '';
  private token: string | null = '';

  constructor(private http: HttpClient, private route: Router) {

    this.baseApiUrl = "https://localhost:7074/api/User/";
  }

  Register(user: User) {

    return this.http.post(this.baseApiUrl + 'Register', user);
  }

  Login(user: User) {

    return this.http.post(this.baseApiUrl + 'Login', user, { responseType: 'text' });
  }

  Logout() {

    //localStorage.removeItem("token");
    localStorage.clear();
    this.route.navigate(['auth/login']);
  }

  RefreshToken(user: User) {

    return this.http.post(this.baseApiUrl + 'RefreshToken', user);
  }

  GetToken() {

    this.token = localStorage.getItem('token');

    if (this.token) {

      return this.token;

    } else {

      return '';
    }
  }

  IsAuthenticated() {

    return localStorage.getItem('token') != null;
  }
}
