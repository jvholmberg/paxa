import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceSchemaCreateComponent } from './resource-schema-create/resource-schema-create.component';
import { ResourceSchemaEditComponent } from './resource-schema-edit/resource-schema-edit.component';
import { ResourceSchemaListViewComponent } from './resource-schema-list-view/resource-schema-list-view.component';
import { ResourceSchemaListComponent } from './resource-schema-list/resource-schema-list.component';
import { ResourceSchemaRemoveComponent } from './resource-schema-remove/resource-schema-remove.component';
import { ResourceSchemaViewComponent } from './resource-schema-view/resource-schema-view.component';
import { SchemaRoutingModule } from './schema-routing.module';
import { SchemaComponent } from './schema.component';

@NgModule({
  declarations: [
    ResourceSchemaCreateComponent,
    ResourceSchemaEditComponent,
    ResourceSchemaListComponent,
    ResourceSchemaListViewComponent,
    ResourceSchemaRemoveComponent,
    ResourceSchemaViewComponent,
    SchemaComponent,
  ],
  imports: [
    SharedModule,
    RouterModule,
    SchemaRoutingModule,
  ],
  exports: []
})
export class SchemaModule { }
