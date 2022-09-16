import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LocalDataSource, ServerDataSource } from 'ng2-smart-table';

@Component({
  selector: 'app-ng-smart-table',
  templateUrl: './ng-smart-table.component.html',
  styleUrls: ['./ng-smart-table.component.css']
})
export class NgSmartTableComponent implements OnInit {

  @Input() data: any;
  @Input() settings: any;

  @Output() CreateEvent = new EventEmitter<any>();
  @Output() UpdateEvent = new EventEmitter<any>();
  @Output() DeleteEvent = new EventEmitter<any>();

  constructor() {


  }
  
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

    this.CreateEvent.emit(event);
  }

  Update(event: any) {

    this.UpdateEvent.emit(event);
  }

  Delete(event: any) {

    this.DeleteEvent.emit(event);

    //if (window.confirm('Are you sure you want to delete?')) {
    //  event.confirm.resolve();
    //} else {
    //  event.confirm.reject();
    //}
  }

  //source = new ServerDataSource(http,
  //  {
  //    endPoint: 'http:localhost:xxxx/api/endpoint', //full-url-for-endpoint without any query strings 
  //    dataKey: 'data.records' //your-list-path-from-response , 
  //   pagerPageKey: 'page' // your backend endpoint param excpected for page number key, 
  //   pagerLimitKey: 'pageSize, //your backend endpoint param excpected for page size
  //   totalKey: 'data.total', //  total records returned in response path filterFieldKey: your filter keys template should set to '#field#' if you need to send params as you set, Default is '#field#_like' // ignore if no need for filteration 
  //});

}
