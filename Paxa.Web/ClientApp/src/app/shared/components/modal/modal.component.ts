import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() title: string;
  @Input() submitText: string;
  @Input() cancelText: string;
  @Output() submit = new EventEmitter();
  @Output() cancel = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.submit.emit();
  }

  onCancel(): void {
    this.cancel.emit();
  }

}
