import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingComponent } from './booking.component';
import { BookingListComponent } from './booking-list/booking-list.component';
import { BookingViewComponent } from './booking-view/booking-view.component';
import { BookingFormComponent } from './booking-form/booking-form.component';

const routes: Routes = [
  { path: '', component: BookingComponent, pathMatch: 'full' },
  { path: 'all', component: BookingListComponent },
  { path: 'create', component: BookingFormComponent },
  { path: ':id', redirectTo: ':id/view', pathMatch: 'full' },
  { path: ':id/view', component: BookingViewComponent },
  { path: ':id/edit', component: BookingFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
