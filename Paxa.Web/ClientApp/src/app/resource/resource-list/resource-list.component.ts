import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ResourceService } from '@resource/services/resource.service';
import { Resource } from '@resource/services/resource.model';

@Component({
  selector: 'app-resource-list',
  templateUrl: './resource-list.component.html',
  styleUrls: ['./resource-list.component.css']
})
export class ResourceListComponent  implements OnInit {

  @Input() organizationId: number;

  resources$: Observable<Resource[]>;

  headers = [
    { key: 'name', value: 'Name'},
    { title: '' },
  ];

  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
    const params = this.organizationId ? { organizationId: this.organizationId } : null;

    this.resources$ = params
      ? this.resourceService.query(params)
      : this.resourceService.get();
  }

  getUrl(resourceId: number, action: string): string[] {
    return [
      ...this.organizationId
        ? ['/', 'organization', `${this.organizationId}`, 'resource']
        : ['/', 'resource'],
      `${resourceId}`,
      action,
    ]
  }
}
