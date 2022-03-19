import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators, NgForm, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { logError } from '@utils/logger';
import { SchemaService } from '@schema/services/schema.service';
import { OrganizationService } from '@organization/services/organization.service';
import { Organization } from '@organization/services/organization.model';

@Component({
  selector: 'app-schema-entry-list-create',
  templateUrl: './schema-entry-list-create.component.html',
  styleUrls: ['./schema-entry-list-create.component.css']
})
export class SchemaEntryListCreate implements OnInit {
  @Input() schemaId: number;
  @Input() weekdayId: number;
  @Input() schemaEntries: FormArray;

  constructor(
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {

  }

  onAddEntry(): void {

    const entryForm = this.formBuilder.group({
      fromTimestamp: [null, Validators.required],
      toTimestamp: [null, [Validators.required]],
      weekdayId: this.weekdayId,
    });
    this.schemaEntries.push(entryForm);
  }

  onDeleteEntry(entryIndex: number): void {
    this.schemaEntries.removeAt(entryIndex);
  }
}
