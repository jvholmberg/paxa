import { Injectable } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Injectable({
  providedIn: 'root'
})
export class PersonGuard implements CanLoad {
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
