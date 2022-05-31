import { Component, Input, OnInit } from '@angular/core';
import { Timeslot } from '@timeslot/services/timeslot.model';
import { TimeslotService } from '@timeslot/services/timeslot.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-timeslot-list',
  templateUrl: './timeslot-list.component.html',
  styleUrls: ['./timeslot-list.component.css']
})
export class TimeslotListComponent implements OnInit {

  @Input() resourceId: number;

  timeslots$: Observable<Timeslot[]>;

  headers = [
    { key: 'from', value: 'From'},
    { key: 'to', value: 'To' },
  ];

  constructor(private timeslotService: TimeslotService) { }

  ngOnInit(): void {
    const params = this.resourceId
      ? { organizationId: this.resourceId }
      : null;

    this.timeslots$ = params
      ? this.timeslotService.query(params)
      : this.timeslotService.get();
  }

}
