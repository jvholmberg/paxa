import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Resource } from '@resource/services/resource.model';
import { ResourceService } from '@resource/services/resource.service';

@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

  @Input() resourceId: number;
  resource$: Observable<Resource>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private resourceService: ResourceService,
  ) { }

  ngOnInit(): void {
    // If no id was provided; Check params
    if (this.resourceId === undefined || this.resourceId === null) {
      this.resourceId = +this.activatedRoute.snapshot.params['id'];
    }

    this.resource$ = this.resourceService.getById(this.resourceId);
  }

  onGoBack(): void {
    this.router.navigate(['/', 'resource'], {
      queryParamsHandling: 'merge',
    });
  }

}
