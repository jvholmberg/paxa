import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SchemaService } from '@schema/services/schema.service';

@Component({
  selector: 'app-schema-execute',
  templateUrl: './schema-execute.component.html',
  styleUrls: ['./schema-execute.component.css']
})
export class SchemaExecuteComponent implements OnInit {

  @Input() schemaId: number;

  constructor(private schemaService: SchemaService) { }

  ngOnInit(): void {}

  onSubmit(f: NgForm): void {

    this.schemaService.execute(this.schemaId, 0, 0, 0)
  }

  onCancel(): void {

  }
}
