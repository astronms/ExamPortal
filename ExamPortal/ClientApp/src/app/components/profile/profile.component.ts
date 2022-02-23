import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AuthUserModel } from 'src/app/models/auth-user.model';

import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user: AuthUserModel;

  constructor(public authService: AuthService) {
  }

  ngOnInit()
  {
    this.user = this.authService.userValue;
  }

  changePassword(data)
  {
    
  }

}
