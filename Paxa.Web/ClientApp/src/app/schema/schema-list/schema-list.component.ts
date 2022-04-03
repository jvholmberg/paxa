import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { faCircle } from '@fortawesome/free-solid-svg-icons';
import { Schema } from '@schema/services/schema.model';
import { SchemaService } from '@schema/services/schema.service';

@Component({
  selector: 'app-schema-list',
  templateUrl: './schema-list.component.html',
  styleUrls: ['./schema-list.component.css']
})
export class SchemaListComponent  implements OnInit {

  @Input() organizationId: number;

  faCircle = faCircle;

  schemas$: Observable<Schema[]>;

  constructor(private schemaService: SchemaService) { }

  ngOnInit(): void {
    const params = this.organizationId ? { organizationId: this.organizationId } : null;
    console.log(params);
    this.schemas$ = params
      ? this.schemaService.query(params)
      : this.schemaService.get();
  }

  getUrl(resourceId: number, action: string): string[] {
    return [
      ...this.organizationId
        ? ['/', 'organization', `${this.organizationId}`, 'schemas']
        : ['/', 'schemas'],
      `${resourceId}`,
      action,
    ]
  }
}
