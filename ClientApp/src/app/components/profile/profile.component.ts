import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: []
})
export class HomeComponent {
  constructor(private router: Router, private authService: AuthService ) { }

  ngOnInit() {
    /*
    if(this.authService.isUserAuthenticated())
      this.router.navigate(["/profile"]);
      */
  }
}