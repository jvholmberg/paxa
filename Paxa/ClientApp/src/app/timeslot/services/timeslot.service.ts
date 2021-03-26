import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { Timeslot } from './timeslot.model';

@Injectable({
  providedIn: 'root'
})
export class TimeslotService extends BaseService<Timeslot[]> {

  constructor(http: HttpClient) {
    super(http, 'timeslot');
  }

  public findById(id: number): Observable<Timeslot> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
