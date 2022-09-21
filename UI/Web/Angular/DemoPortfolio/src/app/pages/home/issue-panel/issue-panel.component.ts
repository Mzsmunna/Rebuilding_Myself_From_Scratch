import { Component, OnInit, ViewChild } from '@angular/core';
import { Pager } from '../../../helper_models/pager.model';
import { AuthService } from '../../../services/auth/auth.service';
import { IssueService } from '../../../services/features/issue/issue.service';
import { UserService } from '../../../services/features/user/user.service';
import { DefaultPaginationComponent } from '../../../ui-elements/paginations/default-pagination/default-pagination.component';
import { NgSmartTableComponent } from '../../../ui-elements/tables/ng-smart-table/ng-smart-table.component';
import { TableService } from '../../../ui-elements/tables/table.service';
import { AddIssueComponent } from '../../../ui-templates/popup-modals/add-issue/add-issue.component';
import { AssignUser, User } from '../../../view_models/auth/user.model';
import { Issue } from '../../../view_models/issue.model';
import { SearchField } from '../../../view_models/search-field.model';

@Component({
  selector: 'app-issue-panel',
  templateUrl: './issue-panel.component.html',
  styleUrls: ['./issue-panel.component.css']
})
export class IssuePanelComponent implements OnInit {

  public loggedUser: User;
  public assignUserList: AssignUser[];
  public userSearchQueries: SearchField[];

  activeTab: string = "";
  issueFilterType: string = "";
  public isAdmin: boolean = false;

  public issueSearchQueries: SearchField[];
  public issuesList: Issue[];
  //public issuesListCount: number = 0;

  pager: Pager;

  @ViewChild(AddIssueComponent) addIssueComponent!: AddIssueComponent;
  @ViewChild(DefaultPaginationComponent) defaultPaginationComponent!: DefaultPaginationComponent;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService) {

    this.loggedUser = {} as User;
    this.assignUserList = [] as AssignUser[];
    this.issuesList = [] as Issue[];

    this.userSearchQueries = [] as SearchField[];
    this.issueSearchQueries = [] as SearchField[];

    //Pagination
    this.pager = {

      TotalDataCount: 0,
      TotalDataFetch: 0,
      CurrentData: 0,
      CurrentDataStartRange: 0,
      CurrentDataEndRange: 0,
      CurrentPage: 1,
      TotalPage: 1,
      PageSize: 2,
      SortField: "CreatedOn",
      SortDirection: 'Descending',
      IsLoading: true

    };

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

    this.isAdmin = this.authService.IsAdmin();
    this.GetLoggedUser();

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
      },
      {
        Key: 'Type',
        Value: this.issueFilterType,
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
      }
    );

    this.GetToken();

    //this.GetAllIssuesByAssignedCount();
    //this.GetAllIssuesByAssigned();

    this.LoadTable();
  }

  FilterIssueType(issueType: string) {

    this.issueFilterType = issueType;

    const first = this.issueSearchQueries.find((obj) => {
      return obj.Key === "Type";
    })!;

    first.Value = this.issueFilterType;

    this.UpdateTable();
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

  GetAllUserToAssign() {

    this.userService.GetAllUserToAssign().subscribe(result => {

      console.log(result);

      this.assignUserList = result as AssignUser[];

    });
  }

  GetAllIssuesByAssignedCount() {

    //this.issueService.GetAllIssuesByAssignedCount(this.issueSearchQueries).subscribe(result => {
    this.issueService.GetAllIssueCount(this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.pager.TotalDataCount = result as number;

    });
  }

  GetAllIssuesByAssigned() {

    //this.issueService.GetAllIssuesByAssigned(0, 10, "Title", "ascending", this.issueSearchQueries).subscribe(result => {
    this.issueService.GetAllIssues(0, 10, "Title", "ascending", this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.issuesList = result as Issue[];
    });
  }

  LoadTable() {

    this.pager.IsLoading = true;

    this.issueService.GetAllIssueCount(this.issueSearchQueries).subscribe(result => {

      console.log(result);

      this.pager.TotalDataCount = result as number;

      if (this.pager.TotalDataCount >= 0) {

        this.issueService.GetAllIssues(this.pager.CurrentPage - 1, this.pager.PageSize, this.pager.SortField, this.pager.SortDirection, this.issueSearchQueries).subscribe(result => {

          console.log(result);

          this.issuesList = result as Issue[];

          if (this.issuesList.length >= 0) {

            this.pager.TotalDataFetch = this.issuesList.length;
            this.pager.IsLoading = false;

            this.defaultPaginationComponent.syncPagination(this.pager);
          }

        });

      }

    });
  }

  UpdateIssueList(event: Issue) {

    if (event) {

      this.UpdateTable();
    }
  }

  UpdatePager(event: Pager) {

    if (event) {

      this.pager = event;
      this.UpdateTable();
    }
  }

  UpdateTable() {

    //this.GetAllIssuesByAssignedCount();
    //this.GetAllIssuesByAssigned();

    this.LoadTable();
  }

  OnStatusChange(issue: Issue, event: any) {

    issue.Status = event.target.value;
    console.log("Issue status updated :", issue.Status);
    this.issueService.SaveIssue(issue).subscribe(result => {

      console.log(result);
      //this.UpdateIssueList(result);

    });
  }

  OnUpdate(issue: Issue) {

    //pass to adduser component template with view child
    this.addIssueComponent.EnableUpdateMode(issue);
  }

  OnDelete(issue: Issue) {

    if (!issue.IsCompleted) {

      this.issueService.DeleteIssue(issue).subscribe(result => {

        console.log(result);
        this.UpdateIssueList(issue);

      });
    }

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
