import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './guard/auth/auth.guard';
import { RoleGuard } from './guard/role/role.guard';
import { UnAuthGuard } from './guard/un-auth/un-auth.guard';
import { AboutComponent } from './pages/about/about.component';
import { AngularBasicsComponent } from './pages/angular-basics/angular-basics.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HomeComponent } from './pages/home/home.component';
import { IssuePanelComponent } from './pages/home/issue-panel/issue-panel.component';
import { UserPanelComponent } from './pages/home/user-panel/user-panel.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const routes: Routes = [
  { path: "", component: HomeComponent, canActivate: [AuthGuard] },
  { path: "home", component: HomeComponent, canActivate: [AuthGuard],
    children: [
      { path: "users", component: UserPanelComponent, canActivate: [RoleGuard] },
      { path: "issues", component: IssuePanelComponent, canActivate: [AuthGuard] }
    ]
  },
  { path: "about", component: AboutComponent, canActivate: [AuthGuard] },
  { path: "contact", component: ContactComponent, canActivate: [AuthGuard] },
  { path: "angular-basics", component: AngularBasicsComponent, canActivate: [RoleGuard] },

  //lazy loading implementation
  { path: "auth", loadChildren: () => import('./pages/user-auth/user-auth.module').then(opt => opt.UserAuthModule), canActivate: [UnAuthGuard] },

  //Not Found 404 page
  { path: "**", component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
