import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HeroComponent } from './hero/hero.component';
import { FeaturesComponent } from './features/features.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [
    LayoutComponent,
    NavbarComponent,
    HeroComponent,
    FeaturesComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    LayoutComponent,
    HeroComponent,
    FeaturesComponent
  ]
})
export class ComponentsModule { }
