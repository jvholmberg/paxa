import { Component, Input, OnInit } from '@angular/core';
import { Link } from '@shared/models/link.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Input() mainLinks: Link[];
  @Input() userLinks: Link[];

  constructor() { }

  ngOnInit(): void {
  }

}
