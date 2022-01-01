import { Component } from '@angular/core';
import { HttpsStatusService } from '@core/http-status/https-status.service';
import { UserService } from '@user/services/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent {

  public kendokaAvatar =
    "https://www.telerik.com/kendo-angular-ui-develop/components/navigation/appbar/assets/kendoka-angular.png";
  isExpanded = false;
  isLoading$ = this.httpsStatusService.loading$;
  isLoggedIn$ = this.userService.loggedIn$;

  constructor(
    private httpsStatusService: HttpsStatusService,
    private userService: UserService,
  ) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
