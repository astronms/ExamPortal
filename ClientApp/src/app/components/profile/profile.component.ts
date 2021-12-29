import { Component, ViewEncapsulation } from '@angular/core';
import { UserModel } from 'src/app/models/user.model';

import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  public user: UserModel;

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
