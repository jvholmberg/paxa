import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base-service';
import { Timeslot } from './timeslot.model';

@Injectable({
  providedIn: 'root'
})
export class TimeslotService extends BaseService<Timeslot> {

  constructor(http: HttpClient) {
    super(http, 'timeslot');
  }
}
