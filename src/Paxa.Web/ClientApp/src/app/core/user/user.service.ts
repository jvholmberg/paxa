import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserProxy } from './user.proxy.base';
import { User } from '@shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly entitySource = new BehaviorSubject<User>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly entity$ = this.entitySource.asObservable();

  constructor(private proxy: UserProxy) { }

  private setSource(
    loading: boolean,
    error?: Error,
    entity?: User
  ): void {
    this.initialized = true;
    this.loadingSource.next(loading);
    if (error !== undefined) { this.errorSource.next(error); }
    if (entity !== undefined) { this.entitySource.next(entity); }
  }

  public getEntity(): Observable<User> {
    this.setSource(true);
    this.proxy.get().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public createEntity(): Observable<User> {
    this.setSource(true);
    this.proxy.create().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public updateEntity(): Observable<User> {
    this.setSource(true);
    this.proxy.update().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public deleteEntity(): void {
    this.setSource(true);
    this.proxy.delete().subscribe(
      (val) => this.setSource(false, null, val ? null : undefined),
      (err) => this.setSource(false, err, null),
    );
  }
}
