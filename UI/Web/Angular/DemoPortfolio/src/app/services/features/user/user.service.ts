import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../../view_models/auth/user.model';
import { SearchField } from '../../../view_models/search-field.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/User/";
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

}
