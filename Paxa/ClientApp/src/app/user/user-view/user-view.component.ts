import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import BaseServiceStatus from '@core/base-service/base-serivce-status';
import { User } from '@user/services/user.model';
import { UserService } from '@user/services/user.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {

  user$: Observable<User>;
  followers$: Observable<User[]>;
  following$: Observable<User[]>;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
  ) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.user$ = this.userService.findByUserId(id);

  }

}
