import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { logError } from '@utils/logger';
import { OrganizationService } from '@organization/services/organization.service';
import { Organization } from '@organization/services/organization.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-organization-remove',
  templateUrl: './organization-remove.component.html',
  styleUrls: ['./organization-remove.component.css']
})
export class OrganizationRemoveComponent implements OnInit {

  organizationId: number;
  organization$: Observable<Organization>;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private organizationService: OrganizationService,
  ) { }

  ngOnInit(): void {
    this.organizationId = +this.activatedRoute.snapshot.params['id'];
    this.organization$ = this.organizationService.getById(this.organizationId);
  }

  onDelete(): void {
    this.organizationService
      .delete(this.organizationId)
      .subscribe(
        () => {
          this.router.navigate(['/', 'organization'], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
