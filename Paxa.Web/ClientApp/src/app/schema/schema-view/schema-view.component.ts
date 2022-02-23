import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Schema } from '@schema/services/schema.model';
import { SchemaService } from '@schema/services/schema.service';

@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

  @Input() schemaId: number;
  schema$: Observable<Schema>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private schemaService: SchemaService,
  ) { }

  ngOnInit(): void {
    // If no id was provided; Check params
    if (this.schemaId === undefined || this.schemaId === null) {
      this.schemaId = +this.activatedRoute.snapshot.params['id'];
    }

    this.schema$ = this.schemaService.getById(this.schemaId);
  }

  onGoBack(): void {
    this.router.navigate(['/', 'schemas'], {
      queryParamsHandling: 'merge',
    });
  }

}
