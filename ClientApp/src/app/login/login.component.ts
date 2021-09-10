import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { catchError, map } from 'rxjs/operators';
import { Observable, of, pipe } from 'rxjs';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor( private router: Router, private authService: AuthService ) { }

  signIn(form: NgForm) {
    this.authService.login(form.value)
      .subscribe(result => {
        const token = (<any>result).token;
        if(result && token) {
          localStorage.setItem("jwt", token);
          this.router.navigate(["/"]);
        }
        else {
          this.invalidLogin = true;
        }
      },
      err => {
        this.invalidLogin = true;
      });
  }
 }
