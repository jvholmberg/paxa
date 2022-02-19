import { Injectable } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrganizationGuard implements CanLoad {

  constructor(
    private router: Router,
    private authorizationService: AuthorizationService,
    ) {}

  canLoad(route: Route, segments: UrlSegment[]): Observable<boolean | UrlTree> {
    return this.authorizationService.loggedIn$.pipe(
      take(1),
      map((loggedIn: boolean) => {
        return loggedIn
          ? true
          : this.router.parseUrl('/not-allowed');
      }),
    );
  }
}
