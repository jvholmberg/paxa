import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceCreateComponent } from './resource-create/resource-create.component';
import { ResourceEditComponent } from './resource-edit/resource-edit.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { ResourceRemoveComponent } from './resource-remove/resource-remove.component';


@NgModule({
  declarations: [
    ResourceComponent,
    ResourceListComponent,
    ResourceCreateComponent,
    ResourceEditComponent,
    ResourceViewComponent,
    ResourceRemoveComponent,
  ],
  imports: [
    SharedModule,
    RouterModule,
    ResourceRoutingModule,
  ],
  exports: [
    ResourceListComponent,
  ]
})
export class ResourceModule { }
