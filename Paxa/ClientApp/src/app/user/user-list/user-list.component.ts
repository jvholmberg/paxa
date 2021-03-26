import { Component, Input, OnInit } from '@angular/core';
import { User } from '@user/services/user.model';
import { UserService } from '@user/services/user.service';
import { Observable } from 'rxjs';
import { map, skipWhile } from 'rxjs/operators';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  @Input() loading: boolean;
  @Input() error: Error;
  @Input() collection: User[];

  @Input() displayedColumns: string[] = [
    'person.firstName',
    'person.lastName',
    'email',
    'actions',
  ];

  constructor(private userService: UserService) { }

  ngOnInit(): void {}

}
