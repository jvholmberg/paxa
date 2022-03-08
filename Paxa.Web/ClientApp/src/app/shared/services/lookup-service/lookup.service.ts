import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { BaseService } from '@core/base-service/base.service';
import { Weekday } from './weekday.model';

@Injectable({
  providedIn: 'root'
})
export class LookupService extends BaseService<never> {

  private readonly weekdaysSubject = new BehaviorSubject<Weekday[]>([]);
  public readonly weekdays$ = this.weekdaysSubject.asObservable();
  public get weekdaysValue(): Weekday[] { return this.weekdaysSubject.value }

  constructor(http: HttpClient) {
    super(http, 'lookups');
  }

  getWeekdays(force: boolean = false): Observable<Weekday[]> {
    const previousValue = this.weekdaysValue;
    if (previousValue?.length === 0 || force) {
      this.http.get<Weekday[]>(`${this.serviceUrl}/weekdays`).subscribe((weekdays) => {
        this.weekdaysSubject.next(weekdays);
      });
    }

    return this.weekdays$;
  }
}
