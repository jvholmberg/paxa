import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceFormComponent } from './resource-form/resource-form.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';


@NgModule({
  declarations: [
    ResourceComponent,
    ResourceListComponent,
    ResourceFormComponent,
    ResourceViewComponent,
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
