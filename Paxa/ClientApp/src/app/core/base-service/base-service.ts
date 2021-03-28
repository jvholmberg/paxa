import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { logInfo } from '@utils/logger';
import { Confirmation } from '@shared/models/confirmation.model';
import { HttpClient } from '@angular/common/http';
import { map, share } from 'rxjs/operators';
import { environment } from '@environments/environment';

export abstract class BaseService<T> {

  private readonly loadingSource: BehaviorSubject<boolean>;
  private readonly errorSource: BehaviorSubject<Error>;
  private readonly allIdsSource: BehaviorSubject<number[]>;
  private readonly byIdSource: BehaviorSubject<{}>;

  public readonly loading$: Observable<boolean>;
  public readonly error$: Observable<Error>;
  public readonly allIds$: Observable<number[]>;
  public readonly byId$: Observable<{}>;

  http: HttpClient;
  serviceUrl: string;
  initialized: boolean;

  constructor(http: HttpClient, name: string) {
    this.http = http;
    this.serviceUrl = `${environment.apiUrl}/${name}`;
    this.initialized = false;

    this.loadingSource = new BehaviorSubject<boolean>(false);
    this.errorSource = new BehaviorSubject<Error>(null);
    this.allIdsSource = new BehaviorSubject<number[]>([]);
    this.byIdSource = new BehaviorSubject<{}>({});

    this.loading$ = this.loadingSource.asObservable();
    this.error$ = this.errorSource.asObservable();
    this.allIds$ = this.allIdsSource.asObservable();
    this.byId$ = this.byIdSource.asObservable();
  }

  public get value$(): Observable<T[]> {
    return combineLatest([this.allIds$, this.byId$]).pipe(
      map(([ids, values]) => ids.reduce((acc, id) => {
        const item: T = values[id];
        return item !== null
          ? [...acc, item]
          : acc;
      }, [])),
      share(),
    );
  }

  private setLoading(loading: boolean): void {
    logInfo(`${this.serviceUrl} => setLoading`, loading);
    this.loadingSource.next(loading);
  }

  private setError(error: Error): void {
    logInfo(`${this.serviceUrl} => setError`, error);
    this.errorSource.next(error);
  }

  private setInitialValue(id: number): void {
    logInfo(`${this.serviceUrl} => setInitialValue`, id);
    const previous = this.byIdSource.value;
    if (previous[id] === null) {
      this.byIdSource.next({ ...previous, [id]: null });
      this.allIdsSource.next([ ...this.allIdsSource.value, id ]);
    }
  }

  setValue(value: T[]): void {
    logInfo(`${this.serviceUrl} => setValue`, value);
    const next = value.reduce((acc, val: T) => {
      const id: number = val['id'];
      if (acc.byId[id] === null) {
        acc.allIds.push(id);
      }
      acc.byId[id] = val;
      return acc;
    }, { allIds: this.allIdsSource.value, byId: this.byIdSource.value });
    this.byIdSource.next(next.byId);
  }

  get(): Observable<T[]> {
    logInfo(`${this.serviceUrl} => get`);
    this.setLoading(true);

    if (!this.initialized) {
      this.http.get<T[]>(this.serviceUrl).subscribe(
        (res) => {
          this.initialized = true;
          this.setValue(res);
          this.setError(null);
        },
        (err) => {
          this.setValue(null);
          this.setError(err);
        },
        () => {
          this.setLoading(false);
        }
      );
    }
    return this.value$;
  }

  getById(id: number, force: boolean = true): Observable<T> {
    logInfo(`${this.serviceUrl} => getById`, id);
    this.setInitialValue(id);
    return this.http.get<T>(`${this.serviceUrl}/${id}`);
  }

  create(body: {}): Observable<Confirmation> {
    logInfo(`${this.serviceUrl} => create`, body);
    return this.http.post<Confirmation>(this.serviceUrl, body);
  }

  update(id: number, body: {}): Observable<Confirmation> {
    logInfo(`${this.serviceUrl} => update`, id, body);
    return this.http.put<Confirmation>(`${this.serviceUrl}/${id}`, body);
  }

  delete(id: number): Observable<Confirmation> {
    logInfo(`${this.serviceUrl} => delete`, id);
    return this.http.delete<Confirmation>(`${this.serviceUrl}/${id}`);
  }
}
