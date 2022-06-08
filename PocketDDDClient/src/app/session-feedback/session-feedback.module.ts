import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SessionFeedbackPageRoutingModule } from './session-feedback-routing.module';

import { SessionFeedbackPage } from './session-feedback.page';
import { RatingComponentModule } from '../rating/rating.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SessionFeedbackPageRoutingModule,
    RatingComponentModule
  ],
  declarations: [SessionFeedbackPage]
})
export class SessionFeedbackPageModule {}
