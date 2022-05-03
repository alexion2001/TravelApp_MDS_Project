import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home/home.component';
import { ForumComponent } from './forum/forum.component';
import { MaterialModule } from '../material/material.module';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';


@NgModule({
  declarations: [
    HomeComponent,
    ForumComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MaterialModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule
  ]
})
export class HomeModule { }
