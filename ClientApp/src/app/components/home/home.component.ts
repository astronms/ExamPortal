import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private router: Router, private authService: AuthService ) { }

  ngOnInit() {
    //if(this.authService.isUserAuthenticated())
      //this.router.navigate(["/exams"]);

    //this.authService.getUserRole();
  }
}
