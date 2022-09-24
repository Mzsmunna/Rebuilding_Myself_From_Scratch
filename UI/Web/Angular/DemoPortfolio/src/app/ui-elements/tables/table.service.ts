import { EventEmitter, Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Pager } from '../../helper_models/pager.model';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  private NgSmartTableSettings: any;
  private pager: Pager;
  paginationEmitter: EventEmitter<Pager>;
  //paginationEmitter: Subject<Pager>;

  constructor() {

    this.pager = {} as Pager;

    this.paginationEmitter =  new EventEmitter<Pager>();
    //this.paginationEmitter =  new Subject<Pager>();
  }

  GetDefaultPagination(): Pager {

    return this.pager = {

      TotalDataCount: 0,
      TotalDataFetch: 0,
      CurrentData: 0,
      CurrentDataStartRange: 0,
      CurrentDataEndRange: 0,
      CurrentPage: 1,
      TotalPage: 1,
      PageSize: 5,
      SortField: "CreatedOn",
      SortDirection: 'Descending',
      IsLoading: true,
      IsPageChanged: false,
    };
  }

  SyncPagination(pager: Pager) {

    this.paginationEmitter.emit(pager);
    //this.paginationEmitter.next(pager);
  }

  GetNgSmartTableDefaultSettings() {

    this.NgSmartTableSettings = {
      //mode: 'external',
      pager: {
        display: false,
        perPage: 20
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
      }
    };

    return this.NgSmartTableSettings;
  }
}
