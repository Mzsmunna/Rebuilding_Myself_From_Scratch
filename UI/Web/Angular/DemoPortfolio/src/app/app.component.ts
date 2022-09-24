import { Component } from '@angular/core';
import { TableService } from './ui-elements/tables/table.service';
//import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  // template: `
  // <h2 class="display-2">I am Mzs.</h2>
  // <h3 class="display-3">Hello World!</h3>
  // `,
  styleUrls: ['./app.component.css'],
  providers: [] //TableService, NgbCarouselConfig
})
export class AppComponent {

  title: string = "Demo Angular App";
}


