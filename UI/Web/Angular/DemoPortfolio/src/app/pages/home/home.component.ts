import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { IssueService } from '../../services/features/issue/issue.service';
import { UserService } from '../../services/features/user/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService) {

  }

  ngOnInit(): void {

    this.GetToken();
    this.GetAllUsers();
    this.GetAllIssues();
  }

  GetToken() {

    let token = this.authService.GetToken();

    console.log("Token from Home :" + token);
  }

  GetAllUsers() {

    this.userService.GetAllUsers().subscribe(result => {

        console.log(result);

      });
  }

  GetAllIssues() {

    this.issueService.GetAllIssues().subscribe(result => {

      console.log(result);

    });
  }
}
