import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { share } from 'rxjs/operators';
import { User } from '@user/services/user.model';
import { UserService } from '@user/services/user.service';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {

  @Input() userId: number;

  user$: Observable<User>;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.user$ = this.userService
      .getById(this.userId)
      .pipe(
        share(),
      );
  }

}
