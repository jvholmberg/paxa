import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { LandingComponent } from './landing/landing.component';
import { GetStartedComponent } from './get-started/get-started.component';

const routes: Routes = [
  { path: '', component: LandingComponent, pathMatch: 'full' },
  { path: 'get-started', component: GetStartedComponent },
  {
    path: 'booking',
    canLoad: [],
    loadChildren: () => import('./booking/booking.module').then(m => m.BookingModule),
  },
  {
    path: 'organization',
    canLoad: [],
    loadChildren: () => import('./organization/organization.module').then(m => m.OrganizationModule)
  },
  {
    path: 'person',
    canLoad: [],
    loadChildren: () => import('./person/person.module').then(m => m.PersonModule),
  },
  {
    path: 'resource',
    canLoad: [],
    loadChildren: () => import('./resource/resource.module').then(m => m.ResourceModule),
  },
  {
    path: 'timeslot',
    canLoad: [],
    loadChildren: () => import('./timeslot/timeslot.module').then(m => m.TimeslotModule),
  },
  {
    path: 'user',
    canLoad: [],
    loadChildren: () => import('./user/user.module').then(m => m.UserModule),
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
