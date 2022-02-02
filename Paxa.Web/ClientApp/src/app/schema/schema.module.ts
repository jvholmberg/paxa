import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { ResourceSchemaCreateComponent } from './resource-schema-create/resource-schema-create.component';
import { ResourceSchemaEditComponent } from './resource-schema-edit/resource-schema-edit.component';

@NgModule({
  declarations: [
    ResourceSchemaCreateComponent,
    ResourceSchemaEditComponent,
  ],
  imports: [
    SharedModule,
  ],
  exports: [
    ResourceSchemaCreateComponent,
    ResourceSchemaEditComponent,
  ]
})
export class SchemaModule { }
