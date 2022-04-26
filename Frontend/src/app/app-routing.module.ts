import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    loadChildren: () => import('src/app/modules/home/home.module').then(m => m.HomeModule),
  },
  {
    path:'',
    loadChildren: () => import('src/app/modules/login/login.module').then(m => m.LoginModule),
  
  },
  {
    path:'',
    loadChildren: () => import('src/app/modules/profile/profile.module').then(m => m.ProfileModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
