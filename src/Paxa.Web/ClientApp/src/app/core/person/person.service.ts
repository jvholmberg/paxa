import { Injectable } from '@angular/core';
import { PersonProxy } from './person.proxy.base';
import { BehaviorSubject, Observable } from 'rxjs';
import { Person } from 'src/app/shared/models/person.model';
import { UserService } from '@core/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private initialized = false;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);
  private readonly errorSource = new BehaviorSubject<Error>(undefined);
  private readonly collectionSource = new BehaviorSubject<Person[]>(undefined);

  public readonly loading$ = this.loadingSource.asObservable();
  public readonly error$ = this.errorSource.asObservable();
  public readonly collection$ = this.collectionSource.asObservable();

  constructor(
    private proxy: PersonProxy,
    private userService: UserService
  ) { }

  private setSource(
    loading: boolean,
    error?: Error,
    collection?: Person[]
  ): void {
    this.initialized = true;
    this.loadingSource.next(loading);
    if (error !== undefined) { this.errorSource.next(error); }
    if (collection !== undefined) { this.collectionSource.next(collection); }
  }

  getById(personId: number): Observable<Person[]> {
    return this.getByIds([personId]);
  }

  getByIds(personIds: number[]): Observable<Person[]> {
    this.setSource(true);
    this.proxy.get(personIds).subscribe(
      (val) => this.setSource(false, null, val),
      (err) => this.setSource(false, err, null),
    );

    return this.collection$;
  }
}
