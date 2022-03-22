import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators, NgForm, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { logError } from '@utils/logger';
import { SchemaService } from '@schema/services/schema.service';
import { OrganizationService } from '@organization/services/organization.service';
import { Organization } from '@organization/services/organization.model';
import { LookupService } from '@shared/services/lookup-service/lookup.service';
import { Weekday } from '@shared/services/lookup-service/weekday.model';
import { SchemaEntry } from '@schema/services/schema-entry.model';

@Component({
  selector: 'app-schema-create',
  templateUrl: './schema-create.component.html',
  styleUrls: ['./schema-create.component.css']
})
export class SchemaCreateComponent implements OnInit {

  organizations$: Observable<Organization[]>;
  weekdays$: Observable<Weekday[]>;

  form: FormGroup;

  getSchemaEntries(weekdayNumber: number) {
    console.log(weekdayNumber);
    return this.form.controls[weekdayNumber] as FormArray;
  }

  constructor(
    private location: Location,
    private router: Router,
    private formBuilder: FormBuilder,
    private lookupService: LookupService,
    private organziationService: OrganizationService,
    private schemaService: SchemaService,
  ) { }

  ngOnInit(): void {
    this.organizations$ = this.organziationService.get();
    this.weekdays$ = this.lookupService.getWeekdays();

    this.form = this.initForm();
  }

  private initForm(): FormGroup {
    return this.formBuilder.group({
      organizationId: [null, Validators.required],
      name: ['', [Validators.required, Validators.minLength(2)]],
      resourceIds: [[], Validators.minLength(0)],
      0: this.formBuilder.array([]),
      1: this.formBuilder.array([]),
      2: this.formBuilder.array([]),
      3: this.formBuilder.array([]),
      4: this.formBuilder.array([]),
      5: this.formBuilder.array([]),
      6: this.formBuilder.array([]),
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      console.log(f)
      this.form.markAllAsTouched();
      return;
    }

    // Merge schema-entries
    const schemaEntries = [
      ...f.value[0],
      ...f.value[1],
      ...f.value[2],
      ...f.value[3],
      ...f.value[4],
      ...f.value[5],
      ...f.value[6],
    ];


    // Create body
    const body = {
      organizationId: f.value.organizationId,
      name: f.value.name,
      resourceIds: f.value.resourceIds,
      schemaEntries,
    };

    this.schemaService
      .create(body)
      .subscribe(
        (res) => {
          this.router.navigate(['/', 'schemas', res.id], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
