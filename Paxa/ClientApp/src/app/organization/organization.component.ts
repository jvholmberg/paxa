import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrganizationService } from './services/organization.service';
import { Organization } from './services/organization.model';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.css']
})
export class OrganizationComponent implements OnInit {

  displayedColumns = ['name', 'action'];
  organizationCollection$: Observable<Organization[]>;
  
  constructor(private organizationService: OrganizationService) { }

  ngOnInit(): void {
    this.organizationCollection$ = this.organizationService.get();
  }
}
