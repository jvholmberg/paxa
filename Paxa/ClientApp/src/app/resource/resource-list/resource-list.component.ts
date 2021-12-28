import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { faBuilding, faEdit, faPlus, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { ResourceService } from '@resource/services/resource.service';
import { Resource } from '@resource/services/resource.model';

@Component({
  selector: 'app-resource-list',
  templateUrl: './resource-list.component.html',
  styleUrls: ['./resource-list.component.css']
})
export class ResourceListComponent  implements OnInit {

  @Input() organizationId: number;

  displayedColumns = ['name', 'action'];
  resources$: Observable<Resource[]>;

  iconFaPlus = faPlus;
  iconFaEdit = faEdit;
  iconFaBuilding = faBuilding;
  iconFaTrashAlt = faTrashAlt;

  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
    const params = this.organizationId ? { organizationId: this.organizationId } : null;
    this.resources$ = this.resourceService.query(params);
  }
}
