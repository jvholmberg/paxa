import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {

  organizations$: Observable<Organization[]>;

  headers = [
    { key: 'name', value: 'Name'},
    { value: '' },
  ];

  constructor(private organizationService: OrganizationService) { }

  ngOnInit(): void {
    this.organizations$ = this.organizationService.get();
  }

}
