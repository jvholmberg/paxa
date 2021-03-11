import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationComponent } from './organization.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationViewComponent } from './organization-view/organization-view.component';
import { OrganizationFormComponent } from './organization-form/organization-form.component';

const routes: Routes = [
  { path: '', component: OrganizationComponent, pathMatch: 'full' },
  { path: 'all', component: OrganizationListComponent },
  { path: 'create', component: OrganizationFormComponent },
  { path: ':id', redirectTo: ':id/view', pathMatch: 'full' },
  { path: ':id/view', component: OrganizationViewComponent },
  { path: ':id/edit', component: OrganizationFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationRoutingModule { }
