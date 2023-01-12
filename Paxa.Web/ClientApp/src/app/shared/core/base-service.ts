import { BehaviorSubject, combineLatest, Observable, of } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, skipWhile, tap } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { PageList } from '@shared/models/pagelist.model';

export abstract class BaseService<T> {

  private readonly loadingSource: BehaviorSubject<boolean>;
  private readonly errorSource: BehaviorSubject<Error>;
  private readonly allIdsSource: BehaviorSubject<number[]>;
  private readonly byIdSource: BehaviorSubject<{}>;

  public readonly loading$: Observable<boolean>;
  public readonly error$: Observable<Error>;
  public readonly allIds$: Observable<number[]>;
  public readonly byId$: Observable<{}>;

  public readonly value$: Observable<T[]>;

  public get loadingValue(): boolean { return this.loadingSource.value; }

  /**
   * DO NOT USE. BAD PRACTICE.
   * TODO: Remove asap (Only added for migration purposes)
   */
  public get byIdValue(): {} { return this.byIdSource.value; }
  /**
   * DO NOT USE. BAD PRACTICE
   * TODO: Remove asap (Only added for migration purposes)
   */
  public get allIdsValue(): number[] { return this.allIdsSource.value; }

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

    this.value$ = combineLatest([this.allIds$, this.byId$]).pipe(
      map(([ids, values]) => ids.reduce((acc, id) => {
        const item: T = values[id];
        return item !== null
          ? [...acc, item]
          : acc;
      }, [])),
    );
  }

  /**
   * Create Params for request
   * @param query Object to be turned into valid HttpParams
   * @returns HttpParams for passed in object
   */
  createParams(query: {}): HttpParams {
    let params = new HttpParams();
    Object.entries(query).forEach(([key, value]: [param: string, value: string | number | []]) => {
      // Manage string and numeric values
      const isString = typeof value === 'string' && value?.length > 0;
      const isNumber = typeof value === 'number';
      if (isString || isNumber) {
        params = params.append(key, `${value}`);
        return;
      }

      // Manage boolean values
      const isBoolean = typeof value === 'boolean';
      if (isBoolean) {
        params = params.append(key, value ? '1' : '0');
        return;
      }

      // Manage Arrays
      const isArray =  typeof value === 'object' && value?.length > 0;
      if (isArray) {
        const rawArray = value as [];
        const filteredArray = rawArray.filter((e) => !!e);
        const parsedArray = filteredArray?.join(',');
        params = params.append(key, parsedArray);
      }
    });
    return params;
  }

  /**
   * Set loading status in internal state
   * @param loading
   */
  setLoading(loading: boolean): void {
    this.loadingSource.next(loading);
  }

  /**
   * Set error in internal state
   * @param error
   */
  setError(error: Error): void {
    this.errorSource.next(error);
  }

  /**
   * Set initial value for entity in internal state.
   * @param id
   * @returns
   */
  setInitialValue(id: number): void {
    // Validation
    if (typeof id !== 'number') {
      return;
    }

    // Execute
    const previousValue = this.byIdSource.value;
    if (previousValue[id] === null) {
      this.byIdSource.next({ ...previousValue, [id]: null });
      this.allIdsSource.next([ ...this.allIdsSource.value, id ]);
    }
  }

  /**
   * Remove entity in internal state.
   * @param id
   */
  removeValue(id: number): void {
    // Execute
    const nextAllIds = this.allIdsSource.value.filter((e) => e !== id);
    const nextById = { ...this.byIdSource.value, [id]: undefined };

    this.allIdsSource.next(nextAllIds);
    this.byIdSource.next(nextById);
  }

  /**
   * Get next value
   * @param allIdsValue
   * @param byIdValue
   * @param value
   * @returns
   */
  getNextValue<Y>(allIdsValue: number[], byIdValue: {}, value: Y[]): { allIds: number[], byId: {} } {
    // Validation
    if (!value || !value.length) {
      return {
        allIds: allIdsValue,
        byId: byIdValue,
      };
    }

    // Execute
    const initialValue = {
      allIds: allIdsValue,
      byId: byIdValue,
    };

    const nextValue = value.reduce((previousValue, currentValue: Y) => {
      const id: number = currentValue['id'];
      if (previousValue.byId[id] === undefined || previousValue.byId[id] === null) {
        previousValue.allIds.push(id);
      }
      previousValue.byId[id] = currentValue;
      return previousValue;
    }, initialValue);

    return nextValue;
  }

  /**
   * Set internal value
   * @param value
   * @returns
   */
  setValue(value: T[]): void {
    const nextValue = this.getNextValue<T>(
      this.allIdsSource.value,
      this.byIdSource.value,
      value,
    );

    this.allIdsSource.next(nextValue.allIds);
    this.byIdSource.next(nextValue.byId);
  }

  /**
   * Get all entities
   * @param force
   * @returns
   */
  get(force: boolean = false): Observable<T[]> {
    this.setLoading(true);
    if (!this.initialized || force) {
      this.http.get<T[]>(this.serviceUrl).subscribe({
        next: (res) => {
          this.initialized = true;
          this.setValue(res);
          this.setError(null);
        },
        error: (err) => {
          this.setValue(null);
          this.setError(err);
        },
        complete: () => {
          this.setLoading(false);
        },
      });
    }

    return this.value$;
  }

  /**
   * Get entities matching query
   * @param query
   * @returns
   */
  query(query: {}): Observable<T[]> {
    this.setLoading(true);

    const params = this.createParams(query);
    return this.http.get<T[]>(this.serviceUrl, { params }).pipe(
      tap({
        next: (res) => {
          this.setValue(res);
        },
        error: (err) => {
          this.setValue(null);
          this.setError(err);
        },
        complete: () => {
          this.setLoading(false);
        },
      }),
    );
  }

  /**
   * Get page with entries matching query
   * @param query
   * @returns
   */
   getPageList(query: {}): Observable<PageList<T>> {

    const params = this.createParams(query);
    return this.http.get<PageList<T>>(`${this.serviceUrl}/page-list`, { params }).pipe(
      tap({
        next: (res) => {
          this.setValue(res.records);
        },
        error: (err) => {
          this.setValue(null);
          this.setError(err);
        },
        complete: () => {
          this.setLoading(false);
        },
      }),
    );
  }

  /**
   * Get entity by id
   * @param id
   * @param force
   * @returns
   */
  getById(id: number, force: boolean = true): Observable<T> {
    // Get current value
    this.setInitialValue(id);
    const previousValue = this.byIdSource.value[id];

    // Update existing value
    if (!previousValue || force) {
      this.http.get<T>(`${this.serviceUrl}/${id}`).subscribe({
        next: (res) => {
          this.setValue([res]);
          this.setError(null);
        },
        error: (err) => {
          this.setValue(null);
          this.setError(err);
        },
        complete: () => {
          this.setLoading(false);
        },
      });
    }

    // Return value
    return this.byId$.pipe(
      map((byIds) => byIds[id]),
      skipWhile((e) => !e),
    );
  }

  /**
   * Create entity
   * @param body
   * @returns
   */
  create(body: {}): Observable<T> {
    return this.http.post<T>(this.serviceUrl, body).pipe(
      tap((res) => {
        this.setValue([res]);
      }),
    );
  }

  /**
   * Update entity with id
   * @param id
   * @param body
   * @returns
   */
  update(id: number, body: {}): Observable<T> {
    return this.http.put<T>(`${this.serviceUrl}/${id}`, body).pipe(
      tap((res) => {
        this.setValue([res]);
      }),
    );
  }

  /**
   * Delete entity with id
   * @param id
   * @returns
   */
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.serviceUrl}/${id}`).pipe(
      tap(() => {
        this.removeValue(id);
      }),
    );
  }
}
