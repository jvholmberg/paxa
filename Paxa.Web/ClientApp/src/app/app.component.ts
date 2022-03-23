import { Component, ViewEncapsulation } from '@angular/core';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class AppComponent {
  isLoggedIn$ = this.authorizationService.loggedIn$;

  constructor(private authorizationService: AuthorizationService) {}
}
