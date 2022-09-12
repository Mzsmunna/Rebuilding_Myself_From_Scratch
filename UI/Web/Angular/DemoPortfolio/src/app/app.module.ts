import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { UiElementsModule } from './ui-elements/ui-elements.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';

@NgModule({
  declarations: [
    AppComponent,
    AngularBasicsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiElementsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
