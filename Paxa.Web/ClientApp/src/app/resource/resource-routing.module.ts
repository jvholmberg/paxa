import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourceComponent } from './resource.component';
import { ResourceListViewComponent } from './resource-list-view/resource-list-view.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { ResourceCreateComponent } from './resource-create/resource-create.component';
import { ResourceEditComponent } from './resource-edit/resource-edit.component';
import { ResourceRemoveComponent } from './resource-remove/resource-remove.component';

const routes: Routes = [
  {
    path: '',
    component: ResourceComponent,
    children: [
      {
        path: '',
        component: ResourceListViewComponent,
        children: [
          { path: ':id/remove', component: ResourceRemoveComponent },
        ]
      },
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
