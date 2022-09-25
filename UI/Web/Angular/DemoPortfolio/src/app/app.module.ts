import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { UiElementsModule } from './ui-elements/ui-elements.module';
//import { UserAuthModule } from './pages/user-auth/user-auth.module'; //don't import when implementing lazy loading
import { AppComponent } from './app.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { TokenInterceptorService } from './services/common/http-intercept/token-interceptor.service';
import { UserPanelComponent } from './pages/home/user-panel/user-panel.component';
import { IssuePanelComponent } from './pages/home/issue-panel/issue-panel.component';
import { UiTemplatesModule } from './ui-templates/ui-templates.module';
import { CustomCapitalize, CustomPipePipe } from './pipes/custom-pipe.pipe';


@NgModule({
  declarations: [
    AppComponent,
    AngularBasicsComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    NotFoundComponent,
    UserPanelComponent,
    IssuePanelComponent,

    //Custom Pipes
    CustomPipePipe,
    CustomCapitalize
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    UiElementsModule,
    UiTemplatesModule
    //UserAuthModule //don't import when implementing lazy loading
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
