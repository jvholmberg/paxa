import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { KeyPair } from '@shared/models/keypair.model';

@Component({
  selector: 'app-tab-strip',
  templateUrl: './tab-strip.component.html',
  styleUrls: ['./tab-strip.component.css']
})
export class TabStripComponent implements OnInit {

  @Input() tabs: KeyPair[];
  @Input() active: string | number;
  @Output() select = new EventEmitter();

  constructor() { }

  ngOnInit(): void {}

  onSelect(key: string | number): void {
    this.select.emit(key);
  }

}
