import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonService } from '@person/services/person.service';
import { Person } from '@person/services/person.model';
import { share } from 'rxjs/operators';

@Component({
  selector: 'app-person-view',
  templateUrl: './person-view.component.html',
  styleUrls: ['./person-view.component.css']
})
export class PersonViewComponent implements OnInit {

  @Input() personId: number;
  person$: Observable<Person>;

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.person$ = this.personService
      .getById(this.personId)
      .pipe(
        share(),
      );
  }

}
