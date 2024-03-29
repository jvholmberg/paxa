import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BookingGuard } from '@booking/booking.guard';
import { OrganizationGuard } from '@organization/organization.guard';
import { PersonGuard } from '@person/person.guard';
import { ResourceGuard } from '@resource/resource.guard';
import { SchemaGuard } from '@schema/schema.guard';
import { TimeslotGuard } from '@timeslot/timeslot.guard';
import { UserGuard } from '@user/user.guard';

import { NotFoundComponent } from './not-found/not-found.component';
import { NotAllowedComponent } from './not-allowed/not-allowed.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LogoutComponent } from './logout/logout.component';
import { LoginComponent } from './login/login.component';
import { GetStartedComponent } from './get-started/get-started.component';

const routes: Routes = [

  { path: '', pathMatch: 'full', redirectTo: 'welcome' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'get-started', component: GetStartedComponent },
  {
    path: 'booking',
    canLoad: [BookingGuard],
    loadChildren: () => import('./booking/booking.module').then(m => m.BookingModule),
  },
  {
    path: 'organization',
    canLoad: [OrganizationGuard],
    loadChildren: () => import('./organization/organization.module').then(m => m.OrganizationModule)
  },
  {
    path: 'person',
    canLoad: [PersonGuard],
    loadChildren: () => import('./person/person.module').then(m => m.PersonModule),
  },
  {
    path: 'resource',
    canLoad: [ResourceGuard],
    loadChildren: () => import('./resource/resource.module').then(m => m.ResourceModule),
  },
  {
    path: 'schemas',
    canLoad: [SchemaGuard],
    loadChildren: () => import('./schema/schema.module').then(m => m.SchemaModule),
  },
  {
    path: 'timeslot',
    canLoad: [TimeslotGuard],
    loadChildren: () => import('./timeslot/timeslot.module').then(m => m.TimeslotModule),
  },
  {
    path: 'user',
    canLoad: [UserGuard],
    loadChildren: () => import('./user/user.module').then(m => m.UserModule),
  },
  { path: 'logout', component: LogoutComponent },
  { path: 'login', component: LoginComponent },
  { path: 'not-allowed', component: NotAllowedComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
