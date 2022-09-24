import { Component, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Pager } from '../../../helper_models/pager.model';
import { AuthService } from '../../../services/auth/auth.service';
import { UserService } from '../../../services/features/user/user.service';
import { TableService } from '../../../ui-elements/tables/table.service';
import { User } from '../../../view_models/auth/user.model';
import { SearchField } from '../../../view_models/search-field.model';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user-panel.component.css']
})
export class UserPanelComponent implements OnInit {

  public usersList: User[];
  public usersListCount: number = 0;
  public userSearchQueries: SearchField[];

  pager: Pager;

  public NgSmartTableSettings: any;

  constructor(private authService: AuthService, private userService: UserService, private tableService: TableService) {

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
    //this.GetAllUserCount();
    //this.GetAllUsers();
    this.LoadTable();

    //this.tableService.paginationEmitter.subscribe(result => {

    //  //console.log("current pager user:", result);
    //  this.pager = result;

    //  if (this.pager.IsPageChanged) {

    //    this.pager.IsPageChanged = false;

    //    this.LoadTable();
    //  }

    //});
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log("User Page on chnage:");

    //if (changes.name != undefined) {
    //  this.name = changes.name.currentValue
    //}
  }

  GetToken() {

    let token = this.authService.GetToken();

    console.log("Token from User Page :" + token);
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

  UpdatePager(event: Pager) {

    if (event) {

      this.pager = event;
      this.pager.IsPageChanged = false;
      this.LoadTable();
    }
  }

  LoadTable() {

    this.pager.IsLoading = true;

    this.userService.GetAllUserCount(this.userSearchQueries).subscribe(result => {

      console.log(result);

      this.pager.TotalDataCount = result as number;

      if (this.pager.TotalDataCount >= 0) {

        this.userService.GetAllUsers(this.pager.CurrentPage - 1, this.pager.PageSize, this.pager.SortField, this.pager.SortDirection, this.userSearchQueries).subscribe(result => {

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
