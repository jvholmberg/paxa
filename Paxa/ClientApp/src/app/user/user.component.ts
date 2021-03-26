import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './services/user.model';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  loading$: Observable<boolean> = this.userService.loading$;
  error$: Observable<Error> = this.userService.error$
  collection$: Observable<User[]> = this.userService.persons$;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.get();
  }

}
