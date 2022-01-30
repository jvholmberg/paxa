import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceModule } from '@resource/resource.module';
import { OrganizationComponent } from '../organization/organization.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationListViewComponent } from './organization-list-view/organization-list-view.component';
import { OrganizationRoutingModule } from './organization-routing.module';
import { OrganizationEditComponent } from './organization-edit/organization-edit.component';
import { OrganizationViewComponent } from './organization-view/organization-view.component';
import { OrganizationCreateComponent } from './organization-create/organization-create.component';
import { OrganizationRemoveComponent } from './organization-remove/organization-remove.component';

@NgModule({
  declarations: [
    OrganizationComponent,
    OrganizationListComponent,
    OrganizationListViewComponent,
    OrganizationEditComponent,
    OrganizationViewComponent,
    OrganizationCreateComponent,
    OrganizationRemoveComponent,
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
