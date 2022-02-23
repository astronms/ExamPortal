import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: []
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor( private router: Router, private authService: AuthService ) { }

  signIn(form: NgForm) {
    this.authService.login(form.value)
      .subscribe(result => {
        if(result)
          this.router.navigate(["/"]);
        else
          this.invalidLogin = true;
      },
      err =>
        this.invalidLogin = true
      );
  }
 }
