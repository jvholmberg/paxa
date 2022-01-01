import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationComponent } from './organization.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationViewComponent } from './organization-view/organization-view.component';
import { OrganizationEditComponent } from './organization-edit/organization-edit.component';
import { OrganizationCreateComponent } from './organization-create/organization-create.component';
import { OrganizationRemoveComponent } from './organization-remove/organization-remove.component';

const routes: Routes = [
  {
    path: '',
    component: OrganizationComponent,
    children: [
      {
        path: '',
        component: OrganizationListComponent,
        children: [
          { path: ':id/remove', component: OrganizationRemoveComponent },
        ]
      },
      { path: 'create', component: OrganizationCreateComponent },
      { path: ':id', component: OrganizationViewComponent },
      { path: ':id/edit', component: OrganizationEditComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationRoutingModule { }
