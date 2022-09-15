import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiElementsRoutingModule } from './ui-elements-routing.module';
import { TileBarComponent } from './tile-bar/tile-bar.component';
import { ImageCardComponent } from './cards/image-card/image-card.component';
import { DefaultBarChartComponent } from './charts/bar-charts/default-bar-chart/default-bar-chart.component';
import { DefaultPieChartComponent } from './charts/pie-charts/default-pie-chart/default-pie-chart.component';
import { DefaultButtonComponent } from './buttons/default-button/default-button.component';
import { DefaultCardComponent } from './cards/default-card/default-card.component';
import { DefaultContainerComponent } from './containers/default-container/default-container.component';
import { DefaultEsignComponent } from './esigns/default-esign/default-esign.component';
import { DefaultFileUploaderComponent } from './file-uploaders/default-file-uploader/default-file-uploader.component';
import { CustomFileUploaderComponent } from './file-uploaders/custom-file-uploader/custom-file-uploader.component';
import { DefaultFooterComponent } from './footers/default-footer/default-footer.component';
import { DefaultHeaderComponent } from './headers/default-header/default-header.component';
import { DefaultSliderComponent } from './sliders/default-slider/default-slider.component';
import { ImageSliderComponent } from './sliders/image-slider/image-slider.component';
import { DefaultMapComponent } from './maps/default-map/default-map.component';
import { DefaultNavBarComponent } from './nav-bars/default-nav-bar/default-nav-bar.component';
import { SideNavBarComponent } from './nav-bars/side-nav-bar/side-nav-bar.component';
import { DefaultGenericFormComponent } from './generic-forms/default-generic-form/default-generic-form.component';
import { UsMapComponent } from './maps/us-map/us-map.component';
import { DefaultTableComponent } from './tables/default-table/default-table.component';
import { AngularDataTableComponent } from './tables/angular-data-table/angular-data-table.component';

@NgModule({
  declarations: [
    TileBarComponent,
    ImageCardComponent,
    DefaultBarChartComponent,
    DefaultPieChartComponent,
    DefaultButtonComponent,
    DefaultCardComponent,
    DefaultContainerComponent,
    DefaultEsignComponent,
    DefaultFileUploaderComponent,
    CustomFileUploaderComponent,
    DefaultFooterComponent,
    DefaultHeaderComponent,
    DefaultSliderComponent,
    ImageSliderComponent,
    DefaultMapComponent,
    DefaultNavBarComponent,
    SideNavBarComponent,
    DefaultGenericFormComponent,
    UsMapComponent,
    DefaultTableComponent,
    AngularDataTableComponent
  ],
  imports: [
    CommonModule,
    UiElementsRoutingModule
  ],
  exports: [
    TileBarComponent,
    ImageCardComponent,
    DefaultBarChartComponent,
    DefaultPieChartComponent,
    DefaultButtonComponent,
    DefaultCardComponent,
    DefaultContainerComponent,
    DefaultEsignComponent,
    DefaultFileUploaderComponent,
    CustomFileUploaderComponent,
    DefaultFooterComponent,
    DefaultHeaderComponent,
    DefaultSliderComponent,
    ImageSliderComponent,
    DefaultMapComponent,
    DefaultNavBarComponent,
    SideNavBarComponent,
    DefaultGenericFormComponent,
    UsMapComponent,
    DefaultTableComponent,
    AngularDataTableComponent
  ]
})
export class UiElementsModule { }
