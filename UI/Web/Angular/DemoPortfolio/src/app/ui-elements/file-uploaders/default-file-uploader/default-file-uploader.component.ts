import { Component, OnInit } from '@angular/core';
import { FileUploaderService } from '../../../services/common/file-uploader/file-uploader.service';

@Component({
  selector: 'app-default-file-uploader',
  templateUrl: './default-file-uploader.component.html',
  styleUrls: ['./default-file-uploader.component.css']
})
export class DefaultFileUploaderComponent implements OnInit {

  // Variable to store shortLink from api response
  shortLink: string = "";
  loading: boolean = false; // Flag variable
  file: File | null = null; // Variable to store file

  // Inject service 
  constructor(private fileUploadService: FileUploaderService) {

  }

  ngOnInit(): void {
  }

  // On file Select
  onChange(event: any) {
    this.file = event.target.files[0];
  }

  // OnClick of button Upload
  onUpload() {
    this.loading = !this.loading;
    console.log(this.file);
    this.fileUploadService.upload(this.file).subscribe(
      (event: any) => {
        //if (typeof (event) === 'object') {

          // Short link via api response
        this.shortLink = event;//event.link;

          this.loading = false; // Flag variable 
        //}
      }
    );
  }

}
