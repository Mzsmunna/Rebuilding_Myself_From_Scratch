import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';
import { IssueService } from '../../../services/features/issue/issue.service';
import { UserService } from '../../../services/features/user/user.service';
import { NgSmartTableComponent } from '../../../ui-elements/tables/ng-smart-table/ng-smart-table.component';
import { TableService } from '../../../ui-elements/tables/table.service';
import { AddIssueComponent } from '../../../ui-templates/popup-modals/add-issue/add-issue.component';
import { User } from '../../../view_models/auth/user.model';
import { Issue } from '../../../view_models/issue.model';
import { SearchField } from '../../../view_models/search-field.model';

@Component({
  selector: 'app-issue-panel',
  templateUrl: './issue-panel.component.html',
  styleUrls: ['./issue-panel.component.css']
})
export class IssuePanelComponent implements OnInit {

  public loggedUser: User;
  public userSearchQueries: SearchField[];

  activeTab: string = "";
  public isAdmin: boolean = false;

  public issueSearchQueries: SearchField[];
  public issuesList: Issue[];
  public issuesListCount: number = 0;

  @ViewChild(AddIssueComponent) addIssueComponent!: AddIssueComponent;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService) {

    this.loggedUser = {} as User;
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
      Key: (this.isAdmin) ? 'CreatedBy' : 'AssignedId',
      Value: this.authService.GetCurrentUserId(), //"", //this.user.Id,
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

  GetLoggedUser() {

    this.authService.GetLoggedUser().subscribe(result => {

      console.log("Logged user: ", result);

      this.loggedUser = result as User;

      if (this.loggedUser.Role.toLowerCase() == "user") {

        this.isAdmin = false;
        this.activeTab = "issues";

      } else {

        this.isAdmin = true;
        this.activeTab = "users";
      }

    });
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

      //this.addIssueComponent.EnableUpdateMode(this.issuesList[0]);

    });
  }

  UpdateIssueList(event: Issue) {

    if (event) {

      this.GetAllIssuesByAssignedCount();
      this.GetAllIssuesByAssigned();
    }
  }

  OnUpdate(issue: Issue) {

    //pass to adduser component template with view child

  }

  OnDelete(event: any) {

    var issue = event.data as Issue;
    issue.IsDeleted = true;
    issue.Status = 'discarded';

    //pass to adduser component template with view child

  }

  //Ng2 Smart Table Action event Trigger Methods:

  NgTableOnCreate(event: any) {

    var issue = event.newData as Issue;
    this.issueService.SaveIssue(issue).subscribe(result => {

      console.log(result);

      var user = result as Issue;

      if (user) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });

  }

  NgTableOnUpdate(event: any) {

    var issue = event.newData as Issue;
    this.issueService.SaveIssue(issue).subscribe(result => {

      console.log(result);

      var user = result as Issue;

      if (user) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });

  }

  NgTableOnDelete(event: any) {

    var issue = event.data as Issue;
    issue.IsDeleted = true;
    issue.Status = 'discarded';

    this.issueService.SaveIssue(issue).subscribe(result => {

      console.log(result);

      var deletedIssue = result as Issue;

      if (deletedIssue) {

        event.confirm.resolve();

      } else {

        event.confirm.reject();
      }

    });

  }

}
