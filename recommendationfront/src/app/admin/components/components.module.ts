import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import {MatIconModule} from '@angular/material/icon';



@NgModule({
  declarations: [
    AdminLayoutComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
  ],
  exports: [
    AdminLayoutComponent
  ]
})
export class ComponentsModule { }
