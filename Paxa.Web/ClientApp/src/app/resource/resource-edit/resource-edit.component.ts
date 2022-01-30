import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { logError } from '@utils/logger';
import { ResourceType } from '@resource/services/resource-type.model';
import { Resource } from '@resource/services/resource.model';
import { ResourceService } from '@resource/services/resource.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-resource-edit',
  templateUrl: './resource-edit.component.html',
  styleUrls: ['./resource-edit.component.css']
})
export class ResourceEditComponent implements OnInit {

  resourceTypes$: Observable<ResourceType[]>;

  resourceId: number;
  form: FormGroup;

  constructor(
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private resourceService: ResourceService,
  ) { }

  ngOnInit(): void {
    this.resourceTypes$ = this.resourceService.getTypes();

    this.resourceId = +this.activatedRoute.snapshot.params['id'];
    this.resourceService.getById(this.resourceId).subscribe((resource) => {
      this.form = this.initForm(resource);
    })
  }

  private initForm(resource: Resource): FormGroup {
    console.log('ada',resource);
    return this.formBuilder.group({
      name: [resource.name, [Validators.required, Validators.minLength(2)]],
      typeId: [resource.type.id, Validators.required],
    });
  }

  onSubmit(f: NgForm): void {
    if (f.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.resourceService
      .update(this.resourceId, f.value)
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
