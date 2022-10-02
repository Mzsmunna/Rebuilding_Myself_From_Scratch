import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './popup-modals/add-user/add-user.component';
import { AddIssueComponent } from './popup-modals/add-issue/add-issue.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UiTemplatesRoutingModule } from './ui-templates-routing.module';
import { ArraySortPipe } from '../pipes/custom-pipe.pipe';
import { CustomPhoneMask } from '../directives/custom.directive';

@NgModule({
  declarations: [
    AddUserComponent,
    AddIssueComponent,

    //Custom Pipes
    ArraySortPipe,

    //Custom Directives
    CustomPhoneMask
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UiTemplatesRoutingModule
  ],
  exports: [
    AddUserComponent,
    AddIssueComponent,

    //Custom Pipes
    ArraySortPipe,

    //Custom Directives
    CustomPhoneMask
  ]
})
export class UiTemplatesModule { }
