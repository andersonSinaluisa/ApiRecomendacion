import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { CardItemComponent } from './card-item/card-item.component';
import { ListComponent } from './list/list.component';
import {MatIconModule} from '@angular/material/icon';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    NavbarComponent,
    CardItemComponent,
    ListComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    NgbModule
  ],
  exports: [
    NavbarComponent,
    CardItemComponent,
    ListComponent
  ]
})
export class ComponentsModule { }
