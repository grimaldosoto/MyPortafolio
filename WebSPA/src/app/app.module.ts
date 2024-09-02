import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {PageModule} from "@views/pages/page.module";
import {LayoutModule} from "@views/layout/layout.module";
import { provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";

@NgModule({ declarations: [
        AppComponent,
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        AppRoutingModule,
        PageModule,
        LayoutModule], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
