import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchField } from '../../../view_models/search-field.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/User/";
  }

  GetAllUserCount(searchQueries: SearchField[]) {

    return this.http.get(this.baseApiUrl + "GetAllUserCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries)));
  }

  GetAllUsers(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]) {

    return this.http.get(this.baseApiUrl + "GetAllUsers?currentPage=" + currentPage + "&pageSize=" + pageSize + "&sortField=" + sortField + "&sortDirection=" + sortDirection + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries)));
  }

}
