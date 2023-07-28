import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./core/pages/pages.module').then(m => m.PagesModule) },
  { path: 'admin', loadChildren: () => import('./admin/pages/pages.module').then(m => m.PagesModule)},
  { path: 'demo', loadChildren: () => import('./shop/pages/pages.module').then(m => m.PagesModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
