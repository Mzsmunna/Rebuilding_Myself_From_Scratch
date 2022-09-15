import { Component, Input, OnInit } from '@angular/core';
import { LocalDataSource, ServerDataSource } from 'ng2-smart-table';

@Component({
  selector: 'app-ng-smart-table',
  templateUrl: './ng-smart-table.component.html',
  styleUrls: ['./ng-smart-table.component.css']
})
export class NgSmartTableComponent implements OnInit {

  @Input() data: any;
  @Input() settings: any;

  constructor() {


  }

  //public settings = {

  //  columns: {

  //    firstName: {
  //      title: 'First Name'
  //    },
  //    lastName: {
  //      title: 'Last Name'
  //    },
  //    gender: {
  //      title: 'Gender'
  //    },
  //    birthDate: {
  //      title: 'Birth Date'
  //    },
  //    age: {
  //      title: 'Age'
  //    },
  //    email: {
  //      title: 'Email'
  //    },
  //    role: {
  //      title: 'Role',
  //      filter: false,
  //      editable: false,
  //      addable: false
  //    }
  //  }
  //};
  
  //data = [
  //  {
  //    id: 1,
  //    name: "Leanne Graham",
  //    username: "Bret",
  //    email: "Sincere@april.biz"
  //  },
  //  {
  //    id: 2,
  //    name: "Ervin Howell",
  //    username: "Antonette",
  //    email: "Shanna@melissa.tv"
  //  },

  //  // ... list of items

  //  {
  //    id: 11,
  //    name: "Nicholas DuBuque",
  //    username: "Nicholas.Stanton",
  //    email: "Rey.Padberg@rosamond.biz"
  //  }
  //];

  ngOnInit(): void {

  }

}
