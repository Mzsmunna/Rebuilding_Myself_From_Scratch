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
      TimeOut: 5000
    }
  }

  ShowAlert(alert: Alert) {

    this.alert = alert;
    this.alertSubject$.next(this.alert);
    //this.alert = this.GetDefaultAlert();
  }

  Success(message: string, headline: string, broadcast: boolean) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.Headline = headline;
    this.alert.IsSuccess = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  SuccessDetails(message: string, headline: string, saying: string, broadcast: boolean) {

    this.alert = this.Success(message, headline, false);
    this.alert.Saying = saying;
    this.alert.IsShort = false;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  Error(message: string, headline: string, broadcast: boolean) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.Headline = headline;
    this.alert.IsError = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  ErrorDetails(message: string, headline: string, saying: string, broadcast: boolean) {

    this.alert = this.Error(message, headline, false);
    this.alert.Saying = saying;
    this.alert.IsShort = false;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  Warning(message: string, headline: string, broadcast: boolean) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.Headline = headline;
    this.alert.IsWarning = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  WarningDetails(message: string, headline: string, saying: string, broadcast: boolean) {

    this.alert = this.Warning(message, headline, false);
    this.alert.Saying = saying;
    this.alert.IsShort = false;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  Info(message: string, headline: string, broadcast: boolean) {

    this.alert = this.GetDefaultAlert();
    this.alert.Message = message;
    this.alert.Headline = headline;
    this.alert.IsInfo = true;
    this.alert.IsShort = true;
    this.alert.IsVisible = true;
    this.alert.IsDismissable = true;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }

  InfoDetails(message: string, headline: string, saying: string, broadcast: boolean) {

    this.alert = this.Info(message, headline, false);
    this.alert.Saying = saying;
    this.alert.IsShort = false;

    if (broadcast)
      this.ShowAlert(this.alert);

    return this.alert;
  }
}
