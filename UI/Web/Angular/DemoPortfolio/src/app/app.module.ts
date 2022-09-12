import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { UiElementsModule } from './ui-elements/ui-elements.module';
import { UserAuthModule } from './pages/user-auth/user-auth.module';
import { AppComponent } from './app.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    AngularBasicsComponent,
    HomeComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiElementsModule,
    UserAuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
