import { Component, Input, OnInit } from '@angular/core';
import { Link } from '@shared/models/link.model';

@Component({
  selector: 'app-profile-dropdown',
  templateUrl: './profile-dropdown.component.html',
  styleUrls: ['./profile-dropdown.component.css']
})
export class ProfileDropdownComponent implements OnInit {

  @Input() links: Link[];

  isOpen = false;

  constructor() { }

  ngOnInit(): void {}

  onSetOpen(open: boolean): void {
    this.isOpen = open;
  }


}
