import { NgModule } from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import { HomeComponent } from './home/home.component';
import {PagesRoutingModule} from "@views/pages/pages-routing.module";
import { AboutComponent } from './about/about.component';
import { CatalogComponent } from './catalog/catalog.component';
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [
    HomeComponent,
    AboutComponent,
    CatalogComponent,
    ContactComponent
  ],
    imports: [
        CommonModule,
        PagesRoutingModule,
        NgOptimizedImage
    ],
  exports: [
    HomeComponent,
    AboutComponent,
    CatalogComponent,
    ContactComponent
  ]
})
export class PageModule { }
