import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SessionPage } from './session.page';

const routes: Routes = [
  {
    path: '',
    component: SessionPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SessionPageRoutingModule {}
