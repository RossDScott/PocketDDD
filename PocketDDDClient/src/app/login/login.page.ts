import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { LocalDataService } from '../services/localData';
import { ServerAPIService } from '../services/serverAPI';

@Component({
    selector: 'app-login',
    templateUrl: './login.page.html',
    styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

    constructor(private localData: LocalDataService, private serverAPI: ServerAPIService, private modalController: ModalController) { }

    ngOnInit() {
    }

    isLoggingIn = false;
    loginFailed = false;
    loginName: string;
    async handleLogin() {
        if (this.isLoggingIn)
            return;

        this.isLoggingIn = true;
        this.loginFailed = false;
        try {
            const response = await this.serverAPI.login({ name: this.loginName });
            this.localData.setCurrentUser({ name: response.name, token: response.bearerToken })

            this.modalController.dismiss({
                'dismissed': true
            });

        } catch (error) {
            this.loginFailed = true;
        } finally {
            this.isLoggingIn = false
        }

        this.modalController.dismiss({
            'dismissed': true
        });
    }
}
