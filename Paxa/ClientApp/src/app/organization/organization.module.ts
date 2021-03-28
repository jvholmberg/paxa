import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrganizationComponent } from '../organization/organization.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationRoutingModule } from './organization-routing.module';
import { OrganizationFormComponent } from './organization-form/organization-form.component';
import { OrganizationViewComponent } from './organization-view/organization-view.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [OrganizationComponent, OrganizationListComponent, OrganizationFormComponent, OrganizationViewComponent],
  imports: [
    SharedModule,
    RouterModule,
    OrganizationRoutingModule,
  ],
  exports: [
    OrganizationViewComponent,
  ]
})
export class OrganizationModule { }
