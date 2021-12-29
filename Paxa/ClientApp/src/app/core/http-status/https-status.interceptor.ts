import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import {MatSnackBar} from '@angular/material/snack-bar';
import { HttpsStatusService } from './https-status.service';

@Injectable()
export class HttpsStatusInterceptor implements HttpInterceptor {

  constructor(
    private snackBar: MatSnackBar,
    private httpStatusService: HttpsStatusService,
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    this.httpStatusService.addPendingRequest();
    return next.handle(request).pipe(
      map((event) => {
        return event;
      }),
      catchError((error) => {
        this.snackBar.open(error?.error?.message, 'Close', { duration: 5000 });
        return Observable.throw(error);
      }),
      finalize(() => {
        this.httpStatusService.removePendingRequest();
      })
    );
  }
}
