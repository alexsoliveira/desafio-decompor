import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DecomporCalculoComponent } from './decompor/calculo/decompor-calculo.component';

const routes: Routes = [
  { path: '', redirectTo: '/decompor', pathMatch: 'full' },
  { path: 'decompor', component: DecomporCalculoComponent },
  {
    path: 'decompor',
    loadChildren: () => import('./decompor/decompor.module')
      .then(m => m.DecomporModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
