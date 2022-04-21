import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base.service';
import { Observable } from 'rxjs';
import { Schema } from './schema.model';

@Injectable({
  providedIn: 'root'
})
export class SchemaService extends BaseService<Schema> {

  constructor(http: HttpClient) {
    super(http, 'schemas');
  }

  execute(id: number, year: number, month: number, day: number): Observable<any> {
    return this.http.post(`${this.serviceUrl}/execute`, {
      id,
      year,
      month,
      day,
    });
  }
}
