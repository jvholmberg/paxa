import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '@environments/environment';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Injectable()
export class BearerTokenInterceptor implements HttpInterceptor {

  constructor(private authorizationService: AuthorizationService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    // Add authorization-header?
    if (request.url.startsWith(environment.apiUrl)) {
      const authorizedRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.authorizationService.jwtTokenValue}`,
        }
      });
      return next.handle(authorizedRequest);
    }
    return next.handle(request);
  }
}
