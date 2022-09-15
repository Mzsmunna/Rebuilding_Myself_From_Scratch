import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';

@Component({
  selector: 'app-default-nav-bar',
  templateUrl: './default-nav-bar.component.html',
  styleUrls: ['./default-nav-bar.component.css']
})
export class DefaultNavBarComponent implements OnInit {

  isAuthenticated = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }

  ngOnChanges() {
    //console.log(`ngOnChanges: Nav-Bar`);
  }

  ngDoCheck() {

    //console.log(`ngDoCheck: Nav-Bar`);
    this.isAuthenticated = this.authService.IsAuthenticated();
  }

  Logout() {

    this.authService.Logout();
  }

}
