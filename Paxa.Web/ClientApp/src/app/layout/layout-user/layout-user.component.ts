import { Component, OnInit } from '@angular/core';
import { Link } from '@shared/models/link.model';

@Component({
  selector: 'app-layout-user',
  templateUrl: './layout-user.component.html',
  styleUrls: ['./layout-user.component.css']
})
export class LayoutUserComponent implements OnInit {

  mainLinks: Link[] = [
    { path: ['/', 'organization'], text: 'Organization'},
    { path: ['/', 'resource'], text: 'Resource'},
    { path: ['/', 'schemas'], text: 'Schemas'},
    { path: ['/', 'timeslot'], text: 'Timeslot'},
    { path: ['/', 'user'], text: 'User'},
    { path: ['/', 'booking'], text: 'Booking'},
    { path: ['/', 'person'], text: 'Person'},
  ];

  userLinks: Link[] = [
    { path: ['/', 'logout'], text: 'Logout'},
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
