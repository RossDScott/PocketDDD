import { Component } from '@angular/core';
import { ModalController, NavController } from '@ionic/angular';
import { EventRatingPage } from '../event-rating/event-rating.page';
import { EventScorePage } from '../event-score/event-score.page';
import { LoginPage } from '../login/login.page';
import { CurrentUserContext } from '../models/clientData';
import { MetaDataVM, SessionItemVM, TimeSlotVM } from '../models/clientVM';
import { ClientMetaDataSyncResponseDTO, TimeSlotDTO } from '../models/serverDTO';
import { LocalDataService } from '../services/localData';
import { ServerAPIService } from '../services/serverAPI';
import { SyncService } from '../services/syncService';

@Component({
    selector: 'app-home',
    templateUrl: 'home.page.html',
    styleUrls: ['home.page.scss'],
})
export class HomePage {
    metaData: ClientMetaDataSyncResponseDTO;
    metaDataVM: MetaDataVM;
    currentUser: CurrentUserContext;
    bookmarks: number[] = [];
    eventScore = 0;

    constructor(private localData: LocalDataService, private syncService: SyncService, private navCtrl: NavController, private modalCtrl: ModalController) { }

    async ngOnInit() {

    }

    async ionViewWillEnter() {
        this.loadData();
        this.updateEventScore();
        this.refreshBookmarks();

        this.syncService.TrySyncAll()
            .then(() => {
                this.loadData();
                this.updateEventScore();
            });

        this.currentUser = this.localData.getCurrentUser();
        if(!this.currentUser)
            await this.handleShowLogin();

    }

    loadData = () => {
        this.bookmarks = this.localData.getSessionBookmarks();
        const newMetaData = this.localData.getMetaData();

        if(!this.metaData || this.metaData.version !== newMetaData.version){
            this.metaData = newMetaData;
            this.buildMetaDataVM();
        }
    } 

    updateEventScore = () => this.eventScore = this.localData.getEventScore();
    refreshBookmarks = () => this.metaDataVM.timeSlots.forEach(ts => ts.sessions.forEach(session => session.isBookmarked = this.bookmarks.indexOf(session.session.id) != -1));

    buildMetaDataVM(){
        const metaData = this.metaData;
        const tracks = metaData.tracks;
        const sessions = metaData.sessions;
        const bookmarks = this.bookmarks;

        this.metaDataVM = {
            timeSlots: metaData.timeSlots.map(ts => ({
                id: ts.id,
                from: ts.from,
                to: ts.to,
                info: ts.info,
                sessions: sessions
                    .filter(s => s.timeSlotId == ts.id)
                    .sort((a, b) => a.timeSlotId - b.timeSlotId)
                    .map(s => ({
                            session: s,
                            track: tracks.find(t => t.id == s.trackId),
                            isBookmarked: bookmarks.indexOf(s.id) != -1
                        })
                    )
            }))
        };
    }

    handleSessionSelected(vm: SessionItemVM) {
        this.navCtrl.navigateForward(['/session', vm.session.id]);
    }

    async handleShowEventRating() {
        const modal = await this.modalCtrl.create({
            component: EventRatingPage
        });

        await modal.present();
        await modal.onWillDismiss();
        
        await this.syncService.TrySyncFeedbackAndGameScore();

        this.updateEventScore();
    }

    async handleShowGameScore() {
        const modal = await this.modalCtrl.create({
            component: EventScorePage
        });

        await modal.present();
        await modal.onWillDismiss();
    }

    async handleShowLogin(){
        const modal = await this.modalCtrl.create({
            component: LoginPage
        });

        await await modal.present();
        await modal.onWillDismiss();
        this.currentUser = this.localData.getCurrentUser();
        this.updateEventScore();
    }

    isBookmarked = (sessionId: number) => this.bookmarks.indexOf(sessionId) != -1;
}
