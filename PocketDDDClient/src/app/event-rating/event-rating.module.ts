import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { EventRatingPageRoutingModule } from './event-rating-routing.module';

import { EventRatingPage } from './event-rating.page';
import { RatingComponent } from '../rating/rating.component';
import { RatingComponentModule } from '../rating/rating.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    EventRatingPageRoutingModule,
    RatingComponentModule
  ],
  declarations: [EventRatingPage],
  entryComponents: [
    RatingComponent
  ]
})
export class EventRatingPageModule {}
