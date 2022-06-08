import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventRatingPage } from './event-rating.page';

const routes: Routes = [
  {
    path: '',
    component: EventRatingPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EventRatingPageRoutingModule {}
