import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { LayoutUnknownComponent } from './layout-unknown/layout-unknown.component';
import { LayoutUserComponent } from './layout-user/layout-user.component';
import { LayoutAdminComponent } from './layout-admin/layout-admin.component';

const components = [
  LayoutUnknownComponent,
  LayoutUserComponent,
  LayoutAdminComponent,
];

@NgModule({
  declarations: [
    ...components,
  ],
  imports: [
    SharedModule,
  ],
  exports: [
    ...components,
  ]
})
export class LayoutModule { }
