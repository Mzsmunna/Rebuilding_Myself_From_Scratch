export interface Alert {

  Headline: string;
  Message: string;
  Saying: string;
  Url: string;
  Classes: string;
  Id: string;
  IsSuccess: boolean;
  IsWarning: boolean;
  IsError: boolean;
  IsInfo: boolean;
  IsOther: boolean;
  IsShort: boolean;
  IsDismissable: boolean;
  IsVisible: boolean;
  TimeOut: number;
}
