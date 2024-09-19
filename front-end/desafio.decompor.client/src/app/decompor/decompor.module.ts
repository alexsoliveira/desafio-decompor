import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { DecomporRoutingModule } from './decompor.route';

import { DecomporAppComponent } from './decompor.app.component';
import { DecomporCalculoComponent } from './calculo/decompor-calculo.component';
import { DecomporService } from './services/decompor.service';

@NgModule({
  declarations: [
    DecomporAppComponent,
    DecomporCalculoComponent    
  ],
  imports: [
    CommonModule,
    RouterModule,
    DecomporRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule  
  ],
  providers: [
    DecomporService
  ]
})
export class DecomporModule { }
