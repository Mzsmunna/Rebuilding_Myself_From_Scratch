import { Component, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges } from '@angular/core';
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

  source: LocalDataSource = new LocalDataSource();

  constructor() {

    this.data = [];
  }

  //Custom Pagination
  totalData: number = 100;
  currentData: number = 0;
  currentDataStartRange: number = 0;
  currentDataEndRange: number = 0;
  currentPage: number = 1;
  totalPage: number = 10;
  pageSize: number = 10;

  onPageChange(isNext: boolean) {

    if (isNext)
      this.currentPage++;
    else
      this.currentPage--;
    
    this.updatePagination();
  }

  updatePagination(): void {

    if (this.data.length > 0) {

      this.currentDataEndRange = (this.data.length < this.pageSize) ? ((this.currentPage - 1) * this.pageSize) + this.data.length : this.pageSize * this.currentPage;
      this.currentDataStartRange = (this.pageSize * this.currentPage) - this.pageSize + 1;

    } else {

      this.currentDataEndRange = 0;
      this.currentDataStartRange = 0;
    }
    
  }

  //End Custom Pagination

  ngOnInit(): void {

    this.updatePagination();

    //this.source.load(this.data);
    //this.pageSize = this.settings.pager.perPage;
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-ng-smart-table`);

    if (changes) {

      console.log(changes);
      //  console.log("app-ng-smart-table : updated data");
      //  console.log(changes['data']['currentValue']);
      //  this.data = changes['data']['currentValue'];
      //console.log(this.data);

      const currentItem: SimpleChange = changes["data"];
      console.log('prev value: ', currentItem.previousValue);
      console.log('got item: ', currentItem.currentValue);
      this.data = changes['data']['currentValue'];
      this.source.empty();
      this.source.refresh();
      //this.source.load(this.data);
    }  

    this.source.load(this.data);
    this.pageSize = this.settings.pager.perPage;

    this.updatePagination();
    
    //this.source.setPaging(2, 10);

    this.source.onChanged().subscribe((change: any) => {

      console.log(`ng2TableOnChanges: `);
      console.log(change);

      //if (change.action === 'filter' && !_.isEmpty(change.elements)) {

      //  let filters = _.compact(_.pluck(change.filter.filters, 'search'));
      //  let filterRows = change.elements;
      //  let totalRows = this.tables[this.selectedTableId].rows;

      //  if (_.isEmpty(filters)) {
      //    // There is no filters, it means filters were deleted, so dont do any 
      //    return;
      //  }

      //  // Do whatever you want with the filter event

      //}

      //  if (change.action === 'page') {

      //    console.log(change.action);
      //    console.log(change.paging.page);
      //    this.currentPage = change.paging.page;
      //  }

      //});

    });
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

  Create(event: any) {

    this.CreateEvent.emit(event);
    this.updatePagination();
  }

  Update(event: any) {

    this.UpdateEvent.emit(event);
    this.updatePagination();
  }

  Delete(event: any) {

    this.DeleteEvent.emit(event);
    this.updatePagination();

    //if (window.confirm('Are you sure you want to delete?')) {
    //  event.confirm.resolve();
    //} else {
    //  event.confirm.reject();
    //}
  }

  onChange(event: any) {

    console.log(event);

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
