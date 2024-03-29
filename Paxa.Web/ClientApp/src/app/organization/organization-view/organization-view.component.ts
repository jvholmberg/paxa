import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';

@Component({
  selector: 'app-organization-view',
  templateUrl: './organization-view.component.html',
  styleUrls: ['./organization-view.component.css']
})
export class OrganizationViewComponent implements OnInit {

  @Input() organizationId: number;
  organization$: Observable<Organization>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private organizationService: OrganizationService,
  ) { }

  ngOnInit(): void {
    // If no id was provided; Check params
    if (this.organizationId === undefined || this.organizationId === null) {
      this.organizationId = +this.activatedRoute.snapshot.params['id'];
    }

    this.organization$ = this.organizationService.getById(this.organizationId);
  }

  onGoBack(): void {
    this.router.navigate(['/', 'organization'], {
      queryParamsHandling: 'merge',
    });
  }

}
