import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User> {

  constructor(http: HttpClient) {
    super(http, 'user');
  }

  public get persons$(): Observable<User[]> {
    return this.value$.pipe(
      map((value) => {
        return value === null
          ? value
          : value.filter((user) => !!user.person.id && !user.organization.id)
      })
    );
  }

  public get organizations$(): Observable<User[]> {
    return this.value$.pipe(
      map((value) => {
        return value && value.filter((user) => !!user.organization.id && !user.person.id)
      }),
    );
  }

  public getMyUser(): Observable<User> {
    return this.http.get<User>(`${this.serviceUrl}/my`);
  }

  public findByUserId(id: number): Observable<User> {
    return this.get().pipe(
      map((collection) => {
        return collection && collection.find((entity) => entity.id === id)
      }),
    );
  }

  public findByPersonId(id: number): Observable<User> {
    return this.get().pipe(
      map((collection) => {
        return collection && collection.find((entity) => entity?.person.id === id)
      }),
    );
  }

  public findByOrganizationId(id: number): Observable<User> {
    return this.get().pipe(
      map((collection) => {
        return collection && collection.find((entity) => entity?.organization.id === id)
      }),
    );
  }
}
