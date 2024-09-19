import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DecomporAppComponent } from './decompor.app.component';
import { DecomporCalculoComponent } from './calculo/decompor-calculo.component';

const decomporRouterConfig: Routes = [
    {
        path: '', component: DecomporAppComponent,
        children: [
          { path: 'decompor', component: DecomporCalculoComponent },            
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(decomporRouterConfig)
    ],
    exports: [RouterModule]
})
export class DecomporRoutingModule { }
