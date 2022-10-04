import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';

@Component({
  selector: 'app-default-nav-bar',
  templateUrl: './default-nav-bar.component.html',
  styleUrls: ['./default-nav-bar.component.css']
})
export class DefaultNavBarComponent implements OnInit {

  isAuthenticated = false;
  isAdmin = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }

  ngOnChanges() {
    //console.log(`ngOnChanges: default-nav-bar`);
  }

  ngDoCheck() {

    //console.log(`ngDoCheck: default-nav-bar`);
    this.isAuthenticated = this.authService.IsAuthenticated();
    this.isAdmin = this.authService.IsAdmin();
  }

  Logout() {

    this.authService.Logout();
  }

}
