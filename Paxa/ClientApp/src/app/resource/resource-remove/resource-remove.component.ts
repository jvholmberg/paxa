import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Resource } from '@resource/services/resource.model';
import { logError } from '@utils/logger';
import { ResourceService } from '@resource/services/resource.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-resource-remove',
  templateUrl: './resource-remove.component.html',
  styleUrls: ['./resource-remove.component.css']
})
export class ResourceRemoveComponent implements OnInit {

  resourceId: number;
  resource$: Observable<Resource>;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private resourceService: ResourceService,
    ) { }

  ngOnInit(): void {
    this.resourceId = +this.activatedRoute.snapshot.params['id'];
    this.resourceService.getById(this.resourceId);
  }

  onDelete(): void {
    this.resourceService
      .delete(this.resourceId)
      .subscribe(
        () => {
          this.router.navigate(['/', 'resource'], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
