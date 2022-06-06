import { Component } from '@angular/core';
import { ModalController, NavController } from '@ionic/angular';
import { LoginPage } from '../login/login.page';
import { SessionItemVM } from '../models/clientVM';
import { ClientMetaDataSyncResponseDTO, TimeSlotDTO } from '../models/serverDTO';
import { LocalDataService } from '../services/localData';
import { ServerAPIService } from '../services/serverAPI';

@Component({
    selector: 'app-home',
    templateUrl: 'home.page.html',
    styleUrls: ['home.page.scss'],
})
export class HomePage {
    metaData: ClientMetaDataSyncResponseDTO;
    bookmarks: number[];
    eventScore = 0;

    constructor(private localData: LocalDataService, private serverAPI: ServerAPIService, private navCtrl: NavController, private modalCtrl: ModalController) { }

    ionViewDidLoad() {
        setInterval(() => this.updateEventScore(), 10000);
    }

    async ionViewWillEnter() {
        this.loadMetaData();
        this.updateEventScore();

        if(!this.metaData){
            const modal = await this.modalCtrl.create({
                component: LoginPage
            });

            return await modal.present();
        }
    }

    loadMetaData = () => this.metaData = this.localData.getMetaData();
    updateEventScore = () => this.eventScore = this.localData.getEventScore();

    getSessionsVMForTimeSlot = (timeSlot: TimeSlotDTO): SessionItemVM[] => {
        let tracks = this.metaData.tracks;
        let sessions = this.metaData.sessions;

        return sessions
            .filter(s => s.timeSlotId == timeSlot.id)
            .sort((a, b) => a.timeSlotId - b.timeSlotId)
            .map(s => {
                return {
                    session: s,
                    track: tracks.find(t => t.id == s.trackId)
                }
            });
    }

    handleSessionSelected(vm: SessionItemVM) {
        //this.navCtrl.navigateForward(['/visit-summary', visit.clientId]);
    }

    async handleShowEventRating() {
        // const modal = await this.modalCtrl.create({
        //     component: HelpListPage
        // });

        // return await modal.present();
    }

    async handleShowGameScore() {
        // const modal = await this.modalCtrl.create({
        //     component: HelpListPage
        // });

        // return await modal.present();
    }



    isBookmarked = (sessionId: number) => this.bookmarks.indexOf(sessionId) != -1;
}
