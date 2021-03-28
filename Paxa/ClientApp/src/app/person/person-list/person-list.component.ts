import { Component, Input, OnInit } from '@angular/core';
import { Person } from '@person/services/person.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  @Input() loading: boolean;
  @Input() error: Error;
  @Input() collection: Person[];

  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'actions',
  ];

  constructor() { }

  ngOnInit(): void {}

}
