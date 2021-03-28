import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { Resource } from './resource.model';

@Injectable({
  providedIn: 'root'
})
export class ResourceService extends BaseService<Resource> {

  constructor(http: HttpClient) {
    super(http, 'resource');
  }

  public findById(id: number): Observable<Resource> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
