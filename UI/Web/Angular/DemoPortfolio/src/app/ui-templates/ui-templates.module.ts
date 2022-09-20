import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './popup-modals/add-user/add-user.component';
import { AddIssueComponent } from './popup-modals/add-issue/add-issue.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UiTemplatesRoutingModule } from './ui-templates-routing.module';

@NgModule({
  declarations: [
    AddUserComponent,
    AddIssueComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UiTemplatesRoutingModule
  ],
  exports: [
    AddUserComponent,
    AddIssueComponent
  ]
})
export class UiTemplatesModule { }
