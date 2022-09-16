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

  showPerPage: number = 2;

  //source = new ServerDataSource(http,
  //  {
  //    endPoint: 'http:localhost:xxxx/api/endpoint', //full-url-for-endpoint without any query strings 
  //    dataKey: 'data.records' //your-list-path-from-response , 
  //   pagerPageKey: 'page' // your backend endpoint param excpected for page number key, 
  //   pagerLimitKey: 'pageSize, //your backend endpoint param excpected for page size
  //   totalKey: 'data.total', //  total records returned in response path filterFieldKey: your filter keys template should set to '#field#' if you need to send params as you set, Default is '#field#_like' // ignore if no need for filteration 
  //});

  public NgSmartTableSettings = {
    //mode: 'external',
    pager: {
      display: true,
      perPage: this.showPerPage
    },
    actions: {
      columnTitle: 'Actions',
      add: true,
      edit: true,
      delete: true,
      position: 'right'
    },
    attr: {
      class: 'table table-striped table-hover'
    },
    defaultStyle: false,
    add: {
      addButtonContent: '<i class="fa-solid fa-square-plus"></i>',
      createButtonContent: '<i class="fa-solid fa-square-check"></i>',
      cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
      confirmCreate: true,
    },
    edit: {
      editButtonContent: '<i class="fa-solid fa-pen-to-square"></i>',
      saveButtonContent: '<i class="fa-solid fa-square-check"></i>',
      cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
      confirmSave: true,
    },
    delete: {
      deleteButtonContent: '<i class="fa-solid fa-trash-can"></i>',
      saveButtonContent: '<i class="fa-solid fa-square-check"></i>',
      cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
      confirmDelete: true,
    },
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
  };
}
