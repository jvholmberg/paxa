import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Observable } from 'rxjs';
import { logError } from '@utils/logger';
import { SchemaService } from '@schema/services/schema.service';
import { Schema } from '@schema/services/schema.model';

@Component({
  selector: 'app-schema-remove',
  templateUrl: './schema-remove.component.html',
  styleUrls: ['./schema-remove.component.css']
})
export class SchemaRemoveComponent implements OnInit {

  schemaId: number;
  schema$: Observable<Schema>;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private schemaService: SchemaService,
    ) { }

  ngOnInit(): void {
    this.schemaId = +this.activatedRoute.snapshot.params['id'];
    this.schema$ = this.schemaService.getById(this.schemaId);
  }

  onDelete(): void {
    this.schemaService
      .delete(this.schemaId)
      .subscribe(
        () => {
          this.router.navigate(['/', 'schemas'], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
