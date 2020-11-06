import { Component, OnInit } from '@angular/core';
import { UserService } from '@core/user/user.service';
import { BookingService } from '@core/booking/booking.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private userService: UserService,
    private bookingService: BookingService,
  ) {}

  ngOnInit(): void {
    this.userService.getEntity();
  }

}
