import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { share } from 'rxjs/operators';
import { User } from '@user/services/user.model';
import { UserService } from '@user/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {

  @Input() userId: number;

  user$: Observable<User>;

  constructor(
    private userService: UserService,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    // If no id was provided; Check params
    if (this.userId === undefined || this.userId === null) {
      this.userId = +this.activatedRoute.snapshot.params['userId'];
    }

    this.user$ = this.userService
      .getById(this.userId, false)
      .pipe(
        share(),
      );
  }

}
