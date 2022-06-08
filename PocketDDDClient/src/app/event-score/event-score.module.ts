import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { EventScorePageRoutingModule } from './event-score-routing.module';

import { EventScorePage } from './event-score.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    EventScorePageRoutingModule
  ],
  declarations: [EventScorePage]
})
export class EventScorePageModule {}
