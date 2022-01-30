import { Component, OnInit } from '@angular/core';
import { UserService } from '@user/services/user.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService
      .revokeToken()
      .subscribe(() => {
        // TODO: Prevent user from backtracking
      });
  }

}
