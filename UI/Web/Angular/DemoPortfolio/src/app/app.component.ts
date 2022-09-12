import { Component } from '@angular/core';
//import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  // template: `
  // <h2 class="display-2">I am Mzs.</h2>
  // <h3 class="display-3">Hello World!</h3>
  // `,
  styleUrls: ['./app.component.css'],
  providers: [] //NgbCarouselConfig
})
export class AppComponent { //implements OnInit, OnChanges, DoCheck, AfterContentInit, AfterContentChecked, AfterViewInit, AfterViewChecked, OnDestroy

  title: string = 'Welcome to Basics of Angular';
  count: number = 0;
  eventOutputModal: IEventOutputModal;

  images: { title: string, short: string, src: string }[] = [
    { title: 'First Slide', short: 'First Slide Short', src: "https://picsum.photos/id/700/900/500" },
    { title: 'Second Slide', short: 'Second Slide Short', src: "https://picsum.photos/id/1011/900/500" },
    { title: 'Third Slide', short: 'Third Slide Short', src: "https://picsum.photos/id/984/900/500" }
  ];

  //constructor(config: NgbCarouselConfig) {
  constructor() {

    //config.interval = 1000;
    //config.keyboard = true;
    //config.pauseOnHover = true;

    this.eventOutputModal = {
      id: 1,
      click: "button",
      keyup: "",
      keydown: "",
      blur: "",
      input: "",
      mouseOver: "",
      mouseLeave: ""
    }

    console.log("constructor: This is invoked when Angular creates a component or directive by calling new on the class.");
  }

  // ngOnInit() {
  //   var carouselConfig = document.querySelector('carousel')! as any
  //   carouselConfig.carousel({
  //     interval: 2000,
  //     keyboard: true,
  //     pauseOnHover: true
  //   })
  // }

  //#region Angular LifeCycle Hooks / Methods
  ngOnInit() {
    console.log(`ngOnInit: Invoked when given component has been initialized.
    This hook is only called once after the first ngOnChanges`);
  }

  ngOnChanges() {
    console.log(`ngOnChanges: Invoked every time there is a change in one of th input properties of the component.
    For example => @Input() decorator`);
  }

  ngDoCheck() {
    console.log(`ngDoCheck: Invoked when the change detector of the given component is invoked => Developer’s custom change detection.
    It allows us to implement our own change detection algorithm for the given component.

    Important => ngDoCheck and ngOnChanges should not be implemented together on the same component.`)
  }

  ngOnDestroy() {
    console.log(`ngOnDestroy: This method will be invoked just before Angular destroys the component.
    Use this hook to unsubscribe observables and detach event handlers to avoid memory leaks.`);
  }

  //Note: These hooks are only called for components and not directives.(Hooks for the Component’s Children)
  ngAfterContentInit() {
    console.log(`ngAfterContentInit: Invoked after Angular performs any content projection into the component’s view.
    Called when the component’s content ngContent is initialized`);
  }

  ngAfterContentChecked() {
    console.log(`ngAfterContentChecked: Invoked each time the content of the given component has been checked by the change detection mechanism of Angular.
    Called when the component’s content is updated or checked for updates`);
  }

  ngAfterViewInit() {
    console.log(`ngAfterViewInit: Invoked when the component’s view has been fully initialized.
    Called when the component’s projected view has been initialized`);
  }

  ngAfterViewChecked() {
    console.log(`ngAfterViewChecked: Invoked each time the view of the given component has been checked by the change detection mechanism of Angular.
    Called after the projected view has been checked`);
  }

  readonly lifeCycleHooksRefs: string[] = ["https://www.freecodecamp.org/news/angular-lifecycle-hooks/", "https://blog.logrocket.com/angular-lifecycle-hooks/", "https://codecraft.tv/courses/angular/components/lifecycle-hooks/"];
  //#endregion

  Hide(): void {
    console.log("trying to hide modal");
    // var modalDiv: any = document.getElementById('staticBackdrop') as any
    // modalDiv.modal('hide');
  }

  Counter(): number {
    return this.count++;
  }

  clickCount: number = 0;
  ClickMe(value: string): void {
    this.clickCount = this.clickCount + 1;
    this.eventOutputModal.click = value + ` ${this.clickCount}`;
  }
}

export interface IEventOutputModal {
  readonly id: number,
  click: string,
  keyup: string,
  keydown: string,
  blur: string,
  input: string,
  mouseOver: string,
  mouseLeave: string
}
