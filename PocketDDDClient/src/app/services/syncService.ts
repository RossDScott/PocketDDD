import { Injectable } from '@angular/core';

import { ServerAPIService } from './serverAPI';
import { LocalDataService } from './localData';

import { ClientMetaDataDTO, ClientMetaDataSyncResponseDTO, ServerUpdateResponseDTO } from '../models/serverDTO';
import { CampaignGroupMetaData } from '../models/metaData';

@Injectable()
export class SyncService {
    constructor(private serverAPIService: ServerAPIService, private localDataService: LocalDataService) {

    }

    async TrySyncAll() {
        try {
            await this.SyncMetaData();
            await this.TrySyncFeedbackAndGameScore(); 

            return true;
        } catch (error) {
            return false;
        }
    }

    async SyncAll() {
        await this.SyncMetaData();
        await this.TrySyncFeedbackAndGameScore(); 
    }

    async SyncMetaData() {
        var data = this.localDataService.getMetaData();
        let version = data == null ? -1 : data.version;

        var response = await this.serverAPIService.syncMetaData({version: version});
        
        if(response.status === 200)
            this.localDataService.setMetaData(response.body);
    }

    async TrySyncFeedbackAndGameScore() {
        let sessionData = this.localDataService.getAllPendingSessionFeedbackData();

        let sessionDataPromises = sessionData.map(sessionDataItem => {
            return this.serverAPIService.submitPendingClientSessionData(sessionDataItem)
                .then(this.processSessionSyncDataResponse)
                .catch(() => { });
        })
        let allSessionDataPromise = Promise.all(sessionDataPromises);

        let eventData = this.localDataService.getAllPendingEventFeedbackData();
        let eventDataPromises = eventData.map(eventDataItem => {
            return this.serverAPIService.submitPendingClientEventData(eventDataItem)
                .then(this.processEventSyncDataResponse)
                .catch(() => { });
        })

        try {
            await Promise.all(sessionDataPromises);
            await Promise.all(eventDataPromises);
        } catch (error) {  }
    }

    private processSessionSyncDataResponse = (response: ServerUpdateResponseDTO) => {
        this.localDataService.deletePendingSessionFeedbackData(response.clientId);
        this.updateEventScore(response.score);
    }

    private processEventSyncDataResponse = (response: ServerUpdateResponseDTO) => {
        this.localDataService.deletePendingEventFeedbackData(response.clientId);
        this.updateEventScore(response.score);
    }

    private updateEventScore(score: number){
        var currentScore = this.localDataService.getEventScore();
        if(score > currentScore)
            this.localDataService.setEventScore(score);
    }
}