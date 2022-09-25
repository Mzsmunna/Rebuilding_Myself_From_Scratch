import { Directive, ElementRef, HostBinding, HostListener, Input, OnInit, Renderer2 } from '@angular/core';

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
