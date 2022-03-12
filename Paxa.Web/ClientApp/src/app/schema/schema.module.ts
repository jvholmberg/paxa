import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { SchemaCreateComponent } from './schema-create/schema-create.component';
import { SchemaEditComponent } from './schema-edit/schema-edit.component';
import { SchemaEntryListEdit } from './schema-entry-list-edit/schema-entry-list-edit.component';
import { SchemaListViewComponent } from './schema-list-view/schema-list-view.component';
import { SchemaListComponent } from './schema-list/schema-list.component';
import { SchemaRemoveComponent } from './schema-remove/schema-remove.component';
import { SchemaViewComponent } from './schema-view/schema-view.component';
import { SchemaRoutingModule } from './schema-routing.module';
import { SchemaComponent } from './schema.component';

@NgModule({
  declarations: [
    SchemaCreateComponent,
    SchemaEditComponent,
    SchemaEntryListEdit,
    SchemaListComponent,
    SchemaListViewComponent,
    SchemaRemoveComponent,
    SchemaViewComponent,
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
