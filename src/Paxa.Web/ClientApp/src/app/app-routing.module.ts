import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { FacilityComponent } from './facility/facility.component';
import { GetStartedComponent } from './get-started/get-started.component';
import { LandingComponent } from './landing/landing.component';
import { NotAllowedComponent } from './not-allowed/not-allowed.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SettingsComponent } from './settings/settings.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: LandingComponent },
  { path: 'get-started', component: GetStartedComponent },
  { path: 'get-started/:step', component: GetStartedComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'facility', component: FacilityComponent },
  { path: 'facility/:id', component: FacilityComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'not-allowed', component: NotAllowedComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
