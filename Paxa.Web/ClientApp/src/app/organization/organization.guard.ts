import { Injectable } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { UserService } from '@user/services/user.service';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrganizationGuard implements CanLoad {

  constructor(
    private router: Router,
    private userService: UserService,
    ) {}

  canLoad(route: Route, segments: UrlSegment[]): Observable<boolean | UrlTree> {
    return this.userService.loggedIn$.pipe(
      take(1),
      map((loggedIn: boolean) => {
        return loggedIn
          ? true
          : this.router.parseUrl('/not-allowed');
      }),
    );
  }
}
