import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { SessionDTO, TimeSlotDTO, TrackDTO } from '../models/serverDTO';
import { LocalDataService } from '../services/localData';
import { SessionFeedbackPage } from '../session-feedback/session-feedback.page';

@Component({
    selector: 'app-session',
    templateUrl: './session.page.html',
    styleUrls: ['./session.page.scss'],
})
export class SessionPage implements OnInit {

    session: SessionDTO;
    track: TrackDTO;
    timeSlot: TimeSlotDTO;
    isBookmarked = false;

    constructor(private localData: LocalDataService, private route: ActivatedRoute, private modalCtrl: ModalController) { 
        route.params.subscribe(params => {
            const sessionId = +params.sessionId;
            const metaData = localData.getMetaData();
            this.session = metaData.sessions.find(x => x.id === sessionId);
            this.track = metaData.tracks.find(x => x.id === this.session.trackId);
            this.timeSlot = metaData.timeSlots.find(x => x.id === this.session.timeSlotId);

            this.isBookmarked = localData.getSessionBookmarks().indexOf(this.session.id) != -1
        });
    }

    ngOnInit() {

    }

    async handleShowSessionRating(){
        const modal = await this.modalCtrl.create({
            component: SessionFeedbackPage,
            componentProps: {
                'sessionId': this.session.id
            }
        });

        await modal.present();
        await modal.onWillDismiss();
    }

    handleToggleBookmark = () => {
        this.isBookmarked = !this.isBookmarked;
        let bookmarks = this.localData.getSessionBookmarks();
        let bookmarkPos = bookmarks.indexOf(this.session.id);
        if (this.isBookmarked && bookmarkPos == -1)
            bookmarks.push(this.session.id);
        else if(!this.isBookmarked && bookmarkPos != -1)
            bookmarks.splice(bookmarkPos,1);

        this.localData.setSessionBookmarks(bookmarks);
    }
}
