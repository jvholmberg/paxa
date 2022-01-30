import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from './services/person.model';
import { PersonService } from './services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
  persons$: Observable<Person[]>;

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.persons$ = this.personService.get(true);
  }

}
