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

@Component({
  selector: 'app-schema-create',
  templateUrl: './schema-create.component.html',
  styleUrls: ['./schema-create.component.css']
})
export class SchemaCreateComponent implements OnInit {

  organizations$: Observable<Organization[]>;
  weekdays$: Observable<Weekday[]>;

  form: FormGroup;

  get schemaEntries() {
    return this.form.controls["schemaEntries"] as FormArray;
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
      schemaEntries: this.formBuilder.array([], Validators.minLength(0)),
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.schemaService
      .create(f.value)
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
