import { Injectable } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { UserService } from '@user/services/user.service';

@Injectable({
  providedIn: 'root'
})
export class ResourceGuard implements CanLoad {
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
