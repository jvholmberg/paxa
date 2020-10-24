import { Component, OnInit } from '@angular/core';
import { PersonService } from '@core/person/person.service';
import { BookingService } from '@core/booking/booking.service';
import { Observable } from 'rxjs';
import { Booking } from '@shared/models/booking.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  bookings$: Observable<Booking[]>;

  constructor(
    private personService: PersonService,
    private bookingService: BookingService,
  ) { }

  ngOnInit(): void {
    this.bookings$ = this.bookingService.getMyBookings();
  }

}
