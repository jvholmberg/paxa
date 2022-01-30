import { Component } from '@angular/core';
import { UserService } from '@user/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn$ = this.userService.loggedIn$;

  constructor(private userService: UserService) {}
}
