import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchField } from '../../../view_models/search-field.model';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/Issue/";
  }

  GetAllIssueCount(searchQueries: SearchField[]) {

    return this.http.get(this.baseApiUrl + "GetAllIssueCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries)));
  }

  GetAllIssues(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]) {

    return this.http.get(this.baseApiUrl + "GetAllIssues?currentPage=" + currentPage + "&pageSize=" + pageSize + "&sortField=" + sortField + "&sortDirection=" + sortDirection + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries)));
  }
}
