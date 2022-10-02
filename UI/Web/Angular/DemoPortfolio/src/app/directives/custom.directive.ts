import { Directive, ElementRef, HostBinding, HostListener, Input, OnChanges, OnInit, Renderer2 } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appCustom]'
})
export class CustomDirective {

  constructor() { }

}

@Directive({
  selector: '[customBackground]'
})
export class CustomBackgroundDirective implements OnInit {

  constructor(private element: ElementRef) {

  }

  ngOnInit() {

    this.element.nativeElement.style.backgroundColor = "#C8E6C9";
  }

}

@Directive({
  selector: '[customRender2]'
})
export class CustomRender2Directive implements OnInit {

  constructor(private element: ElementRef, private renderer: Renderer2) {

  }

  ngOnInit() {

    //this.renderer.setStyle(this.element.nativeElement, 'backgroundColor', '#F1948A');
    this.renderer.addClass(this.element.nativeElement, 'bg-light');
    this.renderer.setAttribute(this.element.nativeElement, 'title', 'Designation');
  }

}

@Directive({
  selector: '[customHostListener]'
})
export class CustomHostListenerDirective implements OnInit {

  //@Input() color: string = 'AliceBlue';
  @Input('customHostListener') set setColor(condition: boolean | null | "") {

    console.log("con dir:", condition);

    if (condition)
      this.element.nativeElement.style.backgroundColor = "#C8E6C9";
  }

  constructor(private element: ElementRef, private renderer: Renderer2) {

  }

  ngOnInit() {

  }

  @HostListener('mouseenter') mouseHover() {

    //this.renderer.setAttribute(this.element.nativeElement, 'data-mdb-toggle', 'animation');
    //this.renderer.setAttribute(this.element.nativeElement, 'data-mdb-animation-reset', 'true');
    //this.renderer.setAttribute(this.element.nativeElement, 'data-mdb-animation', 'tada');

    this.renderer.setStyle(this.element.nativeElement, 'margin', '5px 10px');
    this.renderer.setStyle(this.element.nativeElement, 'padding', '30px 30px');
    this.renderer.setStyle(this.element.nativeElement, 'transition', '0.5s');
  }

  @HostListener('mouseleave') mouseOut() {

    this.renderer.setStyle(this.element.nativeElement, 'margin', '-22px -35px');
    this.renderer.setStyle(this.element.nativeElement, 'padding', '-40px -40px');
    this.renderer.setStyle(this.element.nativeElement, 'transition', '0.5s');
  }

  @HostBinding('style.backgroundColor') background: string = 'AliceBlue';
  //@HostBinding('style.border') border: string = '#C8E6C9 2px solid';

}

@Directive({
  //selector: "[customPhoneMask]",
  selector: '[formControlName][Phone]', //Reactive Forms
  //selector: '[ngModel][Phone]', //Template-driven Forms
  //host: {
  //  '(ngModelChange)': 'onInputChange($event, false)',
  //  'keydown.backspace': 'onInputChange($event.target.value, true)'
  //}
})
export class CustomPhoneMask implements OnInit, OnChanges {

  constructor(public ngControl: NgControl) { }

  ngOnInit() {

  }

  ngOnChanges() {

  }

  @HostListener('ngModelChange', ['$event']) onModelChange(event: any) {

    this.onInputChange(event, false);
  }

  @HostListener('keydown.backspace', ['$event']) keydownBackspace(event: any) {

    this.onInputChange(event.target.value, true);
  }

  onInputChange(event: any, backspace: any): any {

    console.log("Phone mask event - ", event);
    // console.log("event length", event.length);

    if (event == null) {

      return "";
    }

    let newVal = event.replace(/\D/g, "");

    if (backspace && newVal.length <= 6) {

      newVal = newVal.substring(0, newVal.length - 1);
    }
    console.log(newVal);

    if (newVal.length === 0) {

      newVal = "";

    } else if (newVal.length <= 3) {

      newVal = newVal.replace(/^(\d{0,3})/, "($1)");

    } else if (newVal.length <= 6) {

      newVal = newVal.replace(/^(\d{0,3})(\d{0,3})/, "($1) $2");

    } else {

      newVal = newVal.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, "($1) $2-$3");
    }

    if (newVal === "") {

      this.ngControl.control?.setValue(null);
      console.log(this.ngControl.value);

    } else {

      this.ngControl.valueAccessor?.writeValue(newVal);
      //this.ngControl.control?.setValue(null);
    }
  }
}
