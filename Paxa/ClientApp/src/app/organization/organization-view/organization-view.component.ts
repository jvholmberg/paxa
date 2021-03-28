import { Component, Input, OnInit } from '@angular/core';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-organization-view',
  templateUrl: './organization-view.component.html',
  styleUrls: ['./organization-view.component.css']
})
export class OrganizationViewComponent implements OnInit {

  @Input() organizationId: number;
  organization$: Observable<Organization>;

  constructor(private organizationService: OrganizationService) { }

  ngOnInit(): void {
    this.organization$ = this.organizationService.getById(this.organizationId);
  }

}
