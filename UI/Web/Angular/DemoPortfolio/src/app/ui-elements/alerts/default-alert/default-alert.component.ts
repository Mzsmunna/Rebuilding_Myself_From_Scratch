import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AlertService } from '../../../services/common/alert/alert.service';
import { Alert } from '../../../view_models/common/alert.model';
declare var window: any;

@Component({
  selector: 'app-default-alert',
  templateUrl: './default-alert.component.html',
  styleUrls: ['./default-alert.component.css']
})
export class DefaultAlertComponent implements OnInit {

  //@ViewChild('successBID', { static: false }) successAdditional: ElementRef<HTMLElement>;
  successBID: any;
  alert: Alert;

  constructor(private alertService: AlertService) {

    this.alert = this.alertService.GetDefaultAlert();
    //{
    //  Headline: "HOLA!!",
    //  Message: "This is an Alert",
    //  Saying: "This is an additional Alert details",
    //  Url: "",
    //  Classes: "",
    //  Id: "",
    //  IsSuccess: false,
    //  IsWarning: false,
    //  IsError: false,
    //  IsInfo: false,
    //  IsOther: false,
    //  IsShort: false,
    //  IsDismissable: true,
    //  IsVisible: false,
    //  TimeOut: 3000
    //}

    //this.successBID = {} as ElementRef;
  }

  ngOnInit(): void {

    //show
    //$('#successBID').show();
    //hide
    //$('#successBID').hide();

    //this.successBID = new window.bootstrap.Modal(
    //  document.getElementById('successBID')
    //);

    //this.successBID.hide();

    this.alertService.alertSubject$.subscribe(result => {

      if (result.Message) {

        console.log("alert: ", result);
        this.alert = result;

        type Timer = ReturnType<typeof setTimeout>

        const timer: Timer = setTimeout(() => {

          this.alert.IsVisible = false;
          this.alert.IsDismissable = false;

          this.alert = this.alertService.GetDefaultAlert();

        }, this.alert.TimeOut)

      }

    });
  }

}
