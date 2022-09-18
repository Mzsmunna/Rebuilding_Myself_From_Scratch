import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { IssueService } from '../../services/features/issue/issue.service';
import { UserService } from '../../services/features/user/user.service';
import { NgSmartTableComponent } from '../../ui-elements/tables/ng-smart-table/ng-smart-table.component';
import { TableService } from '../../ui-elements/tables/table.service';
import { User } from '../../view_models/auth/user.model';
import { Issue } from '../../view_models/issue.model';
import { SearchField } from '../../view_models/search-field.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public usersList: User[];
  public usersListCount: number = 0;
  public userSearchQueries: SearchField[];

  public issueSearchQueries: SearchField[];
  public issuesList: Issue[];
  public issuesListCount: number = 0;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService) {

    this.usersList = [] as User[];
    this.issuesList = [] as Issue[];

    this.userSearchQueries = [] as SearchField[];
    this.issueSearchQueries = [] as SearchField[];

    //Ng2 Smart Table Configure:
    this.NgSmartTableSettings = this.tableService.GetNgSmartTableDefaultSettings();
    this.NgSmartTableSettings.pager.perPage = 5;
    this.NgSmartTableSettings.columns = {

      FirstName: {
        title: 'First Name'
      },
      LastName: {
        title: 'Last Name'
      },
      Gender: {
        title: 'Gender'
      },
      BirthDate: {
        title: 'Birth Date'
      },
      Age: {
        title: 'Age'
      },
      Email: {
        title: 'Email'
      },
      Role: {
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

    this.userSearchQueries.push({
      Key: 'Email',
      Value: '',
      DataType: 'string',
      DataSeparator: '',
      IsString: true,
      IsCaseSensitive: false,
      IsPartialMatch: true,
      IsBoolean: false,
      IsDateTime: false,
      IsAndQuery: true,
      IsEncrypted: false,
      QueryOrder: 1
    });

    this.issueSearchQueries.push({
      Key: 'Summary',
      Value: 'Learn',
      DataType: 'string',
      DataSeparator: '',
      IsString: true,
      IsCaseSensitive: false,
      IsPartialMatch: true,
      IsBoolean: false,
      IsDateTime: false,
      IsAndQuery: true,
      IsEncrypted: false,
      QueryOrder: 1
    });

    this.GetToken();
    this.GetAllUserCount();
    this.GetAllUsers();
    this.GetAllIssueCount();
    this.GetAllIssues();
  }

  GetToken() {

    let token = this.authService.GetToken();

    console.log("Token from Home Page :" + token);
  }

  GetAllUserCount() {

    this.userService.GetAllUserCount(this.userSearchQueries).subscribe(result => {

      console.log(result);

      this.usersListCount = result as number;

    });
  }

  GetAllUsers() {

    this.userService.GetAllUsers(0, 10, "FirstName", "ascending", this.userSearchQueries).subscribe(result => {

      console.log(result);

      this.usersList = result as User[];

      //let timer = setTimeout(() => {

      //  this.usersList.pop();

      //  console.log("updated users");
      //  console.log(this.usersList);

      //}, 5000);

    });
  }

  GetAllIssueCount() {

    this.issueService.GetAllIssueCount(this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.issuesListCount = result as number;

    });
  }

  GetAllIssues() {

    this.issueService.GetAllIssues(0, 10, "Title", "ascending", this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.issuesList = result as Issue[];

    });
  }

  //Ng2 Smart Table Action event Trigger Methods:

  NgTableOnCreate(event: any) {

    var user = event.newData as User;
    this.userService.SaveUser(user).subscribe(result => {

      console.log(result);

      var user = result as User;

      if (user) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });
    
  }

  NgTableOnUpdate(event: any) {

    var user = event.newData as User;
    this.userService.UpdateUser(user).subscribe(result => {

      console.log(result);

      var user = result as User;

      if (user) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });

  }

  NgTableOnDelete(event: any) {

    var user = event.data as User;

    //this.usersList.forEach((value, index) => {
    //  if (value.Id == event.data.Id) this.usersList.splice(index, 1);
    //});

    this.userService.DeleteUser(user).subscribe(result => {

      console.log(result);

      var isDeleted = result as boolean;

      if (isDeleted) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });

  }
}
