import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventScorePage } from './event-score.page';

const routes: Routes = [
  {
    path: '',
    component: EventScorePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EventScorePageRoutingModule {}
