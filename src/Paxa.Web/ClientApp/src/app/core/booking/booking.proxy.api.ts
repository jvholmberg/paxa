import { Observable } from 'rxjs';
import { BookingProxy } from './booking.proxy.base';
import { Booking } from 'src/app/shared/models/booking.model';

export class BookingProxyApi implements BookingProxy {

  get(): Observable<Booking[]> {
    throw new Error("Method not implemented.");
  }

  create(): Observable<Booking[]> {
    throw new Error("Method not implemented.");
  }

  delete(): Observable<Booking[]> {
    throw new Error("Method not implemented.");
  }

  update(): Observable<Booking[]> {
    throw new Error("Method not implemented.");
  }

}
