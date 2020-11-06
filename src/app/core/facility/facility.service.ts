import { Injectable } from '@angular/core';
import { FacilityProxy } from './facility.proxy.base';
import { Observable, BehaviorSubject } from 'rxjs';
import { Facility } from 'src/app/shared/models/facility.model';
import { logInfo } from '@utils/logger';

@Injectable({
  providedIn: 'root'
})
export class FacilityService {
  private initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly collectionSource = new BehaviorSubject<Facility[]>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly collection$ = this.collectionSource.asObservable();

  constructor(private proxy: FacilityProxy) { }

  private setSource(loading: boolean, error: Error, collection: Facility[]): void {
    logInfo('FacilityService.setSource', loading, error, collection);
    this.loadingSource.next(loading);
    this.errorSource.next(error);
    this.collectionSource.next(collection);
  }

  public getCollection(): Observable<Facility[]> {
    logInfo('FacilityService.getCollection');
    if (!this.initialized) {
      this.loadingSource.next(true);
      this.proxy.getCollection().subscribe(
        (val) => {
          this.initialized = true;
          this.setSource(false, null, val);
        },
        (err) => this.setSource(false, err, null),
      );
    }
    return this.collection$;
  }
}
