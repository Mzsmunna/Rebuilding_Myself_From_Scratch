import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { FileInfo } from '../../../view_models/common/file-info.model';

@Injectable({
  providedIn: 'root'
})
export class FileUploaderService {

  // API url
  //baseApiUrl = "https://file.io";
  baseApiUrl = "https://localhost:7074/api/User/";
  uploadedFileInfo$: Subject<FileInfo>;

  constructor(private http: HttpClient) {

    this.uploadedFileInfo$ = new Subject<FileInfo>();
  }

  // Returns an observable
  upload(file: any, to: string | null): Observable<any> {

    if (to)
      this.baseApiUrl = to;

    // Create form data
    const formData = new FormData();

    // Store form name as "file" with file data
    formData.append("file", file, file.name);

    // Make http post request over api
    // with formData as req
    return this.http.post(this.baseApiUrl + 'SaveMedia', formData, { responseType: 'text' });
  }

  BroadcastFileUrl(fileInfo: FileInfo) {

    this.uploadedFileInfo$.next(fileInfo);
  }
}
