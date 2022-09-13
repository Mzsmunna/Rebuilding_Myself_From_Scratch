import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { UiElementsModule } from './ui-elements/ui-elements.module';
//import { UserAuthModule } from './pages/user-auth/user-auth.module'; //don't import when implementing lazy loading
import { AppComponent } from './app.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    AngularBasicsComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiElementsModule,
    //UserAuthModule //don't import when implementing lazy loading
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
