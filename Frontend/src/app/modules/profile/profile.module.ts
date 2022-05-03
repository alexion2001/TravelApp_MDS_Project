import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfilComponent } from './profil/profil.component';
import { MaterialModule } from '../material/material.module';


@NgModule({
  declarations: [
    ProfilComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    MaterialModule
  ]
})
export class ProfileModule { }
