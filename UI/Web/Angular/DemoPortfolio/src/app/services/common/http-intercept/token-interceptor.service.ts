import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  private token: string | null = '';

  constructor() {
    
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.token = localStorage.getItem('token');
    //console.log("Token from HttpInterceptor :" + this.token);

    if (this.token) {

      req = req.clone({
        setHeaders: {
          Authorization: 'bearer ' + this.token
        }
      });

    }

    return next.handle(req);
  }
}
