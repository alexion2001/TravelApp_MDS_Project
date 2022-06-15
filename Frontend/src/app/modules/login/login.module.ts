import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MaterialModule } from '../material/material.module';

import {MatFormFieldModule} from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,

  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    MaterialModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule

    
  ]
})
export class LoginModule { }
