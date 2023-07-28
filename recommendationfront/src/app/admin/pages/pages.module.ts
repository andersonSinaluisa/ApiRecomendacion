import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SettingsComponent } from './settings/settings.component';
import { ProfilesComponent } from './profiles/profiles.component';
import { EntitiesComponent } from './entities/entities.component';


import { RouterModule, Routes } from '@angular/router';
import { ComponentsModule } from '../components/components.module';
import { NgApexchartsModule } from 'ng-apexcharts';
const routes: Routes = [
  { path: '', component: DashboardComponent },

];

@NgModule({
  declarations: [
    DashboardComponent,
    SettingsComponent,
    ProfilesComponent,
    EntitiesComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    RouterModule.forChild(routes),
    NgApexchartsModule,
  ],
  //routing
  exports: [
    RouterModule
  ],
  
})
export class PagesModule { }
