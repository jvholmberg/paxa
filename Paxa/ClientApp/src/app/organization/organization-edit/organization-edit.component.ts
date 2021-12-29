import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { logError } from '@utils/logger';
import { OrganizationService } from '@organization/services/organization.service';
import { Organization } from '@organization/services/organization.model';

@Component({
  selector: 'app-organization-edit',
  templateUrl: './organization-edit.component.html',
  styleUrls: ['./organization-edit.component.css']
})
export class OrganizationEditComponent implements OnInit {

  organizationId: number;

  form: FormGroup;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private organizationService: OrganizationService,
    ) { }

  ngOnInit(): void {
    this.organizationId = +this.activatedRoute.snapshot.params['id'];
    this.organizationService.getById(this.organizationId).subscribe((organization) => {
      this.form = this.initForm(organization);
    });
  }

  private initForm(organization: Organization): FormGroup {
    return this.formBuilder.group({
      name: [organization?.name, [Validators.required, Validators.minLength(2)]],
      description: [organization?.description],
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.organizationService
      .update(this.organizationId, f.value)
      .subscribe(
        (res) => {
          this.router.navigate(['/', 'organization', res.id], { replaceUrl: true });
        },
        (err) => {
          logError(err);
        });
  }

  onCancel(): void {
    this.location.back();
  }

}
