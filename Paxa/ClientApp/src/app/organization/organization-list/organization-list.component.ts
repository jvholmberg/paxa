import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { faBuilding, faEdit, faPlus, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {

  displayedColumns = ['type', 'name', 'action'];
  organizations$: Observable<Organization[]>;

  iconFaPlus = faPlus;
  iconFaEdit = faEdit;
  iconFaBuilding = faBuilding;
  iconFaTrashAlt = faTrashAlt;

  constructor(private organizationService: OrganizationService) { }

  ngOnInit(): void {
    this.organizations$ = this.organizationService.get();
  }

}
