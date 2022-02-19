import { Component } from '@angular/core';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn$ = this.authorizationService.loggedIn$;

  constructor(private authorizationService: AuthorizationService) {}
}
