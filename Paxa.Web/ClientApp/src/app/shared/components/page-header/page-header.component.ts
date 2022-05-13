import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faAngleLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {

  @Input() title: string;
  @Input() subtitle: string;

  @Output() goBack: EventEmitter<void> = new EventEmitter();

  faAngleLeft = faAngleLeft;

  constructor() { }

  ngOnInit(): void {}

}
