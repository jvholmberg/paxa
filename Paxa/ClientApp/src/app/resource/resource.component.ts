import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ResourceService } from './services/resource.service';
import { Resource } from './services/resource.model';

@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {

  displayedColumns = ['name', 'action'];
  resourceCollection$: Observable<Resource[]>;
  
  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
    this.resourceCollection$ = this.resourceService.get();
  }
}
