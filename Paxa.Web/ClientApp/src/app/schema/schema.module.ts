import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { SchemaCreateComponent } from './schema-create/schema-create.component';
import { SchemaEditComponent } from './schema-edit/schema-edit.component';
import { SchemaEntryListCreate } from './schema-entry-list-create/schema-entry-list-create.component';
import { SchemaListViewComponent } from './schema-list-view/schema-list-view.component';
import { SchemaListComponent } from './schema-list/schema-list.component';
import { SchemaRemoveComponent } from './schema-remove/schema-remove.component';
import { SchemaViewComponent } from './schema-view/schema-view.component';
import { SchemaRoutingModule } from './schema-routing.module';
import { SchemaComponent } from './schema.component';
import { SchemaExecuteComponent } from './schema-execute/schema-execute.component';

@NgModule({
  declarations: [
    SchemaCreateComponent,
    SchemaEditComponent,
    SchemaEntryListCreate,
    SchemaListComponent,
    SchemaListViewComponent,
    SchemaRemoveComponent,
    SchemaViewComponent,
    SchemaComponent,
    SchemaExecuteComponent,
  ],
  imports: [
    SharedModule,
    RouterModule,
    SchemaRoutingModule,
  ],
  exports: []
})
export class SchemaModule { }
