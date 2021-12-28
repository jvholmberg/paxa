import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { ResourceCreateComponent } from './resource-create/resource-create.component';
import { ResourceEditComponent } from './resource-edit/resource-edit.component';

const routes: Routes = [
  {
    path: '',
    component: ResourceComponent,
    children: [
      { path: '', component: ResourceListComponent },
      { path: 'create', component: ResourceCreateComponent },
      { path: ':id', component: ResourceViewComponent },
      { path: ':id/edit', component: ResourceEditComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourceRoutingModule { }
