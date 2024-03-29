import { Component, OnDestroy, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { takeUntil } from 'rxjs';
import { Pager } from '../../../helper_models/pager.model';
import { AuthService } from '../../../services/auth/auth.service';
import { UnsubscribeService } from '../../../services/common/unsubscribe/unsubscribe.service';
import { UserService } from '../../../services/features/user/user.service';
import { TableService } from '../../../ui-elements/tables/table.service';
import { AddUserComponent } from '../../../ui-templates/popup-modals/add-user/add-user.component';
import { User } from '../../../view_models/auth/user.model';
import { SearchField } from '../../../view_models/search-field.model';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user-panel.component.css']
})
export class UserPanelComponent extends UnsubscribeService implements OnInit, OnDestroy {

  public newProfile: User;
  public selectedProfile: User;
  public usersList: User[];
  public usersListCount: number = 0;
  public userSearchQueries: SearchField[];

  _searchEmail: string = '';

  get searchEmail() {

    return this._searchEmail;
  }

  set searchEmail(email: string) {

    this._searchEmail = email;

    const found = this.userSearchQueries.find((obj) => {
      return obj.Key === "Email";
    })!;

    found.Value = this._searchEmail;

    this.LoadTable();
  }

  pager: Pager;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private tableService: TableService) {

    super();
    this.newProfile = {} as User;
    this.selectedProfile = {} as User;
    this.usersList = [] as User[];

    this.userSearchQueries = [] as SearchField[];

    //Pagination
    this.pager = this.tableService.GetDefaultPagination();

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
      IsId: false,
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
    this.LoadTable();
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log("User Panel on change:", changes);
  }

  OnAddUser() {

    console.log("On click Add user pop-up modal");
    this.ShowUserDetails(this.newProfile);
  }

  GetToken() {

    let token = this.authService.GetToken();
    console.log("Token from User Page :" + token);
  }

  ShowUserDetails(user: User) {

    this.selectedProfile = user;
    this.userService.SyncSelectedUser(user);
  }

  GetAllUserCount() {

    this.userService.GetAllUserCount(this.userSearchQueries).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

      console.log(result);
      this.usersListCount = result as number;

    });
  }

  GetAllUsers() {

    this.userService.GetAllUsers(0, 10, "FirstName", "ascending", this.userSearchQueries).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

      console.log(result);
      this.usersList = result as User[];

    });
  }

  UpdatePager(event: Pager) {

    if (event) {

      this.pager = event;
      this.pager.IsPageChanged = false;
      this.LoadTable();
    }
  }

  LoadTable() {

    this.pager.IsLoading = true;

    this.userService.GetAllUserCount(this.userSearchQueries).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

      console.log(result);

      this.pager.TotalDataCount = result as number;

      if (this.pager.TotalDataCount >= 0) {

        this.userService.GetAllUsers(this.pager.CurrentPage - 1, this.pager.PageSize, this.pager.SortField, this.pager.SortDirection, this.userSearchQueries).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

          console.log(result);

          this.usersList = result as User[];

          if (this.usersList.length >= 0) {

            this.pager.TotalDataFetch = this.usersList.length;
            this.pager.IsLoading = false;

            this.tableService.SyncPagination(this.pager);           
          }

        });

      }

    });
  }

  OnDetailsClick(user: User, isOpenDetails: boolean ) {


  }

  //Ng2 Smart Table Action event Trigger Methods:

  NgTableOnCreate(event: any) {

    var user = event.newData as User;
    this.userService.SaveUser(user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

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
    this.userService.UpdateUser(user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

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

    this.userService.DeleteUser(user).pipe(takeUntil(this.unsubscribe$)).subscribe(result => {

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
