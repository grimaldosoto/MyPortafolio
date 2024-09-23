import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BaseComponent} from "@views/layout/base/base.component";

const routes: Routes = [
  {
    path: '',
    component: BaseComponent,
    children: [
      {
        path:'home',
        loadChildren: () => import('./views/pages/pages-routing.module').then(m => m.PagesRoutingModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
