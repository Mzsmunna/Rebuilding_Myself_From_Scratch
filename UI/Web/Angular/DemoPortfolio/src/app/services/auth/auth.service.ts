import { HttpClient, HttpHeaders } from '@angular/common/http';
import jwt_decode, { JwtPayload } from 'jwt-decode'
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../view_models/auth/user.model';
import { AlertService } from '../common/alert/alert.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authApiUrl: string = '';
  private baseApiUrl: string = '';
  private token: string | null = '';
  private userId: string = '';

  constructor(private alertService: AlertService, private http: HttpClient, private route: Router) {

    this.authApiUrl = "http://192.168.1.106:5280/api/Auth/";
    this.baseApiUrl = "http://192.168.1.106:5255/api/User/"; //"https://localhost:7074/api/User/"
  }

  RefreshToken(user: User) {

    return this.http.post(this.authApiUrl + 'GetRefreshToken', user);
  }

  Register(user: User) {

    return this.http.post(this.authApiUrl + 'RegisterWithEmail', user);
  }

  Login(user: User) {

    return this.http.post(this.authApiUrl + 'LoginWithEmail', user, { responseType: 'text' });
  }

  LoginWithGoogle(credentials: string): Observable<string> {
    const header = new HttpHeaders().set('Content-type', 'application/json');
    return this.http.post(this.authApiUrl + "LoginWithGoogle", JSON.stringify(credentials), { headers: header, responseType: 'text' }) as Observable<string>;
  }

  GetLoggedUser() {

    this.userId = this.GetCurrentUserId();
    return this.http.get(this.baseApiUrl + 'GetUser?userId=' + this.userId);
  }

  Logout(): void {

    localStorage.removeItem("token");
    localStorage.clear();
    this.route.navigate(['auth/login']);
  }

  GetToken(): string {

    this.token = localStorage.getItem('token');

    if (this.token) {

      return this.token;

    } else {

      return '';
    }

  }

  GetCurrentUserRole(): string {

    this.token = localStorage.getItem('token');

    if (this.token) {

      var claims = jwt_decode<any>(this.token); //JSON.parse(Buffer.from(this.token.split('.')[1], 'base64').toString());
      return claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] as string;

    } else {

      return '';
    }

  }

  GetCurrentUserId(): string {

    this.token = localStorage.getItem('token');

    if (this.token) {

      var claims = jwt_decode<any>(this.token);
      return claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] as string;

    } else {

      return '';
    }

  }

  IsAuthenticated(): boolean {

    //return localStorage.getItem('token') != null;

    this.token = this.GetToken();

    if (this.token) {

      let claims = jwt_decode<any>(this.token);
      //let expiration = claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration'] as Date;
      let expiration = claims['exp'] as number;
      expiration = expiration * 1000;

      if (Date.now() >= expiration) {

        localStorage.removeItem("token");
        localStorage.clear();
        this.alertService.Info("You have been logged out due to Token expiration", "Token Expired!!", true);
        return false;
      }
      else
        return true;

    } else {

      return false;
    }
  }

  IsAdmin(): boolean {

    var role = this.GetCurrentUserRole() as string;
    //console.log(`role:`, role);

    if (role && role.toLowerCase() != 'user')
      return true;
    else
      return false;
  }
}
