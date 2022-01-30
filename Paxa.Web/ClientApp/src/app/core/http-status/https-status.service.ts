import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpsStatusService {

  private numberOfPendingRequests: number = 0;

  private readonly loadingSource = new BehaviorSubject<boolean>(false);

  public readonly loading$ = this.loadingSource.asObservable();

  constructor() {}

  addPendingRequest(): void {
    if (this.numberOfPendingRequests === 0) {
      this.loadingSource.next(true);
    }
    this.numberOfPendingRequests++;
  }

  removePendingRequest(): void {
    this.numberOfPendingRequests--;
    if (this.numberOfPendingRequests === 0) {
      this.loadingSource.next(false);
    }
  }

}
