import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { KeyPair } from '@shared/models/keypair.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  private readonly sortBySubject = new BehaviorSubject<string>(null);
  private readonly sortDescendingSubject = new BehaviorSubject<boolean>(null);

  sortBy$ = this.sortBySubject.asObservable();
  sortDescending$ = this.sortDescendingSubject.asObservable();

  get sortByValue(): string { return this.sortBySubject.value; }
  get sortDescendingValue(): boolean { return this.sortDescendingSubject.value; }

  @Input() headers: KeyPair[];
  @Output() sort = new EventEmitter();

  constructor() { }

  ngOnInit(): void {}

  onSort(key: string): void {
    if (key) {
      if (this.sortByValue === key) {
        this.sortDescendingSubject.next(!this.sortDescendingValue);
      } else {
        this.sortBySubject.next(key);
        this.sortDescendingSubject.next(true);
      }
    }

    this.sort.emit({
      sortBy: this.sortByValue,
      sortDescending: this.sortDescendingValue,
    });
  }
}
