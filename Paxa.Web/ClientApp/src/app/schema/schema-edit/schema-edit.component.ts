import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { logError } from '@utils/logger';
import { Location } from '@angular/common';
import { Observable } from 'rxjs';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';
import { SchemaService } from '@schema/services/schema.service';
import { Schema } from '@schema/services/schema.model';

@Component({
  selector: 'app-schema-edit',
  templateUrl: './schema-edit.component.html',
  styleUrls: ['./schema-edit.component.css']
})
export class SchemaEditComponent implements OnInit {

  organizations$: Observable<Organization[]>;

  schemaId: number;
  form: FormGroup;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private organziationService: OrganizationService,
    private schemaService: SchemaService,
  ) { }

  ngOnInit(): void {
    this.organizations$ = this.organziationService.get();

    this.schemaId = +this.activatedRoute.snapshot.params['id'];
    this.schemaService.getById(this.schemaId).subscribe((schema) => {
      this.form = this.initForm(schema);
    });
  }

  private initForm(schema: Schema): FormGroup {
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
      .update(this.schemaId, f.value)
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
