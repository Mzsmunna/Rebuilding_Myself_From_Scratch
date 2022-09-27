import { Component, Input, OnInit } from '@angular/core';
import { FileUploaderService } from '../../../services/common/file-uploader/file-uploader.service';
import { FileInfo } from '../../../view_models/common/file-info.model';

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
  fileInfo: FileInfo;

  @Input() to: string = '';

  // Inject service 
  constructor(private fileUploadService: FileUploaderService) {

    this.fileInfo = {} as FileInfo;
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
    this.fileUploadService.upload(this.file, this.to).subscribe(
      (result: string) => {
        //if (typeof (event) === 'object') {

          // Short link via api response
        this.shortLink = result;//event.link;

        this.loading = false; // Flag variable

        this.fileInfo.To = this.to;
        this.fileInfo.Url = this.shortLink;

        this.fileUploadService.BroadcastFileUrl(this.fileInfo);
        //}
      }
    );
  }

}
