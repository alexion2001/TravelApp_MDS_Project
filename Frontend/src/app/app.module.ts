import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { Router,NavigationEnd  } from '@angular/router';
//import {MaterialModule} from './app/modules/material/material.module';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    //MaterialModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    HttpClientModule
   // Router,
    //NavigationEnd
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
