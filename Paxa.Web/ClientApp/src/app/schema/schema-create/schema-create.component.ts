import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { logError } from '@utils/logger';
import { SchemaService } from '@schema/services/schema.service';
import { OrganizationService } from '@organization/services/organization.service';
import { ResourceType } from '@resource/services/resource-type.model';
import { Organization } from '@organization/services/organization.model';

@Component({
  selector: 'app-schema-create',
  templateUrl: './schema-create.component.html',
  styleUrls: ['./schema-create.component.css']
})
export class SchemaCreateComponent implements OnInit {

  organizations$: Observable<Organization[]>;
  resourceTypes$: Observable<ResourceType[]>;

  form: FormGroup;

  constructor(
    private location: Location,
    private router: Router,
    private formBuilder: FormBuilder,
    private organziationService: OrganizationService,
    private schemaService: SchemaService,
  ) { }

  ngOnInit(): void {
    this.organizations$ = this.organziationService.get();

    this.form = this.initForm();
  }

  private initForm(): FormGroup {
    return this.formBuilder.group({
      organizationId: [null, Validators.required],
      name: ['', [Validators.required, Validators.minLength(2)]],
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
