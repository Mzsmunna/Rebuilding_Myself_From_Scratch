import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiElementsRoutingModule } from './ui-elements-routing.module';
import { ButtonComponent } from './button/button.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideMenuBarComponent } from './side-menu-bar/side-menu-bar.component';
import { ContainerComponent } from './container/container.component';
import { TableComponent } from './table/table.component';
import { TileBarComponent } from './tile-bar/tile-bar.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { PieChartComponent } from './pie-chart/pie-chart.component';
import { BarChartComponent } from './bar-chart/bar-chart.component';
import { MapComponent } from './map/map.component';
import { ESignatureComponent } from './esignature/esignature.component';
import { FileUploaderComponent } from './file-uploader/file-uploader.component';
import { CardComponent } from './card/card.component';
import { ImageCardComponent } from './image-card/image-card.component';
import { ImageSliderComponent } from './image-slider/image-slider.component';
import { ReactiveFormComponent } from './reactive-form/reactive-form.component';



@NgModule({
  declarations: [
    ButtonComponent,
    HeaderComponent,
    FooterComponent,
    NavBarComponent,
    SideMenuBarComponent,
    ContainerComponent,
    TableComponent,
    TileBarComponent,
    SearchBarComponent,
    PieChartComponent,
    BarChartComponent,
    MapComponent,
    ESignatureComponent,
    FileUploaderComponent,
    CardComponent,
    ImageCardComponent,
    ImageSliderComponent,
    ReactiveFormComponent
  ],
  imports: [
    CommonModule,
    UiElementsRoutingModule
  ],
  exports: [
    ButtonComponent,
    HeaderComponent,
    FooterComponent,
    NavBarComponent,
    SideMenuBarComponent,
    ContainerComponent,
    TableComponent,
    TileBarComponent,
    SearchBarComponent,
    PieChartComponent,
    BarChartComponent,
    MapComponent,
    ESignatureComponent,
    FileUploaderComponent,
    CardComponent,
    ImageCardComponent,
    ImageSliderComponent,
    ReactiveFormComponent
  ]
})
export class UiElementsModule { }
