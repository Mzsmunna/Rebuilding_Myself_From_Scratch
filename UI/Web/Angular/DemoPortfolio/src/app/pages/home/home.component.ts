import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { IssueService } from '../../services/features/issue/issue.service';
import { UserService } from '../../services/features/user/user.service';
import { NgSmartTableComponent } from '../../ui-elements/tables/ng-smart-table/ng-smart-table.component';
import { TableService } from '../../ui-elements/tables/table.service';
import { User } from '../../view_models/auth/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public usersList;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService) {

    this.usersList = [] as User[];

    //Ng2 Smart Table Configure:
    this.NgSmartTableSettings = this.tableService.GetNgSmartTableDefaultSettings();
    this.NgSmartTableSettings.pager.perPage = 2;
    this.NgSmartTableSettings.columns = {

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
      },
      //avatar: {
      //  title: 'Profile Image',
      //  type: 'html',
      //  valuePrepareFunction: (photo: string) => { return ``; },
      //  filter: false
      //},
      //airline_name: {
      //  title: 'Airline Name',
      //  valuePrepareFunction: (idx, air) => {
      //    return `${air.airline[0].name}`;
      //  },
      //},
    }
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

  //Ng2 Smart Table Action event Trigger Methods:

  NgTableOnCreate(event: any) {

    console.log("Create Event Triggered:");
    console.log(event);
    console.log("Data:");
    console.log(event.newData);

    event.confirm.resolve();
    //event.confirm.reject();
  }

  NgTableOnUpdate(event: any) {

    console.log("Update Event Triggered:");
    console.log(event);
    console.log("Data:");
    console.log(event.newData);

    event.confirm.resolve();
    //event.confirm.reject();
  }

  NgTableOnDelete(event: any) {

    console.log("Delete Event Triggered:");
    console.log(event);
    console.log("Data:");
    console.log(event.data);

    event.confirm.resolve();
    //event.confirm.reject();
  }
}
