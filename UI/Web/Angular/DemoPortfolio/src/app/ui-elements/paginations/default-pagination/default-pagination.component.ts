import { Component, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { Stream } from 'stream';
import { Pager } from '../../../helper_models/pager.model';

@Component({
  selector: 'app-default-pagination',
  templateUrl: './default-pagination.component.html',
  styleUrls: ['./default-pagination.component.css']
})
export class DefaultPaginationComponent implements OnInit {

  @Input() pager: Pager;
  @Output() UpdatePager = new EventEmitter<Pager>();

  constructor() {

    this.pager = {} as Pager;
  }

  syncPagination(pager: Pager): void {

    this.pager = pager;

    this.updatePagination();
  }

  onPageChange(isNext: boolean) {

    if (isNext)
      this.pager.CurrentPage++;
    else
      this.pager.CurrentPage--;

    this.updatePagination();

    this.UpdatePager.emit(this.pager);
  }

  updatePagination(): void {

    this.pager.TotalPage = Math.ceil(this.pager.TotalDataCount / this.pager.PageSize);

    if (this.pager.TotalDataFetch > 0) {

      this.pager.CurrentDataEndRange = (this.pager.TotalDataFetch < this.pager.PageSize) ? ((this.pager.CurrentPage - 1) * this.pager.PageSize) + this.pager.TotalDataFetch : this.pager.PageSize * this.pager.CurrentPage;
      this.pager.CurrentDataStartRange = (this.pager.PageSize * this.pager.CurrentPage) - this.pager.PageSize + 1;

    } else {

      this.pager.CurrentDataEndRange = 0;
      this.pager.CurrentDataStartRange = 0;
    }

  }

  ngOnInit(): void {

    this.updatePagination();
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: default-pagination`);

    if (changes) {

      console.log(changes);
      //  console.log("app-ng-smart-table : updated data");
      //  console.log(changes['data']['currentValue']);
      //  this.data = changes['data']['currentValue'];
      //console.log(this.data);

      //const currentItem: SimpleChange = changes["data"];
      //console.log('prev value: ', currentItem.previousValue);
      //console.log('got item: ', currentItem.currentValue);
    }

  }

}
