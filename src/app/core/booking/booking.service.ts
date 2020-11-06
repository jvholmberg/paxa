import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { logInfo } from '@utils/logger';
import { Booking } from '@shared/models/booking.model';
import { BookingProxy } from './booking.proxy.base';
import { tap } from 'rxjs/Operators';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly collectionSource = new BehaviorSubject<Booking[]>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly collection$ = this.collectionSource.asObservable();

  get loadingValue(): boolean { return this.loadingSource.value; }
  get errorValue(): Error { return this.errorSource.value; }
  get collectionValue(): Booking[] { return this.collectionSource.value; }

  constructor(private proxy: BookingProxy) { }

  private setSource(loading: boolean, error: Error, collection: Booking[]): void {
    logInfo('BookingService.setSource', loading, error, collection);
    this.loadingSource.next(loading);
    this.errorSource.next(error);
    this.collectionSource.next(collection);
  }

  public getCollection(): Observable<Booking[]> {
    logInfo('BookingService.getCollection');
    if (!this.initialized) {
      this.loadingSource.next(true);
      this.proxy.get().subscribe(
        (val) => {
          this.initialized = true;
          this.setSource(false, null, val);
        },
        (err) => this.setSource(false, err, null),
      );
    }
    return this.collection$;
  }

  public create(timeslotId: number): Observable<Booking> {
    logInfo('BookingService.create', timeslotId);
    const req = this.proxy.post(timeslotId);
    req.subscribe(() => {
      this.initialized = false;
      this.getCollection();
    });
    return req;
  }

}
