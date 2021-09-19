import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, finalize, map, switchMap, take } from 'rxjs/operators';
import { UserService } from '@user/services/user.service';
import { environment } from '@environments/environment';

@Injectable()
export class BearerTokenInterceptor implements HttpInterceptor {

  constructor(private userService: UserService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    // Add authorization-header?
    if (request.url.startsWith(environment.apiUrl)) {
      const authorizedRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.userService.jwtTokenValue}`,
        }
      });
      return next.handle(authorizedRequest);
    }
    return next.handle(request);
  }
}
