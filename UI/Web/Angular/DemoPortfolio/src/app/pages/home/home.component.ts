import { Component, ElementRef, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { FileUploaderService } from '../../services/common/file-uploader/file-uploader.service';
import { IssueService } from '../../services/features/issue/issue.service';
import { UserService } from '../../services/features/user/user.service';
import { TableService } from '../../ui-elements/tables/table.service';
import { User } from '../../view_models/auth/user.model';
import { FileInfo } from '../../view_models/common/file-info.model';
import { IssueProgress, IssueStat } from '../../view_models/issue.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public userTableSettings: any;
  public issueTableSettings: any;

  activeTab: string = "";
  public isAdmin: boolean = false;
  public isUserSelected: boolean = false;
  public isChangingPhoto: boolean = false;
  public loggedUser: User;
  public currentProfile: User;
  fileInfo: FileInfo;
  public userIssueStat: IssueStat[];
  public userIssueProgress: IssueProgress;

  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;

  constructor(private authService: AuthService, private userService: UserService, private issueService: IssueService, private tableService: TableService, private fileUploadService: FileUploaderService, private router: Router, private route: ActivatedRoute) {

    this.loggedUser = {} as User;
    this.fileInfo = {} as FileInfo;
    this.currentProfile = {} as User;
    this.currentProfile.Gender = "male";
    this.currentProfile.Role = "user";

    this.userIssueStat = [] as IssueStat[];
    this.userIssueProgress = {} as IssueProgress;
    this.ResetIssueProgress();

    this.closeModal = {} as ElementRef;

    //User Table Configure:
    this.userTableSettings = this.tableService.GetNgSmartTableDefaultSettings();
    this.userTableSettings.pager.perPage = 5;
    this.userTableSettings.columns = {

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

    //Issue Table Configure:
    this.issueTableSettings = this.tableService.GetNgSmartTableDefaultSettings();
    this.issueTableSettings.pager.perPage = 5;
    this.issueTableSettings.columns = {

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

    this.GetLoggedUser();

    //this.router.events.subscribe((val) => {

    //  console.log("router val: ", val);
    //  console.log("router val navigation end: ", val instanceof NavigationEnd);
    //});

    this.userService.selectedProfile$.subscribe(result => {

      if (result.Id) {

        console.log("selected user:", result);
        this.currentProfile = result;

        this.isChangingPhoto = false;

        if (result.Id.includes(this.loggedUser.Id))
          this.isUserSelected = false;
        else
          this.isUserSelected = true;

        this.GetIssueStatByUserId();
      }

    });

    this.fileUploadService.uploadedFileInfo$.subscribe(result => {

      if (result.Url) {

        console.log("uploaded file:", result);
        this.fileInfo = result;

        if (this.fileInfo.To == "https://localhost:7074/api/User/") {

          if (this.loggedUser.Id == this.currentProfile.Id) {

            this.loggedUser.Img = this.fileInfo.Url;
            this.userService.SaveUser(this.loggedUser).subscribe(result => {

              console.log("saved user with file link: ", result);

              if (result) {

                this.loggedUser = result;
                this.isChangingPhoto = false;

              } else {

                console.log("something went wrong while changing Profile pic: ", this.loggedUser);
              }

            });
          }
        }
      }

    });

    this.issueService.issueReload$.subscribe(result => {

      if (result) {

        console.log("issue reload requested to home: ", result);
        this.GetIssueStatByUserId();
      }

    });
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-home`);

    if (changes) {

      console.log(changes);
    } 
  }

  ngDoCheck() {

    console.log(`ngDoCheck: app-home`);

    const requestedUrl = this.router.url;
    console.log("requestedUrl: ", requestedUrl);

    if (requestedUrl === '/home/issues') {

      this.activeTab = "issues";

    } else if (requestedUrl === '/home/users') {

      this.activeTab = "users";
    }
    else {

      this.activeTab = "";
    }

  }

  ChangePhoto() {

    this.isChangingPhoto = true;
  }

  ResetIssueProgress() {

    this.userIssueProgress = {
      Pending: 0,
      PendingRatio: 0,
      InProgress: 0,
      InProgressRatio: 0,
      Done: 0,
      DoneRatio: 0,
      Discarded: 0,
      DiscardedRatio: 0,
      Total: 0,
      TotalRatio: 100
    };
  }

  UndoSelectedUser() {

    this.isUserSelected = false;
    this.currentProfile = this.loggedUser;
    this.userService.SyncSelectedUser(this.currentProfile);
  }

  SwitchTab(tabName: string): void {

    this.activeTab = tabName;
  }

  GetLoggedUser() {

    this.authService.GetLoggedUser().subscribe(result => {

      console.log("Logged user: ", result);

      const requestedUrl = this.router.url;
      console.log("requestedUrl: ", requestedUrl);

      const routeParam = this.route.snapshot.paramMap.get('home');
      console.log("routeParam: ", routeParam);

      this.loggedUser = result as User;
      this.currentProfile = result as User;

      this.GetIssueStatByUserId();

      if (this.loggedUser.Role.toLowerCase() == "user") {

        this.isAdmin = false;
        this.activeTab = "issues";
        this.router.navigate(['/home/issues']);

      } else {

        this.isAdmin = true;
        
        if (requestedUrl === '/home/issues') {

          //this.activeTab = "issues";
          this.router.navigate([requestedUrl]);

        } else {

          //this.activeTab = "users";
          this.router.navigate(['/home/users']);
        }
          
      }

    });
  }

  GetIssueStatByUserId() {

    this.issueService.GetIssueStatByUserId(this.currentProfile.Id).subscribe(result => {

      console.log("user's issue stats: ", result);

      this.userIssueStat = result;

      this.ResetIssueProgress();

      if (this.userIssueStat && this.userIssueStat.length > 0) {

        var pending = this.GetObjectValueFromList(this.userIssueStat, "Status", "pending");

        if (pending)
          this.userIssueProgress.Pending = pending.Count;

        var inProgress = this.GetObjectValueFromList(this.userIssueStat, "Status", "in-progress");

        if (inProgress)
          this.userIssueProgress.InProgress = inProgress.Count;

        var done = this.GetObjectValueFromList(this.userIssueStat, "Status", "done");

        if (done)
          this.userIssueProgress.Done = done.Count;

        var discarded = this.GetObjectValueFromList(this.userIssueStat, "Status", "discarded");

        if (discarded)
          this.userIssueProgress.Discarded = discarded.Count;

        this.userIssueProgress.Total = this.userIssueProgress.Pending + this.userIssueProgress.InProgress + this.userIssueProgress.Done + this.userIssueProgress.Discarded;
        this.userIssueProgress.PendingRatio = (this.userIssueProgress.Pending / this.userIssueProgress.Total) * this.userIssueProgress.TotalRatio;
        this.userIssueProgress.InProgressRatio = (this.userIssueProgress.InProgress / this.userIssueProgress.Total) * this.userIssueProgress.TotalRatio;
        this.userIssueProgress.DoneRatio = (this.userIssueProgress.Done / this.userIssueProgress.Total) * this.userIssueProgress.TotalRatio;
        this.userIssueProgress.DiscardedRatio = (this.userIssueProgress.Discarded / this.userIssueProgress.Total) * this.userIssueProgress.TotalRatio;

        console.log("IssueProgress: ", this.userIssueProgress)

      } else {


      }

    });
  }

  GetObjectValueFromList(list: Array<any>, key: string, value: string) {

    const found = list.find((obj) => {
      return obj[key] === value;
    })!;

    return found;
  }

  SaveUser(userForm: FormGroup) {

    if (userForm.valid) {

      this.authService.Register(this.currentProfile).subscribe(result => {

        console.log("saved user: ", result);

        if (result) {

          this.closeModal.nativeElement.click();

          userForm.reset();
          this.currentProfile = {} as User;
          this.currentProfile.Gender = "male";
          this.currentProfile.Role = "user";

        } else {

          console.log("something went wrong while saving user: ", this.currentProfile);
        }

      });

    } else {

      console.log("Invalid user info : ", this.currentProfile);
    }
  }

}
