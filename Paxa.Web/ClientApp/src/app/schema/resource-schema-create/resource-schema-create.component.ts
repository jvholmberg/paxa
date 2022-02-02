import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { logError } from '@utils/logger';
import { ResourceService } from '@resource/services/resource.service';
import { Location } from '@angular/common';
import { Observable } from 'rxjs';
import { ResourceType } from '@resource/services/resource-type.model';
import { Organization } from '@organization/services/organization.model';
import { OrganizationService } from '@organization/services/organization.service';

@Component({
  selector: 'app-resource-schema-create',
  templateUrl: './resource-schema-create.component.html',
  styleUrls: ['./resource-schema-create.component.css']
})
export class ResourceSchemaCreateComponent implements OnInit {

  organizations$: Observable<Organization[]>;
  resourceTypes$: Observable<ResourceType[]>;

  form: FormGroup;

  constructor(
    private location: Location,
    private router: Router,
    private formBuilder: FormBuilder,
    private organziationService: OrganizationService,
    private resourceService: ResourceService,
  ) { }

  ngOnInit(): void {
    this.organizations$ = this.organziationService.get();
    this.resourceTypes$ = this.resourceService.getTypes();

    this.form = this.initForm();
  }

  private initForm(): FormGroup {
    return this.formBuilder.group({
      organizationId: [null, Validators.required],
      name: ['', [Validators.required, Validators.minLength(2)]],
      typeId: [null, Validators.required],
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.resourceService
      .create(f.value)
      .subscribe(
        (res) => {
          this.router.navigate(['/', 'resource', res.id], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
