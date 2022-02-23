import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base.service';
import { Schema } from './schema.model';

@Injectable({
  providedIn: 'root'
})
export class SchemaService extends BaseService<Schema> {

  constructor(http: HttpClient) {
    super(http, 'schemas');
  }
}
