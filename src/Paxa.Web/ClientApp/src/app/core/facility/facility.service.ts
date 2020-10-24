import { Injectable } from '@angular/core';
import { FacilityProxy } from './facility.proxy.base';
import { Observable, BehaviorSubject } from 'rxjs';
import { Facility } from 'src/app/shared/models/facility.model';

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

  getCollectionByLocation(location: Location): Observable<Facility[]> {

    return this.collection$;
  }

  getCollectionByResourceType(resourceTypeId: number): Observable<Facility[]> {

    return this.collection$;
  }

  getEntityById(facilityId: number): Observable<Facility> {

    return this.collection$;
  }
}
