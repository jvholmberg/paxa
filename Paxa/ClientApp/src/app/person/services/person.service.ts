import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { Person } from './person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonService extends BaseService<Person[]> {

  constructor(http: HttpClient) {
    super(http, 'person');
  }

  public findById(id: number): Observable<Person> {
    return this.get().pipe(
      map((collection) => collection.find((entity) => entity.id === id)),
    );
  }
}
