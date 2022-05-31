import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceListViewComponent } from './resource-list-view/resource-list-view.component';
import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceCreateComponent } from './resource-create/resource-create.component';
import { ResourceEditComponent } from './resource-edit/resource-edit.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { ResourceRemoveComponent } from './resource-remove/resource-remove.component';
import { TimeslotModule } from '@timeslot/timeslot.module';

@NgModule({
  declarations: [
    ResourceComponent,
    ResourceListComponent,
    ResourceListViewComponent,
    ResourceCreateComponent,
    ResourceEditComponent,
    ResourceViewComponent,
    ResourceRemoveComponent,
  ],
  imports: [
    SharedModule,
    RouterModule,
    ResourceRoutingModule,
    TimeslotModule,
  ],
  exports: [
    ResourceListComponent,
    ResourceRemoveComponent,
  ]
})
export class ResourceModule { }
