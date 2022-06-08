import { Component, Input, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { SessionDTO, SessionFeedbackDTO } from '../models/serverDTO';
import { LocalDataService } from '../services/localData';

@Component({
    selector: 'app-session-feedback',
    templateUrl: './session-feedback.page.html',
    styleUrls: ['./session-feedback.page.scss'],
})
export class SessionFeedbackPage {
    @Input() sessionId: number;

    session: SessionDTO;
    currentRating: SessionFeedbackDTO;
    isDirty = false;

    constructor(private localData: LocalDataService, private modalController: ModalController) { 

    }

    ionViewWillEnter(){
        const sessionId = this.sessionId;
        const allSessionFeedback = this.localData.getSessionFeedback();
        let currentFeedback = allSessionFeedback.find(x => x.sessionId === sessionId);
        
        if(!currentFeedback)
            currentFeedback = {clientId:"", comments:"", sessionId: sessionId, speakerKnowledgeRating: 0, speakingSkillRating: 0, dateTimeStamp: new Date() };

        this.currentRating = Object.assign({}, currentFeedback);

        const metaData = this.localData.getMetaData();
        this.session = metaData.sessions.find(x => x.id === sessionId);
    }

    handleRatingChange(){
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
            this.localData.setSessionFeedback(this.currentRating);
        }
        
        this.modalController.dismiss({
            'dismissed': true
        });
    }
}
