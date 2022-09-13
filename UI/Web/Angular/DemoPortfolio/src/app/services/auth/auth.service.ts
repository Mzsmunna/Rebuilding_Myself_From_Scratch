import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../../view_models/auth/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/User/";
  }

  Login(user: User) {

    return this.http.post(this.baseApiUrl + 'Login', user, { responseType: 'text' });
  }

  Register(user: User) {

    return this.http.post(this.baseApiUrl + 'Register', user);
  }

  RefreshToken(user: User) {

    return this.http.post(this.baseApiUrl + 'RefreshToken', user);
  }
}
