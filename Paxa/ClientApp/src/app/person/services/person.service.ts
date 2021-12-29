import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base-service';
import { Person } from './person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonService extends BaseService<Person> {

  constructor(http: HttpClient) {
    super(http, 'person');
  }
}
