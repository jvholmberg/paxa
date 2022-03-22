import { Component, OnInit } from '@angular/core';
import { Link } from '@shared/models/link.model';

@Component({
  selector: 'app-layout-unknown',
  templateUrl: './layout-unknown.component.html',
  styleUrls: ['./layout-unknown.component.css']
})
export class LayoutUnknownComponent implements OnInit {

  mainLinks: Link[] = [
    { path: ['/', 'welcome'], text: 'Landing'},
    { path: ['/', 'get-started'], text: 'Get started'},
  ];

  userLinks: Link[] = [
    { path: ['/', 'login'], text: 'Login'},
  ];

  constructor() { }

  ngOnInit(): void {}

}
