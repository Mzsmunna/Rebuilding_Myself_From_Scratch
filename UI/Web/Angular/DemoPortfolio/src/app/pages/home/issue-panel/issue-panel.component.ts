import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';
import { IssueService } from '../../../services/features/issue/issue.service';
import { UserService } from '../../../services/features/user/user.service';
import { NgSmartTableComponent } from '../../../ui-elements/tables/ng-smart-table/ng-smart-table.component';
import { TableService } from '../../../ui-elements/tables/table.service';
import { User } from '../../../view_models/auth/user.model';
import { Issue } from '../../../view_models/issue.model';
import { SearchField } from '../../../view_models/search-field.model';

@Component({
  selector: 'app-issue-panel',
  templateUrl: './issue-panel.component.html',
  styleUrls: ['./issue-panel.component.css']
})
export class IssuePanelComponent implements OnInit {

  public user: User;
  public userSearchQueries: SearchField[];

  public issueSearchQueries: SearchField[];
  public issuesList: Issue[];
  public issuesListCount: number = 0;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService) {

    this.user = {} as User;
    this.issuesList = [] as Issue[];

    this.userSearchQueries = [] as SearchField[];
    this.issueSearchQueries = [] as SearchField[];

    //Ng2 Smart Table Configure:
    this.NgSmartTableSettings = this.tableService.GetNgSmartTableDefaultSettings();
    this.NgSmartTableSettings.pager.perPage = 5;
    this.NgSmartTableSettings.columns = {

      ProjectId: {
        title: 'Project Name'
      },
      Title: {
        title: 'Title'
      },
      Type: {
        title: 'Type'
      },
      Summary: {
        title: 'Summary'
      },
      Description: {
        title: 'Description'
      },
      AssignerName: {
        title: 'AssignerName'
      },
      StartDate: {
        title: 'StartDate'
      },
      EndDate: {
        title: 'EndDate'
      },
      DueDate: {
        title: 'DueDate'
      },
      Status: {
        title: 'Status',
        filter: false,
        editable: false,
        addable: false
      },
      Comment: {
        title: 'Comment'
      },
      CreatedOn: {
        title: 'CreatedOn'
      },
      ModifiedOn: {
        title: 'ModifiedOn'
      },
    }
  }

  ngOnInit(): void {

    //this.userSearchQueries.push({
    //  Key: 'Email',
    //  Value: '',
    //  DataType: 'string',
    //  DataSeparator: '',
    //  IsString: true,
    //  IsCaseSensitive: false,
    //  IsPartialMatch: true,
    //  IsBoolean: false,
    //  IsDateTime: false,
    //  IsAndQuery: true,
    //  IsEncrypted: false,
    //  QueryOrder: 1
    //});

    this.issueSearchQueries.push({
      Key: 'AssignerId',
      Value: "631e4ccd511f1f293c9bd842", //this.user.Id,
      DataType: 'string',
      DataSeparator: '',
      IsId: true,
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
    //this.GetAllIssuesByAssignedCount();
    //this.GetAllIssuesByAssigned();
    this.GetAllIssuesByAssignedCount();
    this.GetAllIssuesByAssigned();
  }

  GetToken() {

    let token = this.authService.GetToken();

    console.log("Token from Home Page :" + token);
  }

  GetAllIssuesByAssignedCount() {

    //this.issueService.GetAllIssuesByAssignedCount(this.issueSearchQueries).subscribe(result => {
    this.issueService.GetAllIssueCount(this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.issuesListCount = result as number;

    });
  }

  GetAllIssuesByAssigned() {

    //this.issueService.GetAllIssuesByAssigned(0, 10, "Title", "ascending", this.issueSearchQueries).subscribe(result => {
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
