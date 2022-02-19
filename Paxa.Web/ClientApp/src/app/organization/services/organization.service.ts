import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/base-service/base.service';
import { Organization } from './organization.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService extends BaseService<Organization> {

  constructor(http: HttpClient) {
    super(http, 'organizations');
  }
}
