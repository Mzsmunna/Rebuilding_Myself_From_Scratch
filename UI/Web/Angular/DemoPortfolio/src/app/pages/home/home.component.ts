import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { TableService } from '../../ui-elements/tables/table.service';
import { User } from '../../view_models/auth/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public userTableSettings: any;
  public issueTableSettings: any;

  activeTab: string = "";
  loggedUserRole: string = "";
  public loggedUser: User;
  public newUser: User;

  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;

  constructor(private authService: AuthService, private tableService: TableService, private route: Router) {

    this.loggedUser = {} as User;
    this.newUser = {} as User;
    this.newUser.Gender = "male";
    this.newUser.Role = "user";

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
  }

  SwitchTab(tabName: string): void {

    this.activeTab = tabName;
  }

  GetLoggedUser() {

    this.authService.GetLoggedUser().subscribe(result => {

      console.log("Logged user: ", result);

      this.loggedUser = result as User;
      this.loggedUserRole = this.loggedUser.Role.toLowerCase();

      if (this.loggedUser.Role.toLowerCase() == "user") {

        this.activeTab = "issues";
        this.route.navigate(['/home/issues']);

      } else {

        this.activeTab = "users";
        this.route.navigate(['/home/users']);
      }

    });
  }

  SaveUser(userForm: FormGroup) {

    if (userForm.valid) {

      this.authService.Register(this.newUser).subscribe(result => {

        console.log("saved user: ", result);

        if (result) {

          this.closeModal.nativeElement.click();

          userForm.reset();
          this.newUser = {} as User;
          this.newUser.Gender = "male";
          this.newUser.Role = "user";

        } else {

          console.log("something went wrong while saving user: ", this.newUser);
        }

      });

    } else {

      console.log("Invalid user info : ", this.newUser);
    }
  }

}
