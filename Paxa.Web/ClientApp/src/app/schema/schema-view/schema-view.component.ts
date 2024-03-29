import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Schema } from '@schema/services/schema.model';
import { SchemaEntry } from '@schema/services/schema-entry.model';
import { SchemaService } from '@schema/services/schema.service';
import { KeyPair } from '@shared/models/keypair.model';
import { LookupService } from '@shared/services/lookup-service/lookup.service';
import { Weekday } from '@shared/services/lookup-service/weekday.model';

@Component({
  selector: 'app-schema-view',
  templateUrl: './schema-view.component.html',
  styleUrls: ['./schema-view.component.css']
})
export class SchemaViewComponent implements OnInit {

  @Input() schemaId: number;

  private readonly selectedWeekdaySubject = new BehaviorSubject<number>(0);
  selectedWeekday$ = this.selectedWeekdaySubject.asObservable();

  weekdays$: Observable<KeyPair[]>;

  schema$: Observable<Schema>;
  schemaEntries$: Observable<SchemaEntry[]>;

  entryHeaders: KeyPair[] = [
    { key: 'startTime', value: 'Start'},
    { key: 'endTime', value: 'End' },
  ];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private schemaService: SchemaService,
    private lookupService: LookupService,
  ) { }

  ngOnInit(): void {
    // If no id was provided; Check params
    if (this.schemaId === undefined || this.schemaId === null) {
      this.schemaId = +this.activatedRoute.snapshot.params['id'];
    }

    this.weekdays$ = this.lookupService
      .getWeekdays()
      .pipe(
        map<Weekday[], KeyPair[]>((weekdays) => {
          return weekdays.map((e) => ({ key: e.number, value: e.name }));
        }),
      );

    this.schema$ = this.schemaService.getById(this.schemaId);
    this.schemaEntries$ = combineLatest([
      this.schema$,
      this.selectedWeekday$,
    ]).pipe(
      map(([schema, selectedWeekday]) => {
        const { schemaEntries } = schema;
        const matchingEntries = schemaEntries.filter((entry: SchemaEntry) => {
          return entry?.weekday?.number === selectedWeekday;
        });
        return matchingEntries;
      }),
    );
  }

  onExecuteSchema(): void {
    this.schemaService.execute(this.schemaId, 2022, 5, 15).subscribe()
  }

  onSelectTab(key: number): void {
    this.selectedWeekdaySubject.next(key);
  }

  onGoBack(): void {
    this.router.navigate(['/', 'schemas'], {
      queryParamsHandling: 'merge',
    });
  }

}
