import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourceSchemaCreateComponent } from './resource-schema-create/resource-schema-create.component';
import { ResourceSchemaEditComponent } from './resource-schema-edit/resource-schema-edit.component';
import { ResourceSchemaListViewComponent } from './resource-schema-list-view/resource-schema-list-view.component';
import { ResourceSchemaRemoveComponent } from './resource-schema-remove/resource-schema-remove.component';
import { ResourceSchemaViewComponent } from './resource-schema-view/resource-schema-view.component';
import { SchemaComponent } from './schema.component';

const routes: Routes = [
  {
    path: '',
    component: SchemaComponent,
    children: [
      {
        path: '',
        component: ResourceSchemaListViewComponent,
        children: [
          { path: ':id/remove', component: ResourceSchemaRemoveComponent },
        ]
      },
      { path: 'create', component: ResourceSchemaCreateComponent },
      { path: ':id', component: ResourceSchemaViewComponent },
      { path: ':id/edit', component: ResourceSchemaEditComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchemaRoutingModule { }
