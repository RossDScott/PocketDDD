import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { EventFeedbackDTO } from '../models/serverDTO';
import { LocalDataService } from '../services/localData';
import { SyncService } from '../services/syncService';

@Component({
    selector: 'app-event-rating',
    templateUrl: './event-rating.page.html',
    styleUrls: ['./event-rating.page.scss'],
})
export class EventRatingPage {

    currentRating: EventFeedbackDTO;
    isDirty = false;

    constructor(private localData: LocalDataService, private modalController: ModalController) { 

    }

    ionViewWillEnter(){
        const currentRating = this.localData.getEventFeedback();
        this.currentRating = Object.assign({}, currentRating);
        if(!this.currentRating)
            this.currentRating = {clientId:"", comments:"",overall:0,refreshmentsRating:0,venueRating:0, dateTimeStamp: new Date() };
    }

    handleRatingChange() {
        this.isDirty = true;
    }

    handleCancel() {
        this.modalController.dismiss({
            'dismissed': true
        });
    }

    handleSubmit() {
        if(this.isDirty){
            this.currentRating.dateTimeStamp = new Date();
            this.localData.setEventFeedback(this.currentRating);
        }
        
        this.modalController.dismiss({
            'dismissed': true
        });
    }
}
