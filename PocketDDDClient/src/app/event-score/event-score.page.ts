import { Component, OnInit } from '@angular/core';
import { AlertController, ModalController } from '@ionic/angular';
import { environment } from 'src/environments/environment';
import { CurrentUserContext } from '../models/clientData';
import { LocalDataService } from '../services/localData';
import { SyncService } from '../services/syncService';

@Component({
    selector: 'app-event-score',
    templateUrl: './event-score.page.html',
    styleUrls: ['./event-score.page.scss'],
})
export class EventScorePage {
    currentUser: CurrentUserContext;
    syncState = "Pending...";
    pendingDataCount = 0;
    currentScore = 0;

    version = environment.version;

    constructor(private localData: LocalDataService, private syncService: SyncService, private modalController: ModalController, private alertController: AlertController) { 

    }

    ionViewWillEnter(){
        this.currentUser = this.localData.getCurrentUser();
        this.updateGameScore();
        this.updatePendingCount();
        this.handleSync();
    }

    updateGameScore = () => this.currentScore = this.localData.getEventScore();

    updatePendingCount = () => {
        var ses = this.localData.getAllPendingSessionFeedbackData().length;
        var evt = this.localData.getAllPendingEventFeedbackData().length;

        this.pendingDataCount = ses + evt;
    }

    handleClose() {
        this.modalController.dismiss({
            'dismissed': true
        });
    }

    async handleSync(){
        this.syncState = "Syncing...";

        try {
            await this.syncService.SyncAll();
            this.syncState = "Success"
        } catch (error) {
            this.syncState = "Failed"
        } finally {
            this.updateGameScore();
            this.updatePendingCount();
        }
    }

    async handleLogOut(){
        const alert = await this.alertController.create({
            header: 'Please Confirm!',
            message: 'Your local data will be deleted and your score will reset',
            buttons: [
              {
                text: 'Cancel',
                role: 'cancel',
                cssClass: 'secondary',
                id: 'cancel-button',
                handler: (blah) => {

                }
              }, {
                text: 'Log Out',
                id: 'confirm-button',
                handler: () => {
                  this.localData.deleteAllData();
                  this.modalController.dismiss({
                        'dismissed': true,
                        'logout': true
                    });
                }
              }
            ]
          });
      
          await alert.present();
    }
}