import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base-service';
import { Booking } from './booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService extends BaseService<Booking[]> {

  constructor(http: HttpClient) {
    super(http, 'booking');
  }
}
