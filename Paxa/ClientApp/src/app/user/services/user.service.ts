import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/BaseService';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User[]> {

  constructor(http: HttpClient) {
    super(http, 'user');
  }

  public findById(id: number): Observable<User> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
