import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchemaCreateComponent } from './schema-create/schema-create.component';
import { SchemaEditComponent } from './schema-edit/schema-edit.component';
import { SchemaListViewComponent } from './schema-list-view/schema-list-view.component';
import { SchemaRemoveComponent } from './schema-remove/schema-remove.component';
import { SchemaViewComponent } from './schema-view/schema-view.component';
import { SchemaComponent } from './schema.component';

const routes: Routes = [
  {
    path: '',
    component: SchemaComponent,
    children: [
      {
        path: '',
        component: SchemaListViewComponent,
        children: [
          { path: ':id/remove', component: SchemaRemoveComponent },
        ]
      },
      { path: 'create', component: SchemaCreateComponent },
      { path: ':id', component: SchemaViewComponent },
      { path: ':id/edit', component: SchemaEditComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchemaRoutingModule { }
