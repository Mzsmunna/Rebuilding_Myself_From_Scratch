import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../../services/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  private IsAdmin: boolean = false;

  constructor(private authService: AuthService, private route: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.IsAdmin = this.authService.IsAdmin();

    if (!this.IsAdmin)
      this.route.navigate(['/home']);

    return this.IsAdmin;
  }
  
}
