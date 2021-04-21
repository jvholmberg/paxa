import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PersonComponent } from './person.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonViewComponent } from './person-view/person-view.component';
import { PersonFormComponent } from './person-form/person-form.component';

const routes: Routes = [
  { path: '', component: PersonComponent, pathMatch: 'full' },
  { path: 'all', component: PersonListComponent },
  { path: 'create', component: PersonFormComponent },
  { path: ':personId', redirectTo: ':personId/view', pathMatch: 'full' },
  { path: ':personId/view', component: PersonViewComponent },
  { path: ':personId/edit', component: PersonFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonRoutingModule { }
