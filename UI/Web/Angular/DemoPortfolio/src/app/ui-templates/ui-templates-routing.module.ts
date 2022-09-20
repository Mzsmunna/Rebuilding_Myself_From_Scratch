import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from '../guard/role/role.guard';
import { AddUserComponent } from './popup-modals/add-user/add-user.component';

const routes: Routes = [
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UiTemplatesRoutingModule { }
