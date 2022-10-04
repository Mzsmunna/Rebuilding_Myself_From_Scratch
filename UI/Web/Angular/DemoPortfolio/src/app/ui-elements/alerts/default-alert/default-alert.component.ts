import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../../services/common/alert/alert.service';
import { Alert } from '../../../view_models/common/alert.model';

@Component({
  selector: 'app-default-alert',
  templateUrl: './default-alert.component.html',
  styleUrls: ['./default-alert.component.css']
})
export class DefaultAlertComponent implements OnInit {

  successBID: any;
  alert: Alert;

  constructor(private alertService: AlertService) {

    this.alert = this.alertService.GetDefaultAlert();
  }

  ngOnInit(): void {

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
