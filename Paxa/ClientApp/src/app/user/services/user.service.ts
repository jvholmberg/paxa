import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { combineLatest, Observable } from 'rxjs';
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
          : value.filter((user) => !!user.person && !user.organization)
      })
    );
  }

  public get organizations$(): Observable<User[]> {
    return this.value$.pipe(
      map((value) => {
        return value && value.filter((user) => !!user.organization && !user.person)
      }),
    );
  }

  public getMy(): Observable<User> {
    return this.http.get<User>(`${this.serviceUrl}/my`).pipe(
      map((user: User) => {
        this.setValue([user]);
        return user;
      }),
    );
  }
}
