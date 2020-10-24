import { Injectable } from '@angular/core';
import { BookingProxy } from './booking.proxy.base';
import { BehaviorSubject, Observable } from 'rxjs';
import { Booking } from '@shared/models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  public initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly collectionSource = new BehaviorSubject<Booking[]>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly collection$ = this.collectionSource.asObservable();

  constructor(private proxy: BookingProxy) { }

  private setSource(
    loading: boolean,
    error?: Error,
    collection?: Booking[]
  ): void {
    this.initialized = true;
    this.loadingSource.next(loading);
    if (error !== undefined) { this.errorSource.next(error); }
    if (collection !== undefined) { this.collectionSource.next(collection); }
  }

  public getMyBookings(): Observable<Booking[]> {
    this.setSource(true);
    this.proxy.get().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.collection$;
  }

}
