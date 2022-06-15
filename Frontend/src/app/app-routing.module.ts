import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginGuard } from './login.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [LoginGuard],
    children: [
      {
        path:'',
        loadChildren: () => import('src/app/modules/profile/profile.module').then(m => m.ProfileModule),
      },
    ]
  },
  {
    path:'',
    loadChildren: () => import('src/app/modules/home/home.module').then(m => m.HomeModule),
  },
  {
    path:'',
    loadChildren: () => import('src/app/modules/login/login.module').then(m => m.LoginModule),
  
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
