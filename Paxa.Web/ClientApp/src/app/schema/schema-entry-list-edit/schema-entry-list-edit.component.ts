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
  selector: 'app-schema-entry-list-edit',
  templateUrl: './schema-entry-list-edit.component.html',
  styleUrls: ['./schema-entry-list-edit.component.css']
})
export class SchemaEntryListEdit implements OnInit {
  @Input() schemaIdId: number;
  @Input() weekdayId: number;
  @Input() schemaEntries: FormArray;

  constructor(
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {}

  onAddEntry(): void {

    const entryForm = this.formBuilder.group({
      fromTimestamp: [null, Validators.required],
      toTimestamp: [null, Validators.required],
      weekdayId:[null, Validators.required],
      schemaId:[null, Validators.required],
    });
    this.schemaEntries.push(entryForm);
  }

  onDeleteEntry(entryIndex: number): void {
    this.schemaEntries.removeAt(entryIndex);
  }
}
