import { Injectable } from '@angular/core';

import { CurrentUserContext } from '../models/clientData';
import { ClientMetaDataSyncResponseDTO, SessionFeedbackDTO, EventFeedbackDTO } from '../models/serverDTO';

@Injectable()
export class LocalDataService {
    static CURRENT_USER = "currentUser";
    static META_DATA = "metaData";
    static SESSION_BOOKMARKS = "sessionBookmarks";
    static SESSION_FEEDBACK = "sessionFeedback";
    static SESSION_FEEDBACK_PREFIX = "sessionFeedback_";
    static EVENT_FEEDBACK = "eventFeedback";
    static EVENT_FEEDBACK_PREFIX = "eventFeedback_";
    static EVENT_SCORE = "eventScore";

    getCurrentUser(): CurrentUserContext{
        var currentUser = this.getItem<CurrentUserContext>(LocalDataService.CURRENT_USER);
        return currentUser;
    }

    setCurrentUser(currentUser: CurrentUserContext){
        this.setItem(LocalDataService.CURRENT_USER, currentUser);
    }

    getEventScore(): number{
        var score = +this.getItem<number>(LocalDataService.EVENT_SCORE);
        if(score == null)
            score = 0;

        return score;
    }
    setEventScore(score: number){
        this.setItem(LocalDataService.EVENT_SCORE, score);
    }

	private metaDataCache: ClientMetaDataSyncResponseDTO = null;
    getMetaData(noCache = false): ClientMetaDataSyncResponseDTO {
		if(!this.metaDataCache || noCache)
			this.metaDataCache = this.getItem<ClientMetaDataSyncResponseDTO>(LocalDataService.META_DATA);
		
		return this.metaDataCache;
    }

    setMetaData(data: ClientMetaDataSyncResponseDTO) {
		this.metaDataCache = null;
        this.setItem(LocalDataService.META_DATA, data);
    }

    private sessionBookmarksCache: number[];
    getSessionBookmarks() {
        if(!this.sessionBookmarksCache)
            this.sessionBookmarksCache = this.getItem<number[]>(LocalDataService.SESSION_BOOKMARKS);

        if(!this.sessionBookmarksCache)
            this.sessionBookmarksCache = [];
            
        return this.sessionBookmarksCache;
    }

    setSessionBookmarks(bookmarks: number[]){
        this.sessionBookmarksCache = bookmarks;
        this.setItem(LocalDataService.SESSION_BOOKMARKS, bookmarks);
    }

    private sessionFeedbackCache: SessionFeedbackDTO[];
    getSessionFeedback() {
        if(!this.sessionFeedbackCache)
            this.sessionFeedbackCache = this.getItem<SessionFeedbackDTO[]>(LocalDataService.SESSION_FEEDBACK);

        if(!this.sessionFeedbackCache)
            this.sessionFeedbackCache = [];

        return this.sessionFeedbackCache;
    }

    setSessionFeedback(feedback: SessionFeedbackDTO){
        let currentFeedbackItems = this.getSessionFeedback();
        let currentFeedback = currentFeedbackItems.find(x=>x.sessionId == feedback.sessionId);
        if(!currentFeedback)
            currentFeedbackItems.push(feedback);
        else
            currentFeedbackItems.splice(currentFeedbackItems.findIndex(x=>x.sessionId == feedback.sessionId),1,feedback);

        this.setItem(LocalDataService.SESSION_FEEDBACK,currentFeedbackItems);

        var clientId = this.createUniqueId();
        feedback.clientId = clientId;
        this.setItem(LocalDataService.SESSION_FEEDBACK_PREFIX + clientId,feedback); 
    }

    private eventFeedbackCache: EventFeedbackDTO;
    getEventFeedback() {
        if(!this.eventFeedbackCache)
            this.eventFeedbackCache = this.getItem<EventFeedbackDTO>(LocalDataService.EVENT_FEEDBACK);

        return this.eventFeedbackCache;
    }

    setEventFeedback(feedback: EventFeedbackDTO){
        this.setItem(LocalDataService.EVENT_FEEDBACK,feedback);

        var clientId = this.createUniqueId();
        feedback.clientId = clientId;
        this.setItem(LocalDataService.EVENT_FEEDBACK_PREFIX + clientId,feedback); 
    }

    getAllPendingSessionFeedbackData(){
        return this.getAllPendingSyncData<SessionFeedbackDTO>(LocalDataService.SESSION_FEEDBACK_PREFIX)
    }

    getAllPendingEventFeedbackData(){
        return this.getAllPendingSyncData<EventFeedbackDTO>(LocalDataService.EVENT_FEEDBACK_PREFIX)
    } 
    getAllPendingSyncData<T>(prefix: string): T[]{
        var data: T[] = [];
        for(let key in localStorage){
            if(key.startsWith(prefix)){
                data.push(this.getItem<T>(key));
            }
        }
        return data;
    }

    deletePendingSessionFeedbackData(clientId: string){
        localStorage.removeItem(LocalDataService.SESSION_FEEDBACK_PREFIX + clientId);
    }

    deletePendingEventFeedbackData(clientId: string){
        localStorage.removeItem(LocalDataService.EVENT_FEEDBACK_PREFIX + clientId);
    }

    deleteAllData(){
        localStorage.clear();
        this.metaDataCache = null;
    }

    private getItem<T>(itemName: string): T {
        var storageText = localStorage.getItem(itemName);

        if (!storageText)
            return null;

        var parsed = JSON.parse(storageText);
        return parsed;
    }

    private setItem<T>(itemName: string, data: T){
        localStorage.setItem(itemName, JSON.stringify(data));
    }

    private createUniqueId(){
        return 'xxxxxxxxxxxx4xxxyxxxxxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
            return v.toString(16);
        });
    }
}