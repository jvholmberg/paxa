import { Injectable } from '@angular/core';
import { ResourceProxy } from './resource.proxy.base';
import { BehaviorSubject, Observable } from 'rxjs';
import { Resource } from 'src/app/shared/models/resource.model';

@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  private initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly collectionSource = new BehaviorSubject<Resource[]>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly collection$ = this.collectionSource.asObservable();

  constructor(private proxy: ResourceProxy) { }

  getByFacilityId(facilityId: number): Observable<Resource[]> {

    return this.collection$;
  }

  getByResourceType(resourceTypeId: number): Observable<Resource[]> {

    return this.collection$;
  }

  getById(resourceId: number): Observable<Resource> {

    return null;
  }
}
