import { NgModule } from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { BaseComponent } from './base/base.component';
import { NavbarComponent } from './navbar/navbar.component';
import {PageModule} from "@views/pages/page.module";
import {RouterLink} from "@angular/router";



@NgModule({
  declarations: [
    FooterComponent,
    BaseComponent,
    NavbarComponent,
  ],
  imports: [
    CommonModule,
    NgOptimizedImage,
    PageModule,
    RouterLink,
  ]
})
export class LayoutModule { }
