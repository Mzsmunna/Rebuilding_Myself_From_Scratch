import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  private NgSmartTableSettings: any;

  constructor() {

  }

  GetNgSmartTableDefaultSettings() {

    this.NgSmartTableSettings = {
      //mode: 'external',
      pager: {
        display: false,
        //perPage: 20
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
