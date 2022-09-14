import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl: string = '';

  constructor(private http: HttpClient) {

    this.baseApiUrl = "https://localhost:7074/api/User/";
  }

  GetAllUsers() {

    return this.http.get(this.baseApiUrl + 'GetAllUsers');
  }

}
