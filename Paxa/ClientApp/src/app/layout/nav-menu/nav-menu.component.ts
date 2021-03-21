import { Component } from '@angular/core';
import { HttpsStatusService } from '@core/http-status/https-status.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  isExpanded = false;

  isLoading$ = this.httpsStatusService.loading$;

  constructor(
    private httpsStatusService: HttpsStatusService,
  ) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
