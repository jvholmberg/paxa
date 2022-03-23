import { Component, Input, OnInit } from '@angular/core';
import { faTwitter, faFacebookF, faInstagram } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.css']
})
export class IconComponent implements OnInit {

  @Input() icon: string;

  faIcon: any;

  constructor() { }

  ngOnInit(): void {
    switch (this.icon) {
      case 'facebook': this.faIcon = faFacebookF; break;
      case 'twitter': this.faIcon = faTwitter; break;
      case 'instagram': this.faIcon = faInstagram; break;
    }
  }

}
