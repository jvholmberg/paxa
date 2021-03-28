import { NgModule } from '@angular/core';
import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserViewComponent } from './user-view/user-view.component';
import { UserFormComponent } from './user-form/user-form.component';
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from '@shared/shared.module';
import { PersonModule } from '@person/person.module';
import { OrganizationModule } from '@organization/organization.module';

@NgModule({
  declarations: [
    UserComponent,
    UserListComponent,
    UserViewComponent,
    UserFormComponent,
  ],
  imports: [
    SharedModule,
    UserRoutingModule,
    PersonModule,
    OrganizationModule
  ]
})
export class UserModule { }
