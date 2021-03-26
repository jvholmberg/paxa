import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { Booking } from './booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService extends BaseService<Booking[]> {

  constructor(http: HttpClient) {
    super(http, 'booking');
  }

  public findById(id: number): Observable<Booking> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
