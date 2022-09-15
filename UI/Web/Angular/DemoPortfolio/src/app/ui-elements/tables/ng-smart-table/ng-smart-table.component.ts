import { Component, OnInit } from '@angular/core';
import { LocalDataSource, ServerDataSource } from 'ng2-smart-table';

@Component({
  selector: 'app-ng-smart-table',
  templateUrl: './ng-smart-table.component.html',
  styleUrls: ['./ng-smart-table.component.css']
})
export class NgSmartTableComponent implements OnInit {

  public settings = {
    columns: {
      id: {
        title: 'ID',
        filter: false,
        editable: false,
        addable: false
      },
      name: {
        title: 'Full Name'
      },
      username: {
        title: 'User Name'
      },
      email: {
        title: 'Email'
      }
    }
  };

  data = [
    {
      id: 1,
      name: "Leanne Graham",
      username: "Bret",
      email: "Sincere@april.biz"
    },
    {
      id: 2,
      name: "Ervin Howell",
      username: "Antonette",
      email: "Shanna@melissa.tv"
    },

    // ... list of items

    {
      id: 11,
      name: "Nicholas DuBuque",
      username: "Nicholas.Stanton",
      email: "Rey.Padberg@rosamond.biz"
    }
  ];

  constructor() {


  }

  ngOnInit(): void {
  }

}
