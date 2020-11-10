import { Observable } from 'rxjs';
import { BookingProxy } from './booking.proxy.base';
import { Booking } from '@shared/models/booking.model';
import { simulate } from '@utils/api';

export class BookingProxyMock implements BookingProxy {

  get(): Observable<Booking[]> {
    const response: Booking[] = [
      { id: 0, timeslot: null, users: [] }
    ];
    return simulate(response);
  }

  post(timeslotId: number): Observable<Booking> {
    const response: Booking = { id: 0, timeslot: null, users: [] };
    return simulate(response);
  }

  delete(): Observable<Booking[]> {
    const response: Booking[] = [];
    return simulate(response);
  }

  update(): Observable<Booking[]> {
    const response: Booking[] = [];
    return simulate(response);
  }

}
