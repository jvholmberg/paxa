import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonComponent } from './person.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonViewComponent } from './person-view/person-view.component';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonRoutingModule } from './person-routing.module';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  declarations: [
    PersonComponent,
    PersonListComponent,
    PersonViewComponent,
    PersonFormComponent,
  ],
  imports: [
    SharedModule,
    PersonRoutingModule
  ]
})
export class PersonModule { }
