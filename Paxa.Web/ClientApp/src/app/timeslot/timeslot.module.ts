import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TimeslotComponent } from './timeslot.component';
import { TimeslotListComponent } from './timeslot-list/timeslot-list.component';
import { TimeslotViewComponent } from './timeslot-view/timeslot-view.component';
import { TimeslotFormComponent } from './timeslot-form/timeslot-form.component';
import { TimeslotRoutingModule } from './timeslot-routing.module';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  declarations: [
    TimeslotComponent,
    TimeslotListComponent,
    TimeslotViewComponent,
    TimeslotFormComponent,
  ],
  imports: [
    SharedModule,
    TimeslotRoutingModule,
  ],
  exports: [
    TimeslotListComponent,
  ]
})
export class TimeslotModule { }
