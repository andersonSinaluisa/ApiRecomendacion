import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';

import { RouterModule, Routes } from '@angular/router';
import { ComponentsModule } from '../components/components.module';
import { CardItemComponent } from '../components/card-item/card-item.component';
const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'demo/**', redirectTo: '/demo', pathMatch: 'full' },
];

@NgModule({
  declarations: [
    MainComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ComponentsModule

  ],
  exports: [
    RouterModule
  ],
})
export class PagesModule { }
