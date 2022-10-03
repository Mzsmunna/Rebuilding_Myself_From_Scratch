import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-not-found',
  //templateUrl: './not-found.component.html',
  template: `
    
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-lg-6">
          <div class="text-center mt-4">
            <img class="mb-4 img-error" src="assets/img/error-404-monochrome.svg" />
            <p class="lead">This requested URL was not found on this server.</p>
            <a routerLink="/home"><i class="fa-solid fa-arrow-left me-2"></i> Return to Home</a>
          </div>
        </div>
      </div>
    </div>

`,
  styleUrls: ['./not-found.component.css'],
  standalone: true,
  imports: [
    //BrowserModule,
    //FormsModule,
    //HttpClientModule,
    RouterModule,
  ],
})
export class NotFoundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }

}
