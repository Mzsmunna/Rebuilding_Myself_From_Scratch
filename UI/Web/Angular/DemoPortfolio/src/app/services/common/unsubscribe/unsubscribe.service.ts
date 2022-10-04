import { Injectable, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

//@Injectable({
//  providedIn: 'root'
//})

@Injectable()
export abstract class UnsubscribeService implements OnDestroy {

  protected unsubscribe$ = new Subject<void>();;

  constructor() {

  }

  ngOnDestroy() {

    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
