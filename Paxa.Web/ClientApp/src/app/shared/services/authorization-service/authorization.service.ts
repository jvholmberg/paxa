import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { BaseService } from '@core/base-service/base.service';
import { User } from '@user/services/user.model';
import { AuthenticateResponse } from '@shared/models/authenticate-response.model';
import { AuthenticateRequest } from '@shared/models/authenticate-request.model';
import { RevokeTokenRequest } from '@shared/models/revoke-token-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService extends BaseService<User> {

  private readonly jwtTokenSource = new BehaviorSubject<string>(null);

  public readonly jwtToken$ = this.jwtTokenSource.asObservable();
  public readonly loggedIn$ = this.jwtToken$.pipe(
    map((jwtToken) => !!jwtToken),
  );

  public get jwtTokenValue(): string { return this.jwtTokenSource.value; }

  constructor(http: HttpClient) {
    super(http, 'authorization');
  }

  public authenticate(body: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.http
      .post<AuthenticateResponse>(`${this.serviceUrl}/get-token`, body)
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
    const body: RevokeTokenRequest = {};
    return this.http
      .post<{}>(`${this.serviceUrl}/revoke-token`, body)
      .pipe(
        tap(() => {
          this.jwtTokenSource.next(null);
        }),
      );
  }
}
