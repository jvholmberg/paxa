import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private authorizationService: AuthorizationService) { }

  ngOnInit(): void {
    this.authorizationService
      .revokeToken()
      .subscribe(() => {
        // TODO: Prevent user from backtracking
      });
  }

}
