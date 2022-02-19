import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { ResourceType } from './resource-type.model';
import { Resource } from './resource.model';

@Injectable({
  providedIn: 'root'
})
export class ResourceService extends BaseService<Resource> {

  private readonly loadingTypesSubject = new BehaviorSubject<boolean>(false);
  private readonly typesSubject = new BehaviorSubject<ResourceType[]>([]);

  public readonly loadingTypes$ = this.loadingTypesSubject.asObservable();
  public readonly types$ = this.typesSubject.asObservable();

  public get loadingTypesValue(): boolean { return this.loadingTypesSubject.value }
  public get typesValue(): ResourceType[] { return this.typesSubject.value }

  constructor(http: HttpClient) {
    super(http, 'resources');
  }

  getTypes(force: boolean = false): Observable<ResourceType[]> {
    const previousValue = this.typesValue;
    if (previousValue?.length === 0 || force) {
      this.loadingTypesSubject.next(true);
      this.http.get<ResourceType[]>(`${this.serviceUrl}/types`).subscribe({
        next: (types) => {
          this.typesSubject.next(types);
        },
        complete: () => {
          this.loadingTypesSubject.next(false);
        },
      });
    }

    return this.types$;
  }
}
