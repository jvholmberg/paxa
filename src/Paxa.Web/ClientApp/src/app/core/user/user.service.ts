import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { logInfo } from '@utils/logger';
import { UserProxy } from './user.proxy.base';
import { User } from '@shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly entitySource = new BehaviorSubject<User>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly entity$ = this.entitySource.asObservable();

  constructor(private proxy: UserProxy) { }

  private setSource(loading: boolean, error: Error, entity: User): void {
    logInfo('UserService.setSource', loading, error, entity);
    this.loadingSource.next(loading);
    this.errorSource.next(error);
    this.entitySource.next(entity);
  }

  public getEntity(): Observable<User> {
    this.loadingSource.next(true);
    this.proxy.get().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public createEntity(): Observable<User> {
    this.loadingSource.next(true);
    this.proxy.post().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public updateEntity(): Observable<User> {
    this.loadingSource.next(true);
    this.proxy.update().subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );
    return this.entity$;
  }

  public deleteEntity(): void {
    this.loadingSource.next(true);
    this.proxy.delete().subscribe(
      () => this.setSource(false, null, null),
      (err) => this.setSource(false, err, null),
    );
  }
}
