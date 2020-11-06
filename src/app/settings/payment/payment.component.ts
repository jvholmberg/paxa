import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  paymentForm = this.fb.group({
    cardNumber: ['', Validators.required],
    /*firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    expiryYear: ['', Validators.required],
    expiryMonth: ['', Validators.required],
    controlCode: ['', Validators.required],*/
  });

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {}

}
