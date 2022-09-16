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
  //  //mode: 'external',
  //  pager: {
  //    display: true,
  //    perPage: 10
  //  },
  //  actions: {
  //    columnTitle: 'Actions',
  //    add: true,
  //    edit: true,
  //    delete: true,
  //    position: 'right'
  //  },
  //  attr: {
  //    class: 'table table-striped table-bordered table-hover'
  //  },
  //  defaultStyle: false,
  //  add: {
  //    addButtonContent: '<i class="fa-solid fa-square-plus"></i>',
  //    createButtonContent: '<i class="fa-solid fa-square-check"></i>',
  //    cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
  //    confirmCreate: true,
  //  },
  //  edit: {
  //    editButtonContent: '<i class="fa-solid fa-pen-to-square"></i>',
  //    saveButtonContent: '<i class="fa-solid fa-square-check"></i>',
  //    cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
  //    confirmSave: true,
  //  },
  //  delete: {
  //    deleteButtonContent: '<i class="fa-solid fa-trash-can"></i>',
  //    saveButtonContent: '<i class="fa-solid fa-square-check"></i>',
  //    cancelButtonContent: '<i class="fa-solid fa-rectangle-xmark"></i>',
  //    confirmDelete: true,
  //  },
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
  //    },
  //    //avatar: {
  //    //  title: 'Profile Image',
  //    //  type: 'html',
  //    //  valuePrepareFunction: (photo: string) => { return ``; },
  //    //  filter: false
  //    //},
  //    //airline_name: {
  //    //  title: 'Airline Name',
  //    //  valuePrepareFunction: (idx, air) => {
  //    //    return `${air.airline[0].name}`;
  //    //  },
  //    //},
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

  Create(event: any) {
    console.log("Create Event In Console")
    console.log(event);
  }

  Update(event: any) {
    console.log("Edit Event In Console")
    console.log(event);
  }

  Delete(event: any) {
    console.log("Delete Event In Console")
    console.log(event);
    //if (window.confirm('Are you sure you want to delete?')) {
    //  event.confirm.resolve();
    //} else {
    //  event.confirm.reject();
    //}
  }

}
