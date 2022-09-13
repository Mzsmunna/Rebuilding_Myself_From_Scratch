import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './guard/auth/auth.guard';
import { AboutComponent } from './pages/about/about.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const routes: Routes = [
  { path: "home", component: HomeComponent, canActivate: [AuthGuard] },
  { path: "about", component: AboutComponent, canActivate: [AuthGuard] },
  { path: "contact", component: ContactComponent, canActivate: [AuthGuard] },
  { path: "angular-basics", component: AngularBasicsComponent, canActivate: [AuthGuard] },

   //lazy loading implementation
  { path: "auth", loadChildren: () => import('./pages/user-auth/user-auth.module').then(opt => opt.UserAuthModule) },


  //Not Found 404 page
  { path: "**", component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
