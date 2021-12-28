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

  displayedColumns = ['name', 'action'];
  resourceCollection$: Observable<Resource[]>;

  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
    this.resourceCollection$ = this.resourceService.get({
      organizationId: this.organizationId,
    });
  }
}
