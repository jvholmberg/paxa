import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserViewComponent } from './user-view/user-view.component';
import { UserFormComponent } from './user-form/user-form.component';

const routes: Routes = [
  { path: '', component: UserComponent, pathMatch: 'full' },
  { path: 'all', component: UserListComponent },
  { path: 'create', component: UserFormComponent },
  { path: ':userId', redirectTo: ':userId/view', pathMatch: 'full' },
  { path: ':userId/view', component: UserViewComponent },
  { path: ':userId/edit', component: UserFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
