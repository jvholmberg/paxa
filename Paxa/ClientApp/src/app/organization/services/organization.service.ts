import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base-service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Organization } from './organization.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService extends BaseService<Organization[]> {

  constructor(http: HttpClient) {
    super(http, 'organization');
  }

  public findById(id: number): Observable<Organization> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
