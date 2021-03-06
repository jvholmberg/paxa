import { BehaviorSubject, Observable } from 'rxjs';
import { logInfo } from '@utils/logger';
import { Confirmation } from '@shared/models/confirmation.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';

export abstract class BaseService<T> {

  private readonly loadingSource: BehaviorSubject<boolean>;
  private readonly errorSource: BehaviorSubject<Error>;
  private readonly valueSource: BehaviorSubject<T>;

  public readonly loading$: Observable<boolean>;
  public readonly error$: Observable<Error>;
  public readonly value$: Observable<T>;

  serviceUrl: string;
  initialized: boolean;

  constructor(private http: HttpClient, name: string) {
    this.serviceUrl = `${environment.apiUrl}/${name}`;
    this.initialized = false;

    this.loadingSource = new BehaviorSubject<boolean>(false);
    this.errorSource = new BehaviorSubject<Error>(null);
    this.valueSource = new BehaviorSubject<T>(null);

    this.loading$ = this.loadingSource.asObservable();
    this.error$ = this.errorSource.asObservable();
    this.value$ = this.valueSource.asObservable();
  }

  private setLoading(loading: boolean): void {
    logInfo(`${this.serviceUrl} => setLoading`, loading);
    this.loadingSource.next(loading);
  }

  private setError(error: Error): void {
    logInfo(`${this.serviceUrl} => setError`, error);
    this.errorSource.next(error);
  }

  private setValue(value: T): void {
    logInfo(`${this.serviceUrl} => setValue`, value);
    this.valueSource.next(value);
  }

  get(): Observable<T> {
    logInfo(`${this.serviceUrl} => get`);
    this.setLoading(true);

    if (!this.initialized) {
      this.http.get<T>(this.serviceUrl).subscribe(
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

  getById(id: number): Observable<T> {
    logInfo(`${this.serviceUrl} => getById`);
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