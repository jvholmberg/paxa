import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { OrganizationService } from '@organization/services/organization.service';
import { Router } from '@angular/router';
import { logError } from '@utils/logger';

@Component({
  selector: 'app-organization-create',
  templateUrl: './organization-create.component.html',
  styleUrls: ['./organization-create.component.css']
})
export class OrganizationCreateComponent implements OnInit {

  form: FormGroup;

  constructor(
    private location: Location,
    private router: Router,
    private formBuilder: FormBuilder,
    private organizationService: OrganizationService,
  ) { }

  ngOnInit(): void {
    this.form = this.initForm();
  }

  private initForm(): FormGroup {
    return this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: [''],
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.organizationService
      .create(f.value)
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
