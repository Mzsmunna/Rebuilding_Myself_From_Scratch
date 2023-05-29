import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { AssignUser, User } from '../../../view_models/auth/user.model';
import { SearchField } from '../../../view_models/search-field.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl: string = '';

  selectedProfile$: Subject<User>;

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7221/api/User/"; //"https://localhost:7074/api/User/"

    this.selectedProfile$ = new Subject<User>();
  }

  SyncSelectedUser(user: User) {

    this.selectedProfile$.next(user);
  }

  GetAllUserCount(searchQueries: SearchField[]): Observable<number> {

    return this.http.get(this.baseApiUrl + "GetAllUserCount?searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<number>;
  }

  GetAllUsers(currentPage: number, pageSize: number, sortField: string, sortDirection: string, searchQueries: SearchField[]): Observable<User[]> {

    return this.http.get(this.baseApiUrl + "GetAllUsers?currentPage=" + currentPage
      + "&pageSize=" + pageSize
      + "&sortField=" + sortField
      + "&sortDirection=" + sortDirection
      + "&searchQueries=" + encodeURIComponent(JSON.stringify(searchQueries))) as Observable<User[]>;
  }

  GetAllUserToAssign(): Observable<AssignUser[]> {

    return this.http.get(this.baseApiUrl + 'GetAllUserToAssign') as Observable<AssignUser[]>;
  }

  GetUser(userId: string): Observable<User> {

    return this.http.get(this.baseApiUrl + 'GetUser?userId=' + userId) as Observable<User>;
  }

  SaveUser(user: User): Observable<User> {

    return this.http.post(this.baseApiUrl + 'SaveUser', user) as Observable<User>;
  }

  UpdateUser(user: User): Observable<User> {

    return this.http.put(this.baseApiUrl + 'UpdateUser', user) as Observable<User>;
  }

  DeleteUser(user: User): Observable<boolean> {

    return this.http.delete(this.baseApiUrl + 'DeleteUser?userId=' + user.Id) as Observable<boolean>;
  }

  SaveMedia(file: any): Observable<string> {

    return this.http.post(this.baseApiUrl + 'SaveMedia', file) as Observable<string>;
  }

}
