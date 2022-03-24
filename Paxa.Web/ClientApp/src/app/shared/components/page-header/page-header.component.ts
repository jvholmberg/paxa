import { Component, Input, OnInit } from '@angular/core';
import { faAngleLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {

  @Input() title: string;
  @Input() subtitle: string;

  faAngleLeft = faAngleLeft;

  constructor() { }

  ngOnInit(): void {
  }

}
