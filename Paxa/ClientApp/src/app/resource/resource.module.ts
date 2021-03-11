import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ResourceComponent } from './resource.component';
import { ResourceListComponent } from './resource-list/resource-list.component';
import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceFormComponent } from './resource-form/resource-form.component';
import { ResourceViewComponent } from './resource-view/resource-view.component';
import { SharedModule } from '../shared/shared.module';

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
  ]
})
export class ResourceModule { }
