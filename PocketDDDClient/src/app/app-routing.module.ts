import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'event-score',
    loadChildren: () => import('./event-score/event-score.module').then( m => m.EventScorePageModule)
  },
  {
    path: 'event-rating',
    loadChildren: () => import('./event-rating/event-rating.module').then( m => m.EventRatingPageModule)
  },
  {
    path: 'session/:sessionId',
    loadChildren: () => import('./session/session.module').then( m => m.SessionPageModule)
  },
  {
    path: 'session-feedback',
    loadChildren: () => import('./session-feedback/session-feedback.module').then( m => m.SessionFeedbackPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
