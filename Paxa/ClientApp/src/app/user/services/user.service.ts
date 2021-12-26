import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base-service';
import { User } from './user.model';
import { AuthenticateResponse } from './authenticate-response.model';
import { AuthenticateRequest } from './authenticate-request.model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User> {

  private readonly jwtTokenSource = new BehaviorSubject<string>(null);

  public readonly jwtToken$ = this.jwtTokenSource.asObservable();
  public readonly loggedIn$ = this.jwtToken$.pipe(
    map((jwtToken) => !!jwtToken),
  );

  public get jwtTokenValue(): string { return this.jwtTokenSource.value; }

  constructor(http: HttpClient) {
    super(http, 'users');
  }

  public authenticate(body: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.http
      .post<AuthenticateResponse>(`${this.serviceUrl}/authenticate`, body)
      .pipe(
        tap((res) => {
          const user: User = {
            id: res.userId,
            personId: res.personId,
            organizationId: res.organizationId,
            email: res.email,
          };
          this.jwtTokenSource.next(res.jwtToken);
          this.setValue([user]);
        }),
      );
  }

  public refreshToken(): Observable<AuthenticateResponse> {
    return this.http
      .post<AuthenticateResponse>(`${this.serviceUrl}/refresh-token`, {})
      .pipe(
        tap((res) => {
        const user: User = {
          id: res.userId,
          personId: res.personId,
          organizationId: res.organizationId,
          email: res.email,
        };
        this.jwtTokenSource.next(res.jwtToken);
        this.setValue([user]);
      }),
    );
  }

  public revokeToken(): Observable<{}> {
    return this.http
      .post<{}>(`${this.serviceUrl}/revoke-token`, {})
      .pipe(
        tap(() => {
          this.jwtTokenSource.next(null);
        }),
      );
  }
}
