import { Component, OnInit } from '@angular/core';
import { UserService } from '@user/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  title = 'app';

  constructor(private userService: UserService) {}

  ngOnInit(): void {
  }
}
