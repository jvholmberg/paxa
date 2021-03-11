import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { ResourceFormComponent } from './resource-form/resource-form.component';

const routes: Routes = [
  { path: '', component: ResourceComponent, pathMatch: 'full' },
  { path: 'all', component: ResourceListComponent },
  { path: 'create', component: ResourceFormComponent },
  { path: ':id', redirectTo: ':id/view', pathMatch: 'full' },
  { path: ':id/view', component: ResourceViewComponent },
  { path: ':id/edit', component: ResourceFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourceRoutingModule { }
