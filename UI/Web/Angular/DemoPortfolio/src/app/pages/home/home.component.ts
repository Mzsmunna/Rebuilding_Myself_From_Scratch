import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { IssueService } from '../../services/features/issue/issue.service';
import { UserService } from '../../services/features/user/user.service';
import { User } from '../../view_models/auth/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public usersList;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService) {

    this.usersList = [] as User[];
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

      this.usersList = result as User[];

    });
  }

  GetAllIssues() {

    this.issueService.GetAllIssues().subscribe(result => {

      console.log(result);

    });
  }

  //Ng2 Smart Table Settings

  public NgSmartTableSettings = {

    columns: {

      firstName: {
        title: 'First Name'
      },
      lastName: {
        title: 'Last Name'
      },
      gender: {
        title: 'Gender'
      },
      birthDate: {
        title: 'Birth Date'
      },
      age: {
        title: 'Age'
      },
      email: {
        title: 'Email'
      },
      role: {
        title: 'Role',
        filter: false,
        editable: false,
        addable: false
      }
    }
  };
}
