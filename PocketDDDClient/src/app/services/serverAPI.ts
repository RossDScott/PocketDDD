import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { timeout } from "rxjs/operators";
import { LoginDTO, LoginResponseDTO, ClientMetaDataDTO, ClientMetaDataSyncResponseDTO, SessionFeedbackDTO, EventFeedbackDTO, ServerUpdateResponseDTO } from '../models/serverDTO';
import { LocalDataService } from './localData';

@Injectable()
export class ServerAPIService {
    private serverURL = "/";
    constructor(private http: HttpClient, private localDataService: LocalDataService) { }

    private TIMEOUT = 10000;

    login = (loginDTO: LoginDTO): Promise<LoginResponseDTO> =>
        this.http.post<LoginResponseDTO>(this.serverURL + "login/login", loginDTO)
            .pipe(
                timeout(this.TIMEOUT)
            )
            .toPromise()
            .catch(this.handleError);

    syncMetaData = (clientStateDTO: ClientMetaDataDTO): Promise<Response> =>
        this.http.post<Response>(this.serverURL + "metaData/getLatest", clientStateDTO)
            .pipe(
                timeout(this.TIMEOUT)
            )
            .toPromise()
            .catch(this.handleError);


    submitPendingClientSessionData = (syncData: SessionFeedbackDTO): Promise<ServerUpdateResponseDTO> =>
        this.http.post<ServerUpdateResponseDTO>(this.serverURL + "clientDataSync/submitClientSessionData", syncData, { headers: this.getSecureHeader(), withCredentials: true })
            .pipe(
                timeout(this.TIMEOUT)
            )
            .toPromise()
            .catch(this.handleError);

    submitPendingClientEventData = (syncData: EventFeedbackDTO): Promise<ServerUpdateResponseDTO> =>
        this.http.post<ServerUpdateResponseDTO>(this.serverURL + "clientDataSync/submitClientEventData", syncData, { headers: this.getSecureHeader(), withCredentials: true })
        .pipe(
            timeout(this.TIMEOUT)
        )
            .toPromise()
            .catch(this.handleError);

    private getSecureHeader(): HttpHeaders {
        var currentUser = this.localDataService.getCurrentUser();

        if(!currentUser)
            return null;

        return new HttpHeaders({ 'Content-Type': 'application/json',  'Authorization': currentUser.token});
    }

    private extractData(res: Response) {
        let body = res.json();
        return body;
    }

    private handleError(error: Response | any) {
        console.dir(error);
        let errMsg: string;
        if (error instanceof Response) {
            let body: any = {};
            let err = '';
            try {
                body = error.json() || '';
                err = body.error || JSON.stringify(body);
            } catch (error) {
                
            }
            
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        
        return Promise.reject(errMsg);
    }
}