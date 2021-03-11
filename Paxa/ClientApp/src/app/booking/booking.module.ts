import { NgModule } from '@angular/core';
import { BookingComponent } from './booking.component';
import { BookingListComponent } from './booking-list/booking-list.component';
import { BookingViewComponent } from './booking-view/booking-view.component';
import { BookingFormComponent } from './booking-form/booking-form.component';
import { BookingRoutingModule } from './booking-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [BookingComponent,
    BookingListComponent,
    BookingViewComponent,
    BookingFormComponent,
  ],
  imports: [
    SharedModule,
    BookingRoutingModule
  ]
})
export class BookingModule { }
