import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Issue, IssueStat } from '../../../view_models/issue.model';
import { SearchField } from '../../../view_models/search-field.model';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  private baseApiUrl: string = '';
  issueReload$: Subject<boolean>;

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/Issue/";
    this.issueReload$ = new Subject<boolean>();
  }

  RequestReload(issue: Issue) {

    if (issue.Id)
      this.issueReload$.next(true);
  }

  GetAllIssueCount(searchQueries: SearchField[]): Observable<number> {

    return this.http.get(this.baseApiUrl + "GetAllIssueCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<number>;
  }

  GetAllIssuesByAssignerCount(searchQueries: SearchField[]): Observable<number> {

    return this.http.get(this.baseApiUrl + "GetAllIssuesByAssignerCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<number>;
  }

  GetAllIssuesByAssignedCount(searchQueries: SearchField[]): Observable<number> {

    return this.http.get(this.baseApiUrl + "GetAllIssuesByAssignedCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<number>;
  }

  GetAllIssues(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]): Observable<Issue[]> {

    return this.http.get(this.baseApiUrl + "GetAllIssues?currentPage=" + currentPage
      + "&pageSize=" + pageSize
      + "&sortField=" + sortField
      + "&sortDirection=" + sortDirection
      + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<Issue[]>;
  }

  GetIssueStatByUserId(userId: string): Observable<IssueStat[]> {

    return this.http.get(this.baseApiUrl + "GetIssueStatByUserId?userId=" + userId) as Observable<IssueStat[]>;
  }

  GetAllIssuesByAssigner(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]): Observable<Issue[]> {

    return this.http.get(this.baseApiUrl + "GetAllIssuesByAssigner?currentPage=" + currentPage
      + "&pageSize=" + pageSize
      + "&sortField=" + sortField
      + "&sortDirection=" + sortDirection
      + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<Issue[]>;
  }

  GetAllIssuesByAssigned(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]): Observable<Issue[]> {

    return this.http.get(this.baseApiUrl + "GetAllIssuesByAssigned?currentPage=" + currentPage
      + "&pageSize=" + pageSize
      + "&sortField=" + sortField
      + "&sortDirection=" + sortDirection
      + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<Issue[]>;
  }

  SaveIssue(issue: Issue): Observable<Issue>  {

    return this.http.post(this.baseApiUrl + 'SaveIssue', issue) as Observable<Issue>;
  }

  DeleteIssue(issue: Issue): Observable<boolean> {

    return this.http.delete(this.baseApiUrl + 'DeleteIssue?issueId=' + issue.Id) as Observable<boolean>;
  }
}
