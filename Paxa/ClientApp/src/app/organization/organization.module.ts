import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceModule } from '@resource/resource.module';
import { OrganizationComponent } from '../organization/organization.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationRoutingModule } from './organization-routing.module';
import { OrganizationEditComponent } from './organization-edit/organization-edit.component';
import { OrganizationViewComponent } from './organization-view/organization-view.component';
import { OrganizationCreateComponent } from './organization-create/organization-create.component';

@NgModule({
  declarations: [
    OrganizationComponent,
    OrganizationListComponent,
    OrganizationEditComponent,
    OrganizationViewComponent,
    OrganizationCreateComponent,
  ],
  imports: [
    SharedModule,
    RouterModule,
    OrganizationRoutingModule,
    ResourceModule,
  ],
  exports: [
    OrganizationViewComponent,
  ]
})
export class OrganizationModule { }
