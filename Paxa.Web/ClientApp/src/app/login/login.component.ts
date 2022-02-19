import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthorizationService } from '@shared/services/authorization-service/authorization.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup = this.formBuilder.group({
    email: ['johan.holmberg@domain.se', Validators.required],
    password: ['johan', Validators.required],
  });

  constructor(
    private formBuilder: FormBuilder,
    private authorizationService: AuthorizationService,
  ) { }

  ngOnInit(): void {

  }

  onSubmit(f: NgForm): void {
    this.authorizationService.authenticate(f.value).subscribe();
  }

}
