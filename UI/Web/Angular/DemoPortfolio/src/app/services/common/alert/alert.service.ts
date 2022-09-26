import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Alert } from '../../../view_models/common/alert.model';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  alertSubject$: Subject<Alert>;
  private alert: Alert;

  constructor() {

    this.alertSubject$ = new Subject<Alert>();
    this.alert = {} as Alert;
  }

  GetDefaultAlert() {

    return {

      Headline: "",
      Message: "",
      Saying: "",
      Url: "",
      Classes: "",
      Id: "",
      IsSuccess: false,
      IsWarning: false,
      IsError: false,
      IsInfo: false,
      IsOther: false,
      IsShort: true,
      IsDismissable: true,
      IsVisible: false,
      TimeOut: 3000
    }
  }

  ShowAlert(alert: Alert) {

    this.alert = alert;
    this.alertSubject$.next(this.alert);
    this.alert = this.GetDefaultAlert();
  }

  Success(message: string) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.IsSuccess = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    return this.alert;
  }

  SuccessDetails(message: string, saying: string) {

    this.alert = this.Success(message);
    this.alert.Saying = saying;
    this.alert.IsShort = false;
  }

  Error(message: string) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.IsError = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    return this.alert;
  }

  ErrorDetails(message: string, saying: string) {

    this.alert = this.Error(message);
    this.alert.Saying = saying;
    this.alert.IsShort = false;
  }

  Warning(message: string) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.IsWarning = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    return this.alert;
  }

  WarningDetails(message: string, saying: string) {

    this.alert = this.Warning(message);
    this.alert.Saying = saying;
    this.alert.IsShort = false;
  }

  Info(message: string) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.IsInfo = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    return this.alert;
  }

  InfoDetails(message: string, saying: string) {

    this.alert = this.Info(message);
    this.alert.Saying = saying;
    this.alert.IsShort = false;
  }
}
