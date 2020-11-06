import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FacilityService } from '@core/facility/facility.service';
import { BookingService } from '@core/booking/booking.service';
import { Facility } from '@shared/models/facility.model';

@Component({
  selector: 'app-facility',
  templateUrl: './facility.component.html',
  styleUrls: ['./facility.component.scss']
})
export class FacilityComponent implements OnInit {

  displayedColumns = ['name', 'action'];
  facilityCollection$: Observable<Facility[]>;

  constructor(
    private facilityService: FacilityService,
    private bookingService: BookingService,
  ) { }

  ngOnInit(): void {
    this.facilityCollection$ = this.facilityService.getCollection();
  }

  bookTimeSlot(timeslotId: number): void {
    this.bookingService.create(timeslotId);

  }
}
