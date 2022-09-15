import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../../services/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UnAuthGuard implements CanActivate {

  private IsUnthenticated: boolean = true;

  constructor(private authService: AuthService, private route: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    this.IsUnthenticated = !this.authService.IsAuthenticated();

    if (!this.IsUnthenticated)
      this.route.navigate(['/home']);

    return this.IsUnthenticated;
  }
  
}
