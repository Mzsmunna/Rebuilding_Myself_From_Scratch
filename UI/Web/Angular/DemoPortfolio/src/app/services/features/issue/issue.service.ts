import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/Issue/";
  }

  GetAllIssues() {

    return this.http.get(this.baseApiUrl + 'GetAllIssues');
  }
}
