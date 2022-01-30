import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimeslotComponent } from './timeslot.component';
import { TimeslotListComponent } from './timeslot-list/timeslot-list.component';
import { TimeslotViewComponent } from './timeslot-view/timeslot-view.component';
import { TimeslotFormComponent } from './timeslot-form/timeslot-form.component';

const routes: Routes = [
  { path: '', component: TimeslotComponent, pathMatch: 'full' },
  { path: 'all', component: TimeslotListComponent },
  { path: 'create', component: TimeslotFormComponent },
  { path: ':id', redirectTo: ':id/view', pathMatch: 'full' },
  { path: ':id/view', component: TimeslotViewComponent },
  { path: ':id/edit', component: TimeslotFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimeslotRoutingModule { }
