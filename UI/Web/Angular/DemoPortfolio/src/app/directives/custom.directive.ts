import { Directive, ElementRef, OnInit, Renderer2 } from '@angular/core';

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
